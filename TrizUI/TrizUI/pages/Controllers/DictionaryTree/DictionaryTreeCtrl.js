angular.module('myApp')
    .controller('DictionaryTreeCtrl', function ($scope, $rootScope, $location, requestService, $state, locals, $stateParams) {
        $scope.CurrentProjectID = "0";//$scope.CurrentProjectID;
        $scope.PageTitle = $stateParams.Title;
        //获得所有节点，左侧树使用
        $scope.TreeData = [];
        var GetTreeNodes = function () {
            $scope.QueryData = {
                ProjectID: $scope.CurrentProjectID,
                TreeTypeID: $stateParams.TreeTypeID
            };
            requestService.lists("DictionaryTrees", $scope.QueryData).then(function (data) {
                $scope.TreeData = strToJson(data.json);
                //console.log("$scope.nodeData", $scope.TreeData);
            });
        };
        GetTreeNodes();
        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }

        //$scope.DictionaryTreeInfo = function () {
        //    this.ID = "";
        //    this.ProjectID = "";
        //    this.TreeTypeID = "";
        //    this.SerialNum = "";
        //    this.Name = "";
        //    this.Type = "";
        //    this.Note = "";
        //    this.Remark = "";
        //    this.FatherID = "";
        //    this.CreateDateTime = "";
        //}

        function AddRootNode(title, Name) {
            var tmpnode = {
                id: GenRdmID(5),
                title: title,
                ProjectID: $scope.CurrentProjectID,
                TreeTypeID: $stateParams.TreeTypeID,
                ID: "",
                Name: Name,
                nodes: []
            };
            $scope.TreeData.push(tmpnode);
            requestService.add("DictionaryTrees", tmpnode).then(function (data) {
                tmpnode.id = data;
                tmpnode.ID = data;
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
        //浏览节点，冲突解决界面需要
        $scope.View = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            requestService.getobj("DictionaryTrees", $scope.CurrentNode.$modelValue.ID).then(function (data) {
                $scope.$emit("nodeData", data);
            });
        };
        //新增一个节点的保存事件
        $scope.Name = "";
        $scope.SaveName = function () {
            var nodeobj = {};
            nodeobj.ProjectID = $scope.CurrentProjectID;
            nodeobj.Name = $scope.Name;
            nodeobj.TreeTypeID = $stateParams.TreeTypeID;
            if ($scope.CurrentNode == "Root") {
                AddRootNode($scope.Name, $scope.Name);
                $('#modal-table').modal('hide');
                return;
            }
            var nodeData = $scope.CurrentNode.$modelValue;
            //add
            if ($scope.CurrentOperate == "Add") {
                nodeobj.FatherID = nodeData.id;
                requestService.add("DictionaryTrees", nodeobj).then(function (data) {
                    console.log("data", data);
                    nodeData.nodes.push({
                        id: data,
                        ID: data,
                        title: $scope.Name,
                        Name: $scope.Name,
                        Remark: "",
                        ProjectID: $scope.CurrentProjectID,
                        TreeTypeID: $stateParams.TreeTypeID,
                        FatherID: nodeData.id,
                        nodes: []
                    });
                    alert("保存成功。");
                });
            }
            $('#modal-table').modal('hide');
        };
        //新增一个节点的保存事件  --end
        $scope.nodeData = "";
        $scope.UpdateSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            requestService.getobj("DictionaryTrees", $scope.CurrentNode.$modelValue.ID).then(function (data) {
                $scope.nodeData = data;

            });
        };

        $scope.DeleteSubItem = function (scope) {
            bootbox.confirm("要删除当前的记录: " + scope.$modelValue.title + " ？", function (result) {
                if (result) {
                    if (scope.$modelValue.nodes.length > 0) {
                        alert("存在子节点不能删除。");
                        return false;
                    }
                    requestService.delete("DictionaryTrees", scope.$modelValue.ID).then(function (data) {
                        Alert("删除成功。");
                        scope.$parentNodesScope.removeNode(scope);
                    });
                }
            });
        };


    });//end