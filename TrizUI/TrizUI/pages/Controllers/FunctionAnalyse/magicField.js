angular.module('myApp')
.directive('currentProbleml', function (requestService, locals) {
    return {
        restrict: 'E',
        template: '<div ng-include="getContentUrl()"></div>',
        replace: true,
        //transclude: true,
        link: function ($scope, $element, $attr) {
            $scope.getContentUrl = function () {
                if ($attr.type == 1) {
                    template = 'tpl/mgfield/input.html'
                }
                if ($attr.type == 2) {
                    template = 'tpl/mgfield/textarea.html'
                }
                return template;
            }
        }
    }
});