angular.module('myApp')
    .controller('StandardSolutionAndExamplesCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        
        //var editor = new UE.getEditor('myeditor');
        //editor.ready(function () {
        //    alert(1);
        //    //setTimeout(function () {
        //    //    console.log(editor.destroy);
        //    //    editor.destroy();
        //    //    editor = new UE.getEditor('test');
        //    //}, 500);
        //});
        //$scope._simpleConfig = {
        //    //这里可以选择自己需要的工具按钮名称,此处仅选择如下五个
        //    toolbars: [
        //      ['FullScreen', 'Source', 'Undo', 'Redo', 'Bold', 'test']
        //    ],
        //    //focus时自动清空初始化时的内容
        //    autoClearinitialContent: true,
        //    //关闭字数统计
        //    wordCount: false,
        //    //关闭elementPath
        //    elementPathEnabled: false
        //};
        $scope._simpleConfig = {
            //初始化编辑器内容  
            content : '<p>test1</p>',  
            //是否聚焦 focus默认为false  
            focus : true,  
            //首行缩进距离,默认是2em  
            indentValue:'2em',  
            //初始化编辑器宽度,默认1000  
            initialFrameWidth:1000,  
            //初始化编辑器高度,默认320  
            initialFrameHeight:520,  
            //编辑器初始化结束后,编辑区域是否是只读的，默认是false  
            readonly : false ,  
            //启用自动保存  
            enableAutoSave: false,  
            //自动保存间隔时间， 单位ms  
            saveInterval: 500,  
            //是否开启初始化时即全屏，默认关闭  
            fullscreen : false,  
            //图片操作的浮层开关，默认打开  
            imagePopup:true,       
            //提交到后台的数据是否包含整个html字符串  
            allHtmlEnabled:false,  
            //额外功能添加                 
            functions: ['map', 'insertimage', 'insertvideo', 'attachment',
            ,'insertcode','webapp','template',  
            'background','wordimage']       
            };  

        //获得所有节点，左侧树使用
        $scope.TreeData = [];
        var GetTreeNodes = function () {
            $scope.QueryData = {
                ProjectID: "",
                TypeID: ""
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
            //if ($scope.CurrentOperate == "Update") {
            //    ExampleInfo.ID = nodeData.id;
            //    //requestService.update("FunctionElements", ExampleInfo).then(function (data) {
            //    nodeData.title = $scope.ExampleName;
            //    //    alert("保存成功。");
            //    //});
            //}
            $('#modal-table').modal('hide');
        };
        //新增一个节点的保存事件  --end
        $scope.nodeData = "";
        $scope.UpdateSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            //$scope.nodeData = CurrentNode.$modelValue;
            requestService.getobj("StandardSolutionExamples", $scope.CurrentNode.$modelValue.ID).then(function (data) {
                console.log("data", data);
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
                    requestService.delete("StandardSolutionExamples", scope.$modelValue.ID).then(function (data) {
                        Alert("删除成功。");
                        scope.$parentNodesScope.removeNode(scope);
                    });
                }
            });
        };


        $scope.SaveExampleInfo = function () {
            //alert(1);
            //$scope.$apply();
            //$scope.TreeData[0].Name = "1111";
            var nodeData = $scope.CurrentNode.$modelValue;
            nodeData.Name = "455667";
        }


    });//end