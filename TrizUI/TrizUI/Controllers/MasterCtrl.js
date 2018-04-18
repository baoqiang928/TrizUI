angular.module("myApp")
    .controller('MasterCtrl', function ($scope, $location, requestService, $stateParams, $state, locals) {
        //监听：若收到change，把值广播出去
        $scope.$on("change", function (event, msg) {
            $scope.$broadcast("changeCurrentProject", msg);
        });
        //监听父controller的广播，得到changeFromBody广播时取$scope.value
        $scope.$on("changeCurrentProject", function (event, msg) {
            $scope.CurrentProjectName = msg;
        });
        $scope.CurrentProjectName = locals.get("ProjectName");
    });