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
            requestService.lists("StandardSolutionExamples", $scope.QueryData).then(function (data) {
                $scope.TreeData = strToJson(data.json);
                //console.log("$scope.nodeData", $scope.TreeData);
            });
        };
        GetTreeNodes();
        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }

        function AddRootNode(title, Name) {
            var tmpnode = {
                id: GenRdmID(5),
                title: title,
                ProjectID: $scope.CurrentProjectID,
                ID: "",
                Name: Name,
                nodes: []
            };
            $scope.TreeData.push(tmpnode);
            requestService.add("StandardSolutionExamples", tmpnode).then(function (data) {
                tmpnode.id = data;
                tmpnode.ID = data;
                console.log("$scope.TreeData", $scope.TreeData);
            });
        }
        function GenRdmID(randomLength) {
            return Number(Math.random().toString().substr(3, randomLength) + Date.now()).toString(36);
        }
        //

        $scope.CurrentNode = "";
        $scope.CurrentOperate = "";
        $scope.newSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            $scope.Name = "";
            $scope.CurrentOperate = "Add";
            $('#modal-table').modal('show');
            return;
        };

        //新增一个节点的保存事件
        $scope.ExampleName = "";
        $scope.SaveExampleName = function () {
            var ExampleInfo = {};
            ExampleInfo.ProjectID = locals.get("ProjectID");
            ExampleInfo.Name = $scope.ExampleName;
            if ($scope.CurrentNode == "Root") {
                AddRootNode($scope.ExampleName, $scope.ExampleName);
                $('#modal-table').modal('hide');
                return;
            }
            var nodeData = $scope.CurrentNode.$modelValue;
            //add
            if ($scope.CurrentOperate == "Add") {
                ExampleInfo.FatherID = nodeData.id;
                requestService.add("StandardSolutionExamples", ExampleInfo).then(function (data) {
                    console.log("data", data);
                    nodeData.nodes.push({
                        id: data,
                        ID: data,
                        title: $scope.ExampleName,
                        Name: $scope.ExampleName,
                        Remark: "",
                        FatherID: nodeData.id,
                        nodes: []
                    });
                    alert("保存成功。");
                });
            }

            //update
            if ($scope.CurrentOperate == "Update") {
                ExampleInfo.ID = nodeData.id;
                //requestService.update("FunctionElements", ExampleInfo).then(function (data) {
                nodeData.title = $scope.ExampleName;
                //    alert("保存成功。");
                //});
            }
            $('#modal-table').modal('hide');
        };
        //新增一个节点的保存事件  --end

        $scope.UpdateSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            var nodeData = CurrentNode.$modelValue;
            $scope.ExampleName = nodeData.title;
            $scope.CurrentOperate = "Update";
            $('#modal-table').modal('show');
        };

        $scope.DeleteSubItem = function (scope) {
            bootbox.confirm("要删除当前的记录: " + scope.$modelValue.title + " ？", function (result) {
                if (result) {
                    if (scope.$modelValue.nodes.length > 0) {
                        alert("存在子节点不能删除。");
                        return false;
                    }
                    requestService.delete("StandardSolutionExamples", scope.$modelValue.ID).then(function (data) {
                        Alert("删除成功。");
                        scope.$parentNodesScope.removeNode(scope);
                    });
                }
            });
        };
    });//end