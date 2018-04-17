angular.module('myApp')
    .controller('DictionaryBigTreeCtrl', function ($scope, $rootScope, $location, requestService, $state, locals, $stateParams) {
        $scope.CurrentProjectID = $stateParams.CurrentProjectID;
        if ($stateParams.CurrentProjectID == "")
            $scope.CurrentProjectID = locals.get("ProjectID");


        $scope.PageTitle = $stateParams.Title;


        var iniTree = function () {
            $scope.data = {
                ProjectID: $scope.CurrentProjectID,
                TreeTypeID: $stateParams.TreeTypeID,
                OpeType: "GetFathers"
            };
            requestService.lists("DictionaryBigTreesView", $scope.data).then(function (data) {
                var zNodes = data;
                console.log("zNodes", zNodes);
                var setting = {
                    async: {
                        enable: true,
                        url: "http://localhost:2072/api/DictionaryBigTreesView/",
                        autoParam: ["id=NodeID", "name=NodeName", "level=TreeLevel"],
                        otherParam: { "ProjectID": $scope.CurrentProjectID, "TreeTypeID": $stateParams.TreeTypeID, "OpeType": "View" }
                    },
                    check: {
                        enable: false
                    },
                    data: {
                        simpleData: {
                            enable: true
                        }
                    },
                    view: {
                        expandSpeed: "",
                        addHoverDom: addHoverDom,
                        removeHoverDom: removeHoverDom,
                        selectedMulti: false
                    },
                    edit: {
                        enable: true,
                        showRenameBtn: false,
                        showRemoveBtn: showRemoveBtn,
                    },
                    callback: {
                        beforeExpand: beforeExpand,
                        onAsyncSuccess: onAsyncSuccess,
                        onAsyncError: onAsyncError,
                        beforeRemove: beforeRemove,
                        beforeRename: beforeRename,
                        onClick: onClick
                    }
                };
                $.fn.zTree.init($("#treeDemo"), setting, zNodes);

            });
        }

        iniTree();

        var log, className = "dark",
		startTime = 0, endTime = 0, perCount = 100, perTime = 100;

        function showRemoveBtn(treeId, treeNode) {
            return !treeNode.isParent;
        }
        function beforeExpand(treeId, treeNode) {
            //if (!treeNode.isAjaxing) {
            //    startTime = new Date();
            //    treeNode.times = 1;
            //    ajaxGetNodes(treeNode, "refresh");
            //    return true;
            //} else {
            //    alert("zTree 正在下载数据中，请稍后展开节点。。。");
            //    return false;
            //}
        }
        function onAsyncSuccess(event, treeId, treeNode, msg) {
            //if (!msg || msg.length == 0) {
            //    return;
            //}
            //var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
            //totalCount = treeNode.count;
            //if (treeNode.children.length < totalCount) {
            //    setTimeout(function () { ajaxGetNodes(treeNode); }, perTime);
            //} else {
            //    treeNode.icon = "";
            //    zTree.updateNode(treeNode);
            //    zTree.selectNode(treeNode.children[0]);
            //    endTime = new Date();
            //    var usedTime = (endTime.getTime() - startTime.getTime()) / 1000;
            //    className = (className === "dark" ? "" : "dark");
            //    showLog("[ " + getTime() + " ]&nbsp;&nbsp;treeNode:" + treeNode.name);
            //    showLog("加载完毕，共进行 " + (treeNode.times - 1) + " 次异步加载, 耗时：" + usedTime + " 秒");
            //}
        }
        function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            alert("异步获取数据出现异常。");
            treeNode.icon = "";
            zTree.updateNode(treeNode);
        }
        function ajaxGetNodes(treeNode, reloadType) {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            if (reloadType == "refresh") {
                treeNode.icon = "../../../css/zTreeStyle/img/loading.gif";
                zTree.updateNode(treeNode);
            }
            zTree.reAsyncChildNodes(treeNode, reloadType, true);
        }
        //function showLog(str) {
        //    if (!log) log = $("#log");
        //    log.append("<li class='" + className + "'>" + str + "</li>");
        //    if (log.children("li").length > 4) {
        //        log.get(0).removeChild(log.children("li")[0]);
        //    }
        //}
        //function getTime() {
        //    var now = new Date(),
        //	h = now.getHours(),
        //	m = now.getMinutes(),
        //	s = now.getSeconds(),
        //	ms = now.getMilliseconds();
        //    return (h + ":" + m + ":" + s + " " + ms);
        //}
        $scope.nodeData = function () {
            this.ID = "";
            this.Name = "";
            this.Note = "";
            this.Remark = "";
        };
        function onClick(event, treeId, treeNode, clickFlag) {
            //showLog("[ " + getTime() + " onClick ]&nbsp;&nbsp;clickFlag = " + clickFlag + " (" + (clickFlag === 1 ? "普通选中" : (clickFlag === 0 ? "<b>取消选中</b>" : "<b>追加选中</b>")) + ")");
            //console.log("treeNode", treeNode);
            $scope.CurrentNode = treeNode;
            requestService.getobj("DictionaryTrees", treeNode.id).then(function (data) {
                $scope.nodeData = data;
                //$scope.SelectedNodeName = data.Name;
            });

        }
        function beforeRemove(treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            zTree.selectNode(treeNode);
            if (confirm("确认删除 节点 -- " + treeNode.name + " 吗？")) {
                requestService.delete("DictionaryTrees", treeNode.id).then(function (data) { });
                return true;
            }
            return false;
        }
        function beforeRename(treeId, treeNode, newName) {
            if (newName.length == 0) {
                setTimeout(function () {
                    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                    zTree.cancelEditName();
                    alert("节点名称不能为空.");
                }, 0);
                return false;
            }
            return true;
        }
        var newCount = 1;
        $scope.Name = "";
        $scope.CurrentNode = {};
        function addHoverDom(treeId, treeNode) {

            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
            var addStr = "<span class='button edit' id='addBtn_" + treeNode.tId
				+ "' title='add node' onfocus='this.blur();'></span>";
            sObj.after(addStr);
            var btn = $("#addBtn_" + treeNode.tId);
            if (btn) btn.bind("click", function () {
                $scope.CurrentNode = treeNode;
                $scope.CurrentOperate = "Add";
                $('#modal-table').modal('show');
                //var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                //zTree.addNodes(treeNode, { id: (100 + newCount), pId: treeNode.id, name: "new node" + (newCount++) });
                return false;
            });
        };

        $scope.SaveTreeNode = function () {
            if ($scope.CurrentOperate == "Add") {
                var NodeInfo = {};
                NodeInfo.ProjectID = $scope.CurrentProjectID;
                NodeInfo.Name = $scope.Name;
                NodeInfo.FatherID = $scope.CurrentNode.id;
                NodeInfo.TreeTypeID = $stateParams.TreeTypeID;
                console.log("NodeInfo", NodeInfo);
                requestService.add("DictionaryTrees", NodeInfo).then(function (data) {
                    var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                    zTree.addNodes($scope.CurrentNode, { id: data, pId: $scope.CurrentNode.id, name: $scope.Name });
                    alert("保存成功。");
                });
            }

        };

        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_" + treeNode.tId).unbind().remove();
        };

        $scope.newSubItem = function () {

            //var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            //var nodes = zTree.getSelectedNodes();
            //console.log("nodes", nodes);
            //for (var i = 0, l = nodes.length; i < l; i++) {
            //    nodes[i].name = "4444433333222111";
            //    zTree.updateNode(nodes[i]);
            //}
        };


        $scope.UpdateCurrentNodeName = function () {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            $scope.CurrentNode.name = $scope.nodeData.Name;
            //var nodes = zTree.getSelectedNodes();
            //console.log("nodes", nodes);
            //for (var i = 0, l = nodes.length; i < l; i++) {
            //    nodes[i].name = "4444433333222111";
            zTree.updateNode($scope.CurrentNode);
            //}
            console.log("$scope.CurrentNode", $scope.CurrentNode);
        };

    });//end