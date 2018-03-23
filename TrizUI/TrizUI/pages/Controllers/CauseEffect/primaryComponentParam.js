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
                RelListFromPreSection = [];
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
        },


    };
});