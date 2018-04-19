angular.module('myApp')
    .controller('ConflictResolveCtrl', function ($scope, $location, requestService, $state, locals, ImproveCharacterDictionary) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.ImproveCharacterDictionary = ImproveCharacterDictionary;

        $scope.TechnicalConflictInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ImproveCharacter = "";
            this.DeteriorateCharacter = "";
        }
        $scope.AddTechnicalConflictInfo = function () {
            var FatherTechnicalConflictInfo = new $scope.TechnicalConflictInfo();
            FatherTechnicalConflictInfo.ImproveCharacter = $("#ImproveCharacter").val();
            FatherTechnicalConflictInfo.DeteriorateCharacter = $("#DeteriorateCharacter").val();

            //获得冲突矩阵结果 如果是空或者减号，或者加号，则提示。
            var query = {
                ImproveCharacter: FatherTechnicalConflictInfo.ImproveCharacter,
                DeteriorateCharacter: FatherTechnicalConflictInfo.DeteriorateCharacter
            };
            requestService.lists("ConflictMatrixs", query).then(function (data) {
                if ((data.Results == "") || (data.Results == "+") || (data.Results == "-")) {
                    alert('不存在对应解。请重新选择。');
                    return;
                }

                $scope.$broadcast("AddTechnicalConflictInfo", FatherTechnicalConflictInfo);
            });
        };


        $scope.PhysicalConflictInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ForwardCharacter = "";
            this.BackwardCharacter = "";
            this.CommonRelevantParams = "";
        }

        $scope.AddPhysicalConflictInfo = function () {
            $scope.$broadcast("AddPhysicalConflictInfo", $scope.PhysicalConflictInfo);
        };

    });