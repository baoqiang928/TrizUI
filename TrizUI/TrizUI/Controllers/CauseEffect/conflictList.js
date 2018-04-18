angular.module('myApp')
.directive('conflictList', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'conflictList.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");


            scope.GenerateConflictList = function scopeGenerateConflictList() {
                scope.ConflictInfoList = [];
                //初级功能参数列表里的独立变量
                for (var i = 0; i < scope.ComponentParamInfoList.length; i++) {
                    console.log("scope.ComponentParamInfoList[i]", scope.ComponentParamInfoList[i]);
                    if (scope.ComponentParamInfoList[i].ParamType == "非独立变量") continue;
                    var NewConflictInfo = new scope.ConflictInfo();
                    NewConflictInfo.RelComponentName = scope.ComponentParamInfoList[i].ComponentName;
                    NewConflictInfo.RelComponentParamName = scope.ComponentParamInfoList[i].ParamName;
                    scope.ConflictInfoList.push(NewConflictInfo);
                }

                //功能参数列表里的所有独立变量
                for (var SectionIndex = 0; SectionIndex < scope.ComponentRelInfoListSection.length; SectionIndex++) {
                    for (var i = 0; i < scope.ComponentRelInfoListSection[SectionIndex].length; i++) {
                        if (scope.ComponentRelInfoListSection[SectionIndex][i].ParamType != "独立变量") continue;
                        var NewConflictInfo = new scope.ConflictInfo();
                        NewConflictInfo.RelComponentName = scope.ComponentRelInfoListSection[SectionIndex][i].ImpactComponentName;
                        NewConflictInfo.RelComponentParamName = scope.ComponentRelInfoListSection[SectionIndex][i].ImpactParamName;
                        scope.ConflictInfoList.push(NewConflictInfo);
                    }
                }
            }
            //保存事件
            scope.SaveConflict = function () {
                SaveToConflictListToDB();
                scope.GenerateMap();
                console.log("scope.ConflictInfoList", scope.ConflictInfoList);
            };
            function SaveToConflictListToDB() {
                for (var i = 0; i < scope.ConflictInfoList.length; i++) {
                    scope.ConflictInfoList[i].ProjectID = CurrentProjectID;
                    if (scope.ConflictInfoList[i].ID == "") {
                        requestService.add("Conflicts", scope.ConflictInfoList[i]).then(function (data) { });
                    }
                    else {
                        requestService.update("Conflicts", scope.ConflictInfoList[i]).then(function (data) { });
                    }
                }

            };

            scope.ClearAllConflictFromDB = function () {
                for (var i = 0; i < scope.ConflictInfoList.length; i++) {
                    requestService.delete("Conflicts", scope.ConflictInfoList[i].ID).then(function (data) { });
                }
            }

            scope.IsChecked = function (visible) {
                if ((visible == "False") || (!visible) || (visible == "false")) return false;
                return true;
            }
            var GetConflicts = function () {
                var data = {
                    currentPage: "",
                    itemsPerPage: "",
                    ProjectID: CurrentProjectID
                };
                data.currentPage = 1;
                data.itemsPerPage = 999;
                requestService.lists("Conflicts", data).then(function (data) {
                    scope.ConflictInfoList = data.Results;
                });
            }
            GetConflicts();

        },//link end


    };
});