angular.module('myApp')
    .controller('TechEvolveCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {
        $scope.TreeTypeID = "5";
        $scope.$on("nodeData", function (event, msg) {
            $scope.nodeData = msg;
        });
        $scope.TechEvolutionInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.Name = "";
            this.Character = "";
            this.Remark = "";
        }

        $scope.TechEvolutionInfoList = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get("ProjectID")
        };

        var GetTechEvolutionInfoList = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            requestService.lists("TechEvolutions", $scope.data).then(function (data) {
                $scope.TechEvolutionInfoList = data.Results;
                if ($scope.TechEvolutionInfoList.length == 0) {
                    $scope.TechEvolutionInfoList.push(new $scope.TechEvolutionInfo());
                }
            });
        }

        GetTechEvolutionInfoList();

        $scope.AddTechEvolutionInfo = function () {
            var newobj = new $scope.TechEvolutionInfo();
            $scope.TechEvolutionInfoList.push(newobj);
        }

        $scope.DeleteTechEvolutionInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("TechEvolutions", $scope.TechEvolutionInfoList[index].ID).then(function (data) { });
                    $scope.TechEvolutionInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.SaveTechEvolveInfo = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}

            for (var i = 0; i < $scope.TechEvolutionInfoList.length; i++) {
                var TechEvolutionInfo = $scope.TechEvolutionInfoList[i];
                TechEvolutionInfo.SerialNum = i;
                requestService.add("TechEvolutions", TechEvolutionInfo).then(function (data) {
                    if (TechEvolutionInfo.ID == "") {
                        TechEvolutionInfo.ID = data;
                    }
                });
            }
            alert('保存成功。');
        };

        $scope.SetRador = function (TechEvolutionInfo) {
            $state.go("TechEvolveOpe", { TechEvolveID: TechEvolutionInfo.ID, TreeTypeID: $stateParams.TreeTypeID, Name: TechEvolutionInfo.Name, Character: TechEvolutionInfo.Character, Remark: TechEvolutionInfo.Remark, PrincipleIDs: TechEvolutionInfo.PrincipleIDs });
        };

        

    });//End