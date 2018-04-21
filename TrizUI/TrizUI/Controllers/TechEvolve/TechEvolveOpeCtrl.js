angular.module('myApp')
    .controller('TechEvolveOpeCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {
        console.log("$stateParams11111111111", $stateParams);
        $scope.Name = $stateParams.Name;
        $scope.Character = $stateParams.Character;
        $scope.Remark = $stateParams.Remark;


        $scope.$on("nodeData", function (event, msg) {
            $scope.nodeData = msg;
        });


        

    });//End