angular.module('myApp')
    .controller('PhysicalConflictCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.PhysicalConflictInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ForwardCharacter = "";
            this.BackwardCharacter = "";
            this.CommonRelevantParams = "";
        }

        $scope.PhysicalConflictInfoList = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get("ProjectID")
        };

        var GetPhysicalConflictInfoList = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            requestService.lists("PhysicalConflicts", $scope.data).then(function (data) {
                $scope.PhysicalConflictInfoList = data.Results;
                if ($scope.PhysicalConflictInfoList.length == 0) {
                    $scope.PhysicalConflictInfoList.push(new $scope.PhysicalConflictInfo());
                }
            });
        }

        GetPhysicalConflictInfoList();

        //$scope.AddPhysicalConflictInfo = function () {
        //    var newobj = new $scope.PhysicalConflictInfo();
        //    $scope.PhysicalConflictInfoList.push(newobj);
        //}
        $scope.$on("AddPhysicalConflictInfo", function (event, msg) {
            $scope.PhysicalConflictInfoList = [];
            $scope.PhysicalConflictInfoList.push(msg);
        });
        $scope.DeletePhysicalConflictInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("PhysicalConflicts", $scope.PhysicalConflictInfoList[index].ID).then(function (data) { });
                    $scope.PhysicalConflictInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.Deal = function (ConflictID, ImproveCharacter, DeteriorateCharacter) {
            $state.go("PhyConflictResolveOpe", { ConflictID: ConflictID, ConflictType: "物理", TreeTypeID: "2", ImproveCharacter: ImproveCharacter, DeteriorateCharacter: DeteriorateCharacter });
        }
        $scope.SavePhysicalConflict = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}

            for (var i = 0; i < $scope.PhysicalConflictInfoList.length; i++) {
                var PhysicalConflictInfo = $scope.PhysicalConflictInfoList[i];
                PhysicalConflictInfo.SerialNum = i;
                console.log("PhysicalConflictInfo", PhysicalConflictInfo);
                requestService.add("PhysicalConflicts", PhysicalConflictInfo).then(function (data) {
                    if (PhysicalConflictInfo.ID == "") {
                        PhysicalConflictInfo.ID = data;
                    }
                });
            }
            alert("保存成功。");
        };


    });//End