angular.module('myApp')
    .controller('ConflictResolveOpeCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {

        //alert($stateParams.ConflictID);
        //$stateParams.TreeTypeID = "2";

        //$scope.$on("ANode", CurrentNode.$modelValue);
        $scope.$on("nodeData", function (event, msg) {
            $scope.nodeData = msg;
        });
    });