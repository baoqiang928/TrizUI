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

            scope.SaveConflict = function () {
                scope.GenerateMap();
            };

        },//link end


    };
});