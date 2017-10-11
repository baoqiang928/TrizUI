angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location) {

        $scope.Query = function () {
            alert('Query');
            //$location.path("/AddProject");
        }

    });