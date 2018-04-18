angular.module('myApp')
.directive('currentProblem', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'currentProblem.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            requestService.getobj("CauseEffectCurProblems", scope.data.ProjectID).then(function (data) {
                //scope.CurrentProblemDes = data.ProblemDescription;
                console.log("data", data);
                scope.data = data;
            });

            //scope.data = {
            //    ProjectID: locals.get("ProjectID"),
            //    ProblemDescription: "",
            //    AltinativeProblem: "",
            //    TechConflict: "",
            //    PhyConflict: ""
            //};
            scope.SaveCurrentProblemDes = function () {
                //if (!$('#validation-form').valid()) {
                //    return false;
                //}
                requestService.add("CauseEffectCurProblems", scope.data).then(function (data) { });
                return;
            };
        },


    };
});