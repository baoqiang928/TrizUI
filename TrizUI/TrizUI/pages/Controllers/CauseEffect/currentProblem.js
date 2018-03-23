angular.module('myApp')
.directive('currentProblem', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'currentProblem.html',
        replace: true,
        link: function (scope, elem, attrs ) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");
            requestService.getobj("CauseEffectCurProblems", scope.CurrentProjectID).then(function (data) {
                scope.CurrentProblemDes = data.ProblemDescription;
            });

            var data = {
                ProjectID: "",
                ProblemDescription: ""
            };
            scope.SaveCurrentProblemDes = function () {
                //if (!$('#validation-form').valid()) {
                //    return false;
                //}
                data.ProjectID = CurrentProjectID;
                data.ProblemDescription = scope.CurrentProblemDes;
                requestService.add("CauseEffectCurProblems", data).then(function (data) {

                });
                return;
            };
        },


    };
});