angular.module('myApp')
    .controller('TechEvolveOpeCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {

        $scope.Name = $stateParams.Name;
        $scope.Character = $stateParams.Character;
        $scope.Remark = $stateParams.Remark;




    });//End