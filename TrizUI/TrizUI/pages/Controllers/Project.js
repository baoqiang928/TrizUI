angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService, $state) {

        var Sources = "Projects";
        $scope.abcd = "1234";
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

        $scope.Update = function (ID) {
            //requestService.getobj(Sources, ID).then(function (data) {
            //    //alert("data1.Name:" + data.Name);
            //    //$scope.abcd = data.Name;
            //    $scope.abcd = "9999999999999";
            //    $location.path("/ProjectAdd");
            //    $scope.data.Code = data.Code;
            //    $scope.data.Name = data.Name;
            //});
            //alert(ID);
            $scope.data.Name = "777";
            $scope.abcd = "9999999999999";
            //$location.path("/ProjectAdd");
            $state.go("ProjectAdd", { ID: ID });

        }


        //requestService.lists($scope.Owner).then(function (data) {
        //    //alert(data.Name);
        //    //if (data._code === 200) {
        //    $scope.projects = data;
        //    //alert($scope.projects.length);
        //    //alert($scope.projects[0].Id);
        //    //};
        //});


    });