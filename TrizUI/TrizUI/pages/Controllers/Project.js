angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService) {

        var Sources = "Projects";

        $scope.paginationConf = {
            currentPage: 1,
            totalItems: 8000,
            itemsPerPage: 15,
            pagesLength: 15,
            perPageOptions: [10, 20, 30, 40, 50],
            onChange: function () {
            }
        };

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            Name: "",
            Code: "",
            Owner: "",
            Department: "",
            FromDate: "",
            ToDate: ""
        };

        var GetProjects = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.projects = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetProjects);

        $scope.Query = function () {
            GetProjects();
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





//angular.module('myApp', ['tm.pagination']).controller('ProjectCtrl', function ($scope, $timeout) {
//    /**
//     * I'm not good at English, wish you you catch what I said And help me improve my English.
//     *
//     * A lightweight and useful pagination directive
//     * conf is a object, it has attributes like below:
//     *
//     * currentPage: Current page number, default 1
//     * totalItems: Total number of items in all pages, if you want to get totalItems from ajaxRequest,
//     *             you can set the totalItems in onChange function;
//     *             
//     * itemsPerPage:  number of items per page, default 15
//     * onChange: when the pagination is change, it will excute the function.
//     * pagesLength: number for pagination size, default 9
//     * perPageOptions: defind select how many items in a page, default [10, 15, 20, 30, 50]
//     *
//     */
//    $scope.paginationConf = {
//        currentPage: 1,
//        totalItems: 8000,
//        itemsPerPage: 15,
//        pagesLength: 15,
//        perPageOptions: [10, 20, 30, 40, 50],
//        onChange: function () {
//        }
//    };







//});