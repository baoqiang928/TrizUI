angular.module("myApp")
    .controller('UserCtrl', function ($scope, $location, requestService, $state) {
        var Sources = "Users";
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
            Mobile: "",
            Email: "",
            Account: ""
        };

        var GetUsers = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.Users = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetUsers);

        $scope.Query = function () {
            GetUsers();
        }

        $scope.Delete = function (ID) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                requestService.delete(Sources, ID).then(function (data) {
                    GetUsers();
                });
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
                        GetUsers();
                        $scope.one = false;
                        $scope.all = false;
                    });
                }
            });

        }

        $scope.Update = function (ID) {
            $state.go("UserAdd", { ID: ID });
        }

    });//end



