angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService, $state) {
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
        }

        $scope.Delete = function (ID) {
            requestService.delete(Sources, ID).then(function (data) {
                GetProjects();
            });
        }

        $scope.BatchDelete = function () {
            var ids = "";
            $('input[name="ck"]:checked').each(function () {
                ids = $(this).val() + "^" + ids;
            });

            if (ids == "") {
                Alert("请选择记录。");
                return;
            }
            bootbox.confirm("要删除选中的所有记录？", function (result) {
                if (result) {
                    requestService.batchdelete(Sources, ids).then(function (data) {
                        GetProjects();
                        $scope.one = false;
                        $scope.all = false;
                    });
                }
            });


        }


        $scope.Update = function (ID) {
            $state.go("ProjectAdd", { ID: ID });
        }




    });//end

