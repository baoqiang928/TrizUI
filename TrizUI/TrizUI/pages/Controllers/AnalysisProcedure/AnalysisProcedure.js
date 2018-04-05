angular.module("myApp")
    .controller('AnalysisProcedureCtrl', function ($scope, $location, requestService, $state, locals) {
        var Sources = "AnalysisProcedures";
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
            ProjectID: locals.get("ProjectID")
        };
        $scope.AnalysisProcedures = [];
        $scope.AnalysisProcedureInfo = function () {
            ProjectID: locals.get("ProjectID");
            ProcedureID: "";
            Type: "";
            ShortDescription: "";
            Cases: "";
            Valid: "";
        }
        var GetAnalysisProcedures = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.AnalysisProcedures = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetAnalysisProcedures);

        $scope.Query = function () {
            GetAnalysisProcedures();
        }

        $scope.Delete = function (ProcedureID) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete(Sources, ProcedureID).then(function (data) {
                        GetAnalysisProcedures();
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
                        GetAnalysisProcedures();
                        $scope.one = false;
                        $scope.all = false;
                    });
                }
            });

        }

        $scope.Update = function (ID) {
            $state.go("AnalysisProcedureAdd", { ID: ID });
        }

    });//end


