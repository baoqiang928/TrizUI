angular.module('myApp')
.directive('componentParam', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'componentParam.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");

            scope.ADDRelOperate = function (i) {
                var componentRelInfo1 = new scope.ComponentRelInfo();
                scope.ComponentRelInfoListSection[i].push(componentRelInfo1);
            };
            scope.DelRelOperate = function (SectionIndex, Index) {
                bootbox.confirm("确认删除该条记录吗？", function (result) {
                    if (result) {
                        scope.$apply(function () {
                            scope.ComponentRelInfoListSection[SectionIndex].splice(Index, 1);
                        });
                    }
                });
            };

            scope.UpdateSectionOperate = function (i) {
                bootbox.confirm("修改操作会清除当前分析结果之后的内容，确认该操作吗？", function (result) {
                    if (result) {
                        //cleare section after i.
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


            scope.SaveRelOperate = function (i) {
                //disabled
                scope.SetDisabledBySectionIndex(i);

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
            };
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

            scope.SetDisabledBySectionIndex = function (i) {
                for (var j = 0; j < scope.ComponentRelInfoListSection[i].length; j++) {
                    scope.ComponentRelInfoListSection[i][j].Disabled = true;
                }
            };






        },//link end


    };
});