angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.submitTime = ""
        //存
        locals.set("UserID", "1");//字符串
        //locals.setObject("secondpos", secondpos);//对象
        $scope.CurrentProjectID = locals.get("ProjectID");

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
            Code: "",
            Code123: "",
            Name: "",
            Owner: "",
            Department: "",
            FromDateTime:"",
            submitTime: "",
            ToDateTime:""
        };

        $scope.UserProjectData = {
            UserID: "",
            ProjectID: ""
        };

        var GetProjects = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.Projects = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetProjects);

        $scope.Query = function () {
            GetProjects();
        }

        $scope.Delete = function (ID) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete(Sources, ID).then(function (data) {
                        GetProjects();
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

        $scope.SetCurrent = function (ProjectID, ProjectName) {
            $scope.UserProjectData.ProjectID = ProjectID;
            $scope.UserProjectData.UserID = locals.get("UserID");
            requestService.add("UserProjects", $scope.UserProjectData).then(function (aaa) {
                alert('设置成功。');
                locals.set("ProjectID", ProjectID);
                locals.set("ProjectName", ProjectName);
                $scope.CurrentProjectID = ProjectID;
                $scope.$emit("change", ProjectName);
            });
        }
    });//end

