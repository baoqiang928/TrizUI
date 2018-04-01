angular.module('myApp')
    .controller('StandardSolutionAndExamplesCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        //获得所有节点，左侧树使用
        $scope.TreeData = [];
        var GetTreeNodes = function () {
            $scope.QueryData = {
                ProjectID: ""
            };
            $scope.QueryData.ProjectID = $scope.CurrentProjectID;
            requestService.lists("FunctionElements", $scope.QueryData).then(function (data) {
                $scope.TreeData = strToJson(data.json);

            });
        };
        GetTreeNodes();
        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }

        $scope.CurrentNode = "";
        $scope.CurrentOperate = "";
        $scope.newSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            $scope.EleName = "";
            $scope.CurrentOperate = "Add";
            $('#modal-table').modal('show');
            return;
        };

    });//end