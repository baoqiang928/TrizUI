angular.module("myApp")
    .controller('StandardSolutionCtrl', function ($scope, $location, requestService, $state, locals) {
        var Sources = "StandardSolutions";
        $scope.CurrentProjectID = locals.get("ProjectID");
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
            ProjectID: $scope.CurrentProjectID,
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

        //树
        $scope.TreeData = [];
        $scope.QueryData = {
            ProjectID: $scope.CurrentProjectID,
            TypeID: ""
        };
        var GetTreeNodes = function () {
            requestService.lists("StandardSolutionExamples", $scope.QueryData).then(function (data) {
                $scope.TreeData = strToJson(data.json);
            });
        };
        GetTreeNodes();
        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }
        $scope.ClearTypeID = function () {
            $scope.data.TypeID = "";
            $scope.TypeName = "";
        };
        $scope.data.TypeID = "";
        $scope.TypeName = "";
        $scope.SelectItem = function (CurrentNode) {
            $scope.data.TypeID = CurrentNode.$modelValue.ID;
            $scope.TypeName = CurrentNode.$modelValue.title;
            $('#modal-table').modal('hide');
        };
        $scope.SelectType = function () {
            $('#modal-table').modal('show');
        };
        //树 end
    });//end



