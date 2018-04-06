angular.module('myApp')
    .controller('StandardSolutionAndExamplesCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");



    });