angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService) {

        $scope.Query = function () {
            alert('Query');
            //$location.path("/AddProject");
        }
        $scope.Save = function () {
            alert($scope.Owner);
            //$location.path("/AddProject");
        }

        $scope.Owner = "2"
        requestService.lists($scope.Owner).then(function (data) {
            //alert(data.Name);
            //if (data._code === 200) {
            $scope.projects = data;
            //alert($scope.projects.length);
            //alert($scope.projects[0].Id);
            //};
        });





    });