angular.module('myApp')
    .controller('ConflictResolveCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");



    });