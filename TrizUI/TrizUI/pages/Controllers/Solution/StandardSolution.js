angular.module("myApp")
    .controller('StandardSolutionCtrl', function ($scope, $location, requestService, $state) {
        var Sources = "StandardSolutions";
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
            ProjectID: "",
            Name: "",
            Note: "",
            Remark: "",
            TypeID: ""
        };

        var GetStandardSolutions = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.StandardSolutions = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetStandardSolutions);

        $scope.Query = function () {
            GetStandardSolutions();
        }

        $scope.Delete = function (ID) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete(Sources, ID).then(function (data) {
                        GetStandardSolutions();
                    });
                }
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
                        GetStandardSolutions();
                        $scope.one = false;
                        $scope.all = false;
                    });
                }
            });

        }

        $scope.Update = function (ID) {
            $state.go("SolutionADD", { ID: ID });
        }

    });//end



