﻿angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService) {

        $scope.Query = function () {
            alert('Query');
            //$location.path("/AddProject");
        }
        $scope.Save = function () {
            alert($scope.Owner);
            //$location.path("/AddProject");
        }

        $scope.Owner = "2"
        requestService.lists($scope.Owner).then(function (data) {
            //alert(data.Name);
            //if (data._code === 200) {
            $scope.projects = data;
            //alert($scope.projects.length);
            //alert($scope.projects[0].Id);
            //};
        });


    });





angular.module('myApp', ['tm.pagination']).controller('ProjectCtrl', function ($scope, $timeout) {
    /**
     * I'm not good at English, wish you you catch what I said And help me improve my English.
     *
     * A lightweight and useful pagination directive
     * conf is a object, it has attributes like below:
     *
     * currentPage: Current page number, default 1
     * totalItems: Total number of items in all pages, if you want to get totalItems from ajaxRequest,
     *             you can set the totalItems in onChange function;
     *             
     * itemsPerPage:  number of items per page, default 15
     * onChange: when the pagination is change, it will excute the function.
     * pagesLength: number for pagination size, default 9
     * perPageOptions: defind select how many items in a page, default [10, 15, 20, 30, 50]
     *
     */
    $scope.paginationConf = {
        currentPage: 1,
        totalItems: 8000,
        itemsPerPage: 15,
        pagesLength: 15,
        perPageOptions: [10, 20, 30, 40, 50],
        onChange: function () {
        }
    };


    var GetAllEmployee = function () {
        alert($scope.paginationConf.currentPage);
    }


    $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetAllEmployee);




})