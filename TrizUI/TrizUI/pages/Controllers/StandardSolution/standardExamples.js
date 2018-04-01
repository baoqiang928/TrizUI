angular.module('myApp')
.directive('standardExamples', function (requestService, locals) {
    return {
        //scope: {},
        restrict: 'E',
        //require: '^outerDirective',
        templateUrl: 'standardExamples.html',
        replace: true,
        link: function (scope, elem, attrs) { //controllerInstance 调用另外一个directive的方法 需要require。//controllerInstance.say(scope);
            var CurrentProjectID = locals.get("ProjectID");
            






        },//link end


    };
});