angular.module('myApp')
    .controller('DictionaryBigTreeCtrl', function ($scope, $rootScope, $location, requestService, $state, locals, $stateParams) {
        $scope.CurrentProjectID = $stateParams.CurrentProjectID;
        if ($stateParams.CurrentProjectID == "")
            $scope.CurrentProjectID = locals.get("ProjectID");


        $scope.PageTitle = $stateParams.Title;

        var setting = {
            async: {
                enable: true,
                url: getUrl
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
                enable: true
            },
            data: {
                simpleData: {
                    enable: true
                }
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

        var zNodes = [
			{ name: "500个节点", id: "1", count: 500, times: 1, isParent: true },
			{ name: "1000个节点", id: "2", count: 1000, times: 1, isParent: true },
			{ name: "2000个节点", id: "3", count: 2000, times: 1, isParent: true }
        ];

        var log, className = "dark",
		startTime = 0, endTime = 0, perCount = 100, perTime = 100;
        function getUrl(treeId, treeNode) {
            //var curCount = (treeNode.children) ? treeNode.children.length : 0;
            //var getCount = (curCount + perCount) > treeNode.count ? (treeNode.count - curCount) : perCount;
            //var param = "id=" + treeNode.id + "_" + (treeNode.times++) + "&count=" + getCount;
            //return "../asyncData/getNodesForBigData.php?" + param;
            return "http://localhost:2072/api/DictionaryBigTrees?OpeType=GetFatherNodes&ProjectID=0&TreeTypeID=2";
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
            requestService.getobj("DictionaryTrees", treeNode.id).then(function (data) {
                $scope.nodeData = data;
                //$scope.SelectedNodeName = data.Name;
            });

        }
        function beforeRemove(treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            zTree.selectNode(treeNode);
            return confirm("确认删除 节点 -- " + treeNode.name + " 吗？");
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
        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
            var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
				+ "' title='add node' onfocus='this.blur();'></span>";
            sObj.after(addStr);
            var btn = $("#addBtn_" + treeNode.tId);
            if (btn) btn.bind("click", function () {
                var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                zTree.addNodes(treeNode, { id: (100 + newCount), pId: treeNode.id, name: "new node" + (newCount++) });
                return false;
            });
        };
        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_" + treeNode.tId).unbind().remove();
        };


        $.fn.zTree.init($("#treeDemo"), setting, zNodes);

        $scope.newSubItem = function () {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            var nodes = zTree.getSelectedNodes();
            console.log("nodes", nodes);
            for (var i = 0, l = nodes.length; i < l; i++) {
                nodes[i].name = "4444433333222111";
                zTree.updateNode(nodes[i]);
            }
        };

    });//end