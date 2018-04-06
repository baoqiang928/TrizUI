angular.module('myApp')
    .controller('TechnicalConflictCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.TechnicalConflictInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ImproveCharacter = "";
            this.DeteriorateCharacter = "";
        }

        $scope.TechnicalConflictInfoList = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get("ProjectID")
        };

        var GetTechnicalConflictInfoList = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            requestService.lists("TechnicalConflicts", $scope.data).then(function (data) {
                $scope.TechnicalConflictInfoList = data.Results;
                if ($scope.TechnicalConflictInfoList.length == 0) {
                    $scope.TechnicalConflictInfoList.push(new $scope.TechnicalConflictInfo());
                    console.log("$scope.TechnicalConflictInfoList", $scope.TechnicalConflictInfoList);
                }
            });
        }

        GetTechnicalConflictInfoList();

        $scope.AddTechnicalConflictInfo = function () {
            $scope.TechnicalConflictInfoList.push(new $scope.TechnicalConflictInfo());
        }

        $scope.DeleteTechnicalConflictInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("TechnicalConflicts", $scope.TechnicalConflictInfoList[index].ID).then(function (data) { });
                    $scope.TechnicalConflictInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.SaveTechnicalConflictInfo = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}
            for (var i = 0; i < $scope.TechnicalConflictInfoList.length; i++) {
                var TechnicalConflictInfo = $scope.TechnicalConflictInfoList[i];
                console.log("TechnicalConflictInfo", TechnicalConflictInfo);
                TechnicalConflictInfo.SerialNum = i;
                requestService.add("TechnicalConflicts", TechnicalConflictInfo).then(function (data) {
                    if (TechnicalConflictInfo.ID == "") {
                        TechnicalConflictInfo.ID = data;
                    }
                });
            }
            alert('保存成功');
        };

    });