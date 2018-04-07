angular.module('myApp')
    .controller('ConflictResolveOpeCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {

        $scope.ImproveCharacter = $stateParams.ImproveCharacter;
        $scope.DeteriorateCharacter = $stateParams.DeteriorateCharacter;
        console.log("$stateParams", $stateParams);
        $scope.ConflictResolveInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ConflictType = $stateParams.ConflictType;
            this.ConflictID = $stateParams.ConflictID;
            this.ForwardCharacter = $stateParams.ImproveCharacter;
            this.BackwardCharacter = $stateParams.DeteriorateCharacter;
            this.DevidePrincipleID = "";
            this.DevidePrincipleName = "";
            this.InventivePrincipleID = "";
            this.InventivePrincipleName = "";
            this.CaseID = "";
            this.CaseName = "";
        }
        //$state.go("PhyConflictResolveOpe", { ConflictID: ConflictID, ConflictType: "物理", TreeTypeID: "2", ImproveCharacter: ImproveCharacter, DeteriorateCharacter: DeteriorateCharacter });

        $scope.ConflictResolveInfoList = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get("ProjectID")
        };

        var GetConflictResolveInfoList = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            requestService.lists("ConflictResolves", $scope.data).then(function (data) {
                $scope.ConflictResolveInfoList = data.Results;
                //if ($scope.ConflictResolveInfoList.length == 0) {
                //    $scope.ConflictResolveInfoList.push(new $scope.ConflictResolveInfo());
                //}
            });
        }

        GetConflictResolveInfoList();

        $scope.AddConflictResolveInfo = function () {
            var newobj = new $scope.ConflictResolveInfo();
            newobj.CaseID = $scope.nodeData.ID;
            newobj.CaseName = $scope.nodeData.Name;
            $scope.ConflictResolveInfoList.push(newobj);
        }

        $scope.DeleteConflictResolveInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("ConflictResolves", $scope.ConflictResolveInfoList[index].ID).then(function (data) { });
                    $scope.ConflictResolveInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.SaveConflictResolveInfo = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}

            for (var i = 0; i < $scope.ConflictResolveInfoList.length; i++) {
                var ConflictResolveInfo = $scope.ConflictResolveInfoList[i];
                ConflictResolveInfo.SerialNum = i;
                requestService.add("ConflictResolves", ConflictResolveInfo).then(function (data) {
                    if (ConflictResolveInfo.ID == "") {
                        ConflictResolveInfo.ID = data;
                    }
                });
            }
            alert("保存成功。");
        };

        $scope.$on("nodeData", function (event, msg) {
            $scope.nodeData = msg;
        });
    });