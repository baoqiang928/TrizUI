﻿angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location) {

        $scope.Query = function () {
            alert('Query');
            //$location.path("/AddProject");
        }

        $scope.toggle = function () {
            alert(1);
            $scope.visible = !$scope.visible;
        }


    });