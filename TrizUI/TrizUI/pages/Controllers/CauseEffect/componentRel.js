angular.module('myApp')
.directive('componentRel', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'componentRel.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");

            //增加事件
            scope.ADDRelOperate = function (i) {
                var componentRelInfo1 = new scope.ComponentRelInfo();
                scope.ComponentRelInfoListSection[i].push(componentRelInfo1);
            };

            //删除事件
            scope.DelRelOperate = function (SectionIndex, Index) {
                bootbox.confirm("确认删除该条记录吗？", function (result) {
                    if (result) {
                        requestService.delete("ComponentRels", scope.ComponentRelInfoListSection[SectionIndex][Index].ID).then(function (data) { });
                        scope.ComponentRelInfoListSection[SectionIndex].splice(Index, 1);
                        scope.$apply();

                    }
                });
            };

            //修改事件
            scope.UpdateSectionOperate = function (i) {
                bootbox.confirm("修改操作会清除当前分析结果之后的内容，确认该操作吗？", function (result) {
                    if (result) {
                        //clear section after i.
                        scope.DeleteAfterSectionIndexFromDB(i);
                        scope.ClearAllConflictFromDB();
                        scope.ComponentRelInfoListSection.splice(i + 1, scope.ComponentRelInfoListSection.length - i - 1);
                        //clear conflict list
                        scope.ConflictInfoList = [];

                        //set disabled
                        for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                            scope.ComponentRelInfoListSection[i][j].Disabled = "";
                        }

                        scope.$apply();
                    }
                });
            }

            scope.DeleteAfterSectionIndexFromDB = function (index) {
                for (var i = index + 1; i < scope.ComponentRelInfoListSection.length; i++) {
                    for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                        requestService.delete("ComponentRels", scope.ComponentRelInfoListSection[i][j].ID).then(function (data) { });
                    }
                }
            }

            //保存事件
            scope.SaveRelOperate = function (i) {
                //disabled
                SetDisabledBySectionIndex(i);

                //如果不存在非独立变量，则不生成新的
                if (ExistNotDependentParam(i)) {
                    var ComponentRelInfoList1 = [];
                    ComponentRelInfoList1.push(new scope.ComponentParamInfo());
                    scope.ComponentRelInfoListSection.push(ComponentRelInfoList1);
                }
                else {
                    //生成冲突列表 
                    scope.GenerateConflictList();
                }

                SaveToComponentRelInfoListDB(i);
            };

            function SaveToComponentRelInfoListDB(i) {
                for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                    scope.ComponentRelInfoListSection[i][j].SectionID = i;
                    if (scope.ComponentRelInfoListSection[i][j].ID == "") {
                        requestService.add("ComponentRels", scope.ComponentRelInfoListSection[i][j]).then(function (data) { });
                    }
                    else {
                        requestService.update("ComponentRels", scope.ComponentRelInfoListSection[i][j]).then(function (data) { });
                    }
                }

            };

            var GetComponentRels = function () {
                var data = {
                    currentPage: "",
                    itemsPerPage: "",
                    ProjectID: scope.CurrentProjectID,
                    SectionID: "",
                    ImpactParamName: "",
                    Disabled: ""
                };
                data.currentPage = 1;
                data.itemsPerPage = 9999;
                requestService.lists("ComponentRels", data).then(function (data) {
                    scope.ComponentRelInfoListSection = [];
                    var ComponentRelInfoList = [];
                    var j = 0;
                    for (var i = 0; i < data.Results.length; i++) {
                        if (j == data.Results[i].SectionID) {
                            ComponentRelInfoList.push(data.Results[i]);
                        }
                        else {
                            j = data.Results[i].SectionID;
                            scope.ComponentRelInfoListSection.push(ComponentRelInfoList);
                            ComponentRelInfoList = [];
                            ComponentRelInfoList.push(data.Results[i]);
                        }
                    }
                    //页面打开加载时，如果没有功能参数，不显示
                    if (ComponentRelInfoList.length > 0)
                        scope.ComponentRelInfoListSection.push(ComponentRelInfoList);
                });
            }

            GetComponentRels();

            function ExistNotDependentParam(i) {
                for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                    if (scope.ComponentRelInfoListSection[i][j].ParamType == "非独立变量") {
                        return true;
                    }
                }
                return false;
            }

            scope.PreSectionComponentList = function (i) {
                if (i == 0) {
                    return scope.RelListFromPreSection;
                }
                return scope.ComponentRelInfoListSection[i - 1];
            };

            function SetDisabledBySectionIndex(i) {
                for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                    scope.ComponentRelInfoListSection[i][j].Disabled = true;
                }
            };






        },//link end


    };
});