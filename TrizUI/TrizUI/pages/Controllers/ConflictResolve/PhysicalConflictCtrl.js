angular.module('myApp')
    .controller('PhysicalConflictCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");

        

    });//End