angular.module('myApp')
    .controller('TechConflictResolveOpeCtrl', function ($scope, $location, requestService, $state, locals, $stateParams) {
        $scope._simpleConfig = {
            //初始化编辑器内容  
            content: '<p>test1</p>',
            //是否聚焦 focus默认为false  
            focus: true,
            //首行缩进距离,默认是2em  
            indentValue: '2em',
            //初始化编辑器宽度,默认1000  
            initialFrameWidth: '100%',
            //初始化编辑器高度,默认320  
            initialFrameHeight: 520,
            //编辑器初始化结束后,编辑区域是否是只读的，默认是false  
            readonly: false,
            //启用自动保存  
            enableAutoSave: false,
            //自动保存间隔时间， 单位ms  
            saveInterval: 500,
            //是否开启初始化时即全屏，默认关闭  
            fullscreen: false,
            //图片操作的浮层开关，默认打开  
            imagePopup: true,
            //提交到后台的数据是否包含整个html字符串  
            allHtmlEnabled: false,
            //额外功能添加                 
            functions: ['map', 'insertimage', 'insertvideo', 'attachment',
            , 'insertcode', 'webapp', 'template',
            'background', 'wordimage']
        };
        $scope.ImproveCharacter = $stateParams.ImproveCharacter;
        $scope.DeteriorateCharacter = $stateParams.DeteriorateCharacter;
        $scope.FatherIDs = $stateParams.FatherIDs;
        $scope.TreeTypeID = "1";
        $scope.nodeData = {};
        $scope.ConflictResolveInfo = function () {
            this.ID = "";
            this.ProjectID = locals.get("ProjectID");
            this.SerialNum = "";
            this.ConflictType = $stateParams.ConflictType;
            this.ConflictID = $stateParams.ConflictID;
            this.ForwardCharacter = $stateParams.ImproveCharacter;
            this.BackwardCharacter = $stateParams.DeteriorateCharacter;
            this.DevidePrincipleID = "";
            this.DevidePrincipleName = "";
            this.InventivePrincipleID = "";
            this.InventivePrincipleName = "";
            this.CaseID = "";
            this.CaseName = "";
        }
        //$state.go("PhyConflictResolveOpe", { ConflictID: ConflictID, ConflictType: "物理", TreeTypeID: "2", ImproveCharacter: ImproveCharacter, DeteriorateCharacter: DeteriorateCharacter });

        $scope.ConflictResolveInfoList = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get("ProjectID"),
            ConflictType: "技术",
            ConflictID: $stateParams.ConflictID
        };

        var GetConflictResolveInfoList = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = "999";
            console.log("$scope.data111", $scope.data);
            requestService.lists("ConflictResolves", $scope.data).then(function (data) {
                $scope.ConflictResolveInfoList = data.Results;
            });
        }

        GetConflictResolveInfoList();

        $scope.AddConflictResolveInfo = function (nodeData) {
            var newobj = new $scope.ConflictResolveInfo();
            console.log("nodeData", nodeData);
            newobj.CaseID = nodeData.ID;
            newobj.CaseName = nodeData.Name;
            var query = {
                SonID: newobj.CaseID,
                OpeType: "GetFatherID"
            }
            requestService.lists("DictionaryBigTrees", query).then(function (data) {
                newobj.InventivePrincipleID = data.ID;
                newobj.InventivePrincipleName = data.Name;
                $scope.ConflictResolveInfoList.push(newobj);
            });

        }
        $scope.Solution = "";
        $scope.CurrentIndex = "";

        $scope.EditConflictResolveInfo = function (Solution, index) {
            $scope.Solution = Solution;
            $scope.CurrentIndex = index;
            $('#modal-table').modal('show');
            return;
        };
        $scope.DeleteConflictResolveInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("ConflictResolves", $scope.ConflictResolveInfoList[index].ID).then(function (data) { });
                    $scope.ConflictResolveInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.SaveConflictResolveInfo = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}

            for (var i = 0; i < $scope.ConflictResolveInfoList.length; i++) {
                var ConflictResolveInfo = $scope.ConflictResolveInfoList[i];
                ConflictResolveInfo.SerialNum = i;
                requestService.add("ConflictResolves", ConflictResolveInfo).then(function (data) {
                    if (ConflictResolveInfo.ID == "") {
                        ConflictResolveInfo.ID = data;
                    }
                });
            }
            alert("保存成功。");
        };

        $scope.$on("nodeData", function (event, msg) {
            $scope.nodeData = msg;
        });

        $scope.SaveToList = function () {
            UE.getEditor('idTest').setContent(' ', true);
            $scope.ConflictResolveInfoList[$scope.CurrentIndex].Remark = $scope.Solution;
            console.log("$scope.ConflictResolveInfoList", $scope.ConflictResolveInfoList);
            $scope.Solution = "";
            $('#modal-table').modal('hide');
        };
    });