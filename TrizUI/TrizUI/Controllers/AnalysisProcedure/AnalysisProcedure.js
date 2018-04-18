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
        $scope.GetName = function (RadioValue) {
            if (RadioValue == "j1c1")
                return "预测改变的潜力";
            if (RadioValue == "j1c2")
                return "系统改进";
            if (RadioValue == "j1c3")
                return "添加检测、测量功能";
        };
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
                    requestService.batchdelete(Sources, ProcedureID).then(function (data) {
                        GetAnalysisProcedures();
                    });
                }
            });
        }

        $scope.Update = function (ProcedureID) {
            $state.go("AnalysisProcedureAdd", { ProcedureID: ProcedureID, TreeTypeID: "3" });
        }

    });//end


angular.module('myApp')
    .filter('to_trusted', ['$sce', function ($sce) {
        return function (text) {
            return $sce.trustAsHtml(text);
        };
    }]);