angular.module('myApp')
.directive('primaryComponentparam', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'primaryComponentParam.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");

            //新增
            scope.ADDParamInfoOperate = function () {
                var newobj1 = new scope.ComponentParamInfo();
                scope.ComponentParamInfoList.push(newobj1);
            }

            //保存
            scope.SaveParamInfoOperate = function () {
                scope.ClearComponentRelInfoListAndSection();
                scope.InsertComponentToRelInfoList();
                scope.InsertComponentRelInfoListToSection();
                scope.RelListFromPreSection = [];
                for (var j = 0; j < scope.ComponentParamInfoList.length; j++) {
                    if (scope.ComponentParamInfoList[j].ParamType == "非独立变量") {
                        var componentRelInfo = new scope.ComponentRelInfo();
                        componentRelInfo.ImpactComponentName = scope.ComponentParamInfoList[j].ComponentName;
                        componentRelInfo.ImpactParamName = scope.ComponentParamInfoList[j].ParamName;
                        componentRelInfo.ParamType = scope.ComponentParamInfoList[j].ParamType;
                        scope.RelListFromPreSection.push(componentRelInfo);
                    }
                }
                //set disabled
                scope.SetComponentParamInfoListDisabled(true);

                //save to database
                scope.SaveToComponentParamInfoListDB();
            }

            scope.SetComponentParamInfoListDisabled = function (flag) {
                for (var j = 0; j < scope.ComponentParamInfoList.length; j++) {
                    scope.ComponentParamInfoList[j].Disabled = flag;
                }
            };

            scope.ClearComponentRelInfoListAndSection = function () {
                scope.ComponentRelInfoList = [];
                scope.ComponentRelInfoListSection = [];
            };

            scope.InsertComponentToRelInfoList = function () {
                var componentRelInfo = new scope.ComponentRelInfo();
                scope.ComponentRelInfoList.push(componentRelInfo);
            };

            scope.InsertComponentRelInfoListToSection = function () {
                scope.ComponentRelInfoListSection.push(scope.ComponentRelInfoList);
            };

            scope.DeleteComponentParamInfo = function (index) {
                bootbox.confirm("要删除当前的记录？", function (result) {
                    if (result) {
                        console.log("scope.ComponentParamInfoList", scope.ComponentParamInfoList);
                        requestService.delete("ComponentParams", scope.ComponentParamInfoList[index].ID).then(function (data) {
                        });
                        scope.ComponentParamInfoList.splice(index, 1);
                        scope.$apply();
                    }
                });
            }

            scope.UpdateParamInfoOperate = function () {
                bootbox.confirm("修改操作会清除当前分析结果之后的内容，确认该操作吗？", function (result) {
                    if (result) {
                        scope.$apply(function () {
                            scope.ComponentRelInfoList = [];
                            scope.ComponentRelInfoListSection = [];
                            scope.ConflictInfoList = [];
                            scope.SetComponentParamInfoListDisabled(false);
                        });
                    }
                });
            }

            scope.SaveToComponentParamInfoListDB = function () {
                for (var i = 0; i < scope.ComponentParamInfoList.length; i++) {
                    if (scope.ComponentParamInfoList[i].ID == "") {
                        requestService.add("ComponentParams", scope.ComponentParamInfoList[i]).then(function (data) {

                        });
                    }
                    else {
                        requestService.update("ComponentParams", scope.ComponentParamInfoList[i]).then(function (data) {

                        });
                    }
                }

            };


            var GetComponentParams = function () {
                var data = {
                    currentPage: "",
                    itemsPerPage: "",
                    ProjectID: scope.CurrentProjectID,
                    ParamType: "",
                    Disabled: ""
                };
                data.currentPage = 1;
                data.itemsPerPage = 999;
                requestService.lists("ComponentParams", data).then(function (data) {
                    scope.ComponentParamInfoList = data.Results;
                });
            }
            GetComponentParams();
        },


    };
});