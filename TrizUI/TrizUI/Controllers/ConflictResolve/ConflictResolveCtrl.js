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
            $scope.$broadcast("AddTechnicalConflictInfo", FatherTechnicalConflictInfo);
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