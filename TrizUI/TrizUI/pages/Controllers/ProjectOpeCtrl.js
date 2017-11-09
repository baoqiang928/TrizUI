angular.module("myApp")
    .controller('ProjectOpeCtrl', function ($scope, $location, requestService, $stateParams, $state) {
        var Sources = "Projects";
        $scope.data = {
            Name: "",
            Code: "",
            Owner: "",
            Department: ""
        };

        requestService.getobj(Sources, $stateParams.ID).then(function (data) {
            //alert(data.Name);
            //if (data._code === 200) {
            $scope.data = data;
            //alert($scope.projects.length);
            //alert($scope.projects[0].Id);
            //};
        });

        $scope.Save = function () {
            requestService.add(Sources, $scope.data).then(function (data) {
                //$state.go("ProjectList", {}, { reload: true, cache: false });
                $state.go("ProjectList");
            });
            //$state.go("ProjectList");
            //$scope.$apply();
        };




    });