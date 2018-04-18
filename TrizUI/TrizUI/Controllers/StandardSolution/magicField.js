angular.module('myApp')
.directive('currentProbleml', function (requestService, locals) {
    return {
        restrict: 'E',
        template: '<div ng-include="getContentUrl()"></div>',
        replace: true,
        //transclude: true,
        link: function ($scope, $element, $attr) {
            $scope.getContentUrl = function () {
                template = $attr.type;
                //if ($attr.type == 1) {
                //    template = 'standardsolution.html'
                //}
                //if ($attr.type == 2) {
                //    template = 'need.html'
                //}
                return template;
            }
        }
    }
});