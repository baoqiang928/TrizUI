angular.module("myApp")
    .controller('MaterialFieldModelCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.Sources = "MaterialFieldModels";
        $scope.MaterialFieldModelInfo = function () {
            ID: "";
            ProjectID: locals.get("ProjectID");
            SerialNum: "";
            FunctionSubject: "";
            FunctionObject: "";
            RelationType: "";
            FieldName: "";
            FieldType: "";
            Symbol: "";
            Remark: "";            
        }

        $scope.MaterialFieldModelInfoList = [];
        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: ""
        };

        var GetMaterialFieldModels = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            requestService.lists($scope.Sources, $scope.data).then(function (data) {
                $scope.MaterialFieldModelInfoList = data.Results;
                console.log("$scope.MaterialFieldModelInfoList", $scope.MaterialFieldModelInfoList);
            });
        }
        GetMaterialFieldModels();
        //var newobj = new $scope.MaterialFieldModelInfo();
        //$scope.MaterialFieldModelInfoList.push(newobj);

        $scope.AddMaterialFieldModelInfo = function () {
            var newobj = new $scope.MaterialFieldModelInfo();
            $scope.MaterialFieldModelInfoList.push(newobj);
        }

        $scope.DeleteMaterialFieldModelInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete($scope.Sources, $scope.MaterialFieldModelInfoList[index].ID).then(function (data) { });
                    $scope.MaterialFieldModelInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }

        $scope.Save = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}
            for (var i = 0; i < $scope.MaterialFieldModelInfoList.length; i++) {
                var MaterialFieldModelInfo = $scope.MaterialFieldModelInfoList[i];
                MaterialFieldModelInfo.SerialNum = i;
                requestService.add($scope.Sources, MaterialFieldModelInfo).then(function (data) {
                    if (MaterialFieldModelInfo.ID == "") {
                        MaterialFieldModelInfo.ID = data;
                    }
                });
            }
        };

        //监听"ShareObjectEvent"事件
        $scope.$on("ShareObjectEvent", function (event, args) {
            $scope.Save();
        });

        $scope.RefreshMap = function () {
            $scope.$emit("RefreshMap", $scope.MaterialFieldModelInfoList);
        };




    });