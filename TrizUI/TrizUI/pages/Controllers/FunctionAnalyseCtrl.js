angular.module('myApp')
    .controller('FunctionAnalyseCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.Sources = "FunEleMutualReacts";
        $scope.CurrentProjectID = locals.get("ProjectID");
        //相互作用关系维护表
        $scope.RelElementData = [];
        $scope.RelElement = {
            ID: "",
            ProjectID: "",
            PositiveEleID: "",
            PositiveEleName: "",
            FunctionName: "",
            PassiveEleID: "",
            PassiveEleName: "",
            FunctionType: "",
            FunctionGrade: "",
            ElementType: "",
            CreateDateTime: ""
        };
        $scope.FunctionTypes = [{ id: 1, name: '基本功能' }, { id: 2, name: '附加功能' }, { id: 3, name: '辅助功能' }, { id: 4, name: '有害功能' }];
        $scope.FunctionGrades = [{ id: 1, name: '正常功能' }, { id: 2, name: '不足功能' }, { id: 3, name: '过剩功能' }, { id: 4, name: '有害功能' }];

        //相互作用表维护
        $scope.SaveRelOperate = function () {
            //alert(JSON.stringify($scope.RelElementData));
            //alert($scope.RelElementData);

            requestService.update("FunEleMutualReacts", $scope.RelElementData).then(function (data) {
                alert("保存成功。");
            });


        }

        $scope.DeleteRelElement = function (obj) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    if (obj.ID > 0) {
                        requestService.delete("FunEleMutualReacts", obj.ID).then(function (data) {
                            Alert("删除成功。");
                        });
                    }
                    $scope.RelElementData.splice(obj, 1);
                    $scope.$apply();
                }
            });
        };

        $scope.GetFunEleMutualReacts = function () {
            var querydata = {};
            querydata.ProjectID = $scope.CurrentProjectID;
            requestService.lists("FunEleMutualReacts", querydata).then(function (data) {
                $scope.RelElementData = data;
            });

        }
        $scope.GetFunEleMutualReacts();

        //相互作用表维护  -- end




        //check
        function AddRel(RelIDs) {
            var PositiveObj = GetElement(RelIDs.split("_")[0]);
            var PassiveObj = GetElement(RelIDs.split("_")[1]);

            var RelElementInfo = {};
            RelElementInfo.ProjectID = $scope.CurrentProjectID;
            RelElementInfo.PositiveEleID = PositiveObj.ID;
            RelElementInfo.PositiveEleName = PositiveObj.EleName;
            RelElementInfo.FunctionName = "";
            RelElementInfo.PassiveEleID = PassiveObj.ID;
            RelElementInfo.PassiveEleName = PassiveObj.EleName;
            RelElementInfo.FunctionType = "基本功能";
            RelElementInfo.FunctionGrade = "正常功能";
            RelElementInfo.ElementType = "";
            $scope.RelElementData.push(RelElementInfo);
        }

        $scope.links = [];
        function ConvertToMapLinks() {
            console.log("$scope.RelElementData");
            console.log($scope.RelElementData);
            for (var i = 0; i < $scope.RelElementData.length; i++) {
                var link = {};
                link.ID = i;
                link.source = $scope.RelElementData[i].PositiveEleName;
                link.target = $scope.RelElementData[i].PassiveEleName;
                link.effect = "1";//$scope.RelElementData[i].FunctionGrade;
                link.type = $scope.RelElementData[i].FunctionType;
                link.direction = "";
                link.ProjectID = $scope.CurrentProjectID;
                link.PositiveEleID = $scope.RelElementData[i].PositiveEleID;
                link.PositiveEleName = $scope.RelElementData[i].PositiveEleName;
                link.FunctionName = $scope.RelElementData[i].FunctionName;
                link.PassiveEleID = $scope.RelElementData[i].PassiveEleID;
                link.PassiveEleName = $scope.RelElementData[i].PassiveEleName;
                link.FunctionType = $scope.RelElementData[i].FunctionType;
                link.FunctionGrade = $scope.RelElementData[i].FunctionGrade;
                link.ElementType = $scope.RelElementData[i].ElementType;
                $scope.links.push(link);
            }
        }


        function RemoveRel(RelIDs) {
            var PositiveObj = GetElement(RelIDs.split("_")[0]);
            var PassiveObj = GetElement(RelIDs.split("_")[1]);
            for (var i = 0; i < $scope.RelElementData.length; i++) {
                if ($scope.RelElementData[i].PositiveEleID == PositiveObj.ID)
                    if ($scope.RelElementData[i].PassiveEleID == PassiveObj.ID) {
                        $scope.RelElementData.splice(i, 1);
                    }
            }
        }

        function GetElement(ID) {
            //for (var i = 0; i < $scope.TreeLeafs.length; i++) {
            //    if ($scope.TreeLeafs[i].ID == ID)
            //        return $scope.TreeLeafs[i];
            //}
            return $scope.LeafNodes["n" + ID];
        }

        $scope.selected = [];

        var updateSelected = function (action, id, name) {
            if (action == 'add' && $scope.selected.indexOf(id) == -1) {
                $scope.selected.push(id);
                AddRel(id);//增加作用关系
            }
            if (action == 'remove' && $scope.selected.indexOf(id) != -1) {
                var idx = $scope.selected.indexOf(id);
                $scope.selected.splice(idx, 1);
                RemoveRel(id);
            }
        }

        $scope.updateSelection = function ($event, id) {
            var checkbox = $event.target;
            var action = (checkbox.checked ? 'add' : 'remove');
            updateSelected(action, id, checkbox.name);
        }

        $scope.isSelected = function (PositiveEleID, PassiveEleID) {
            for (var i = 0; i < $scope.RelElementData.length; i++) {
                if ($scope.RelElementData[i].PositiveEleID == PositiveEleID)
                    if ($scope.RelElementData[i].PassiveEleID == PassiveEleID) {
                        return true;
                    }
            }
            return false;
        }

        //刷新checkbox from db
        $scope.Refresh = function () {
            $scope.GetTreeLeafs();
            $scope.GetFunEleMutualReacts();
            $scope.$apply();
        }

        //check -- end


        //相互作用关系维护表 -- end

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
        //获得所有节点，左侧树使用 --end



        //获得所有叶子节点，对应表使用
        $scope.TreeLeafs = [];
        $scope.LeafNodes = {};//檢索使用
        $scope.GetTreeLeafs = function () {
            var QueryData = {};
            QueryData.ProjectID = $scope.CurrentProjectID;
            QueryData.EleName = "";
            requestService.lists("FunctionElements", QueryData).then(function (data) {
                $scope.TreeLeafs = data;
                $scope.LeafNodes = {};
                for (var i = 0; i < $scope.TreeLeafs.length; i++) {
                    $scope.LeafNodes["n" + $scope.TreeLeafs[i].ID] = $scope.TreeLeafs[i];
                }
            });
        };
        $scope.GetTreeLeafs();
        //获得所有叶子节点，对应表使用 --end



        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }

        $scope.remove = function (scope) {
            bootbox.confirm("要删除当前的记录: " + scope.$modelValue.title + " ？", function (result) {
                if (result) {
                    if (scope.$modelValue.nodes.length > 0) {
                        alert("存在子节点不能删除。");
                        return false;
                    }
                    requestService.delete("FunctionElements", scope.$modelValue.id).then(function (data) {
                        Alert("删除成功。");
                        return scope.$parentNodesScope.removeNode(scope);
                    });
                }
            });
        };

        $scope.toggle = function (scope) {
            scope.toggle();
        };

        $scope.moveLastToTheBeginning = function () {
            var a = $scope.data.pop();
            $scope.data.splice(0, 0, a);
        };

        $scope.CurrentNode = "";
        $scope.CurrentOperate = "";
        $scope.newSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            $scope.EleName = "";
            $scope.CurrentOperate = "Add";
            $('#modal-table').modal('show');
            return;
        };
        $scope.UpdateSubItem = function (CurrentNode) {
            $scope.CurrentNode = CurrentNode;
            var nodeData = CurrentNode.$modelValue;
            $scope.EleName = nodeData.title;
            $scope.CurrentOperate = "Update";
            $('#modal-table').modal('show');
        };
        //新增一个节点的保存事件
        $scope.EleName = "";
        $scope.SaveEleName = function () {
            var FunctionElementInfo = {};
            FunctionElementInfo.ProjectID = locals.get("ProjectID");
            FunctionElementInfo.EleName = $scope.EleName;
            var nodeData = $scope.CurrentNode.$modelValue;
            //add
            if ($scope.CurrentOperate == "Add") {
                FunctionElementInfo.FatherID = nodeData.id;
                requestService.add("FunctionElements", FunctionElementInfo).then(function (data) {
                    nodeData.nodes.push({
                        id: data,
                        title: $scope.EleName,
                        nodes: []
                    });
                    alert("保存成功。");
                });
            }

            //update
            if ($scope.CurrentOperate == "Update") {
                FunctionElementInfo.ID = nodeData.id;
                requestService.update("FunctionElements", FunctionElementInfo).then(function (data) {
                    nodeData.title = $scope.EleName;
                    alert("保存成功。");
                });
            }
            $('#modal-table').modal('hide');
        };
        //新增一个节点的保存事件  --end

        $scope.FatherSonIDs = "";
        function save(fatherid, sons) {
            for (var i = 0; i < sons.length; i++) {
                $scope.FatherSonIDs = $scope.FatherSonIDs + fatherid + "|" + sons[i].id + "^";
                if (sons[i].nodes.length > 0) {
                    save(sons[i].id, sons[i].nodes);
                }
            }

        }

        $scope.SaveTreeNodes = function () {
            $scope.FatherSonIDs = "";
            for (var i = 0; i < $scope.TreeData.length; i++) {
                $scope.FatherSonIDs = $scope.FatherSonIDs + 0 + "|" + $scope.TreeData[i].id + "^";
                save($scope.TreeData[i].id, $scope.TreeData[i].nodes);
            }
            requestService.updateMutiple("FunctionElements", "FatherSonIDs=" + $scope.FatherSonIDs).then(function (data) {
                alert("保存成功");
            });
        }



        $scope.collapseAll = function () {
            $scope.$broadcast('angular-ui-tree:collapse-all');
        };

        $scope.expandAll = function () {
            $scope.$broadcast('angular-ui-tree:expand-all');
        };

        //$scope.data = [{ 'id': 61, 'title': '1丝杠', 'nodes': [{ 'id': 64, 'title': '超系统元件', 'nodes': [{ 'id': 67, 'title': '导向架', 'nodes': [{ 'id': 63, 'title': '大链轮', 'nodes': [{ 'id': 65, 'title': '小链轮', 'nodes': [{ 'id': 70, 'title': '链条', 'nodes': [{ 'id': 62, 'title': '滚筒', 'nodes': [{ 'id': 71, 'title': '43434', 'nodes': [] }] }] }, { 'id': 66, 'title': '链轮轴', 'nodes': [{ 'id': 69, 'title': '电机', 'nodes': [] }, { 'id': 68, 'title': '螺母', 'nodes': [] }] }] }] }] }] }] }, { 'id': 74, 'title': '通天塔', 'nodes': [{ 'id': 75, 'title': '的点点滴滴', 'nodes': [] }] }];


        //$scope.data = [{
        //    'id': 1,
        //    'title': 'node1',
        //    'nodes': [
        //      {
        //          'id': 11,
        //          'title': 'node1.1',
        //          'nodes': [
        //            {
        //                'id': 111,
        //                'title': 'node1.1.1',
        //                'nodes': []
        //            }
        //          ]
        //      },
        //      {
        //          'id': 12,
        //          'title': 'node1.2',
        //          'nodes': []
        //      }
        //    ]
        //}, {
        //    'id': 2,
        //    'title': 'node2',
        //    'nodrop': true, // An arbitrary property to check in custom template for nodrop-enabled
        //    'nodes': [
        //      {
        //          'id': 21,
        //          'title': 'node2.1',
        //          'nodes': []
        //      },
        //      {
        //          'id': 22,
        //          'title': 'node2.2',
        //          'nodes': []
        //      }
        //    ]
        //}, {
        //    'id': 3,
        //    'title': 'node3',
        //    'nodes': [
        //      {
        //          'id': 31,
        //          'title': 'node3.1',
        //          'nodes': []
        //      }
        //    ]
        //}];

        //map

        $scope.SaveMap = function () {
            var EleNodes = force.nodes();
            for (var n in EleNodes) {
                $scope.NodeData = {
                    ProjectID: "",
                    EleName: "",
                    ElementType: "",
                    EleX: "",
                    EleY: "",
                    Remark: "",
                    FatherID: ""
                };
                $scope.NodeData.ProjectID = locals.get("ProjectID");
                $scope.NodeData.EleName = EleNodes[n].name;
                $scope.NodeData.EleX = EleNodes[n].x;
                $scope.NodeData.EleY = EleNodes[n].y;
                requestService.update("FunctionElements", $scope.NodeData).then(function (data) {

                });
            }
            alert("操作成功。");
        };

        $scope.Draw = function () {
            ConvertToMapLinks();
            console.log($scope.links);


            var links111 = [
    { ID: "197", x: "12", y: "122", source: "电机", target: "大链轮", effect: "1", type: "转动" },
    { ID: "198", x: "212", y: "22", source: "小链轮", target: "滚筒", effect: "2", type: "转动" },
    { ID: "199", x: "1212", y: "111", source: "大链轮", target: "链条", effect: "1", type: "驱动" },
    { ID: "201", x: "12", y: "899", source: "螺母", target: "导向架", effect: "1", type: "带动" },
    { ID: "202", x: "12", y: "89", source: "丝杠", target: "螺母", effect: "1", type: "移动" },
    { ID: "203", x: "232", y: "23", source: "链轮轴", target: "丝杠", effect: "1", type: "转动" },
    { ID: "yuanjian204", x: "23", y: "8", source: "小链轮", target: "链轮轴", effect: "1", type: "转动" },
    { ID: "yuanjian232", x: "23", y: "89", source: "电机", target: "链条", effect: "2", type: "驱动" },
    { ID: "yuanjian241", x: "235", y: "2", source: "滚筒", target: "链条", effect: "1", type: "12" },
    { ID: "yuanjian244", x: "56", y: "23", source: "导向架", target: "电机", effect: "1", type: "23" },
    { ID: "YuanJian113", x: "78", y: "343", source: "超系统元件", target: "电机", effect: "1", type: "222", direction: "CXT2YJ" },
    { ID: "YuanJian114", x: "989", y: "22", source: "超系统元件", target: "大链轮", effect: "1", type: "33", direction: "CXT2YJ" }];

            //       var links = [
            //{ ID: "197", source: "电机", target: "大链轮", effect: "1", type: "转动" },
            //{ ID: "198", source: "小链轮", target: "滚筒", effect: "2", type: "转动" },
            //{ ID: "199", source: "大链轮", target: "链条", effect: "1", type: "驱动" },
            //{ ID: "201", source: "螺母", target: "导向架", effect: "1", type: "带动" },
            //{ ID: "202", source: "丝杠", target: "螺母", effect: "1", type: "移动" },
            //{ ID: "203", source: "链轮轴", target: "丝杠", effect: "1", type: "转动" },
            //{ ID: "yuanjian204", source: "小链轮", target: "链轮轴", effect: "1", type: "转动" },
            //{ ID: "yuanjian232", source: "电机", target: "链条", effect: "2", type: "驱动" },
            //{ ID: "yuanjian241", source: "滚筒", target: "链条", effect: "1", type: "12" },
            //{ ID: "yuanjian244", source: "导向架", target: "电机", effect: "1", type: "23" },
            //{ ID: "YuanJian113", source: "超系统元件", target: "电机", effect: "1", type: "222", direction: "CXT2YJ" },
            //{ ID: "YuanJian114", source: "超系统元件", target: "大链轮", effect: "1", type: "33", direction: "CXT2YJ" }];

            var nodes = {};

            $scope.links.forEach(function (link) {
                link.source = nodes[link.source] || (nodes[link.source] = { id: link.PositiveEleID, name: link.source, showType: getShowType(link, "source") });
                link.target = nodes[link.target] || (nodes[link.target] = { id: link.PassiveEleID, name: link.target, showType: getShowType(link, "target") });

            });

            //var n = {};
            //n["11"] = "aaa";
            //n["12"] = "bbb";
            //console.log(n);

            //console.log("links");
            //console.log(links);
            //console.log("nodes");
            //console.log(nodes);
            //console.log("leaf");
            //console.log($scope.TreeLeafs);


            var width = 1000,
            height = 900;

            var force = d3.layout.force()//layout将json格式转化为力学图可用的格式
            .nodes(d3.values(nodes))//设定节点数组
            .links($scope.links)//设定连线数组
            .size([width, height])//作用域的大小
            .linkDistance(150)//连接线长度
            .charge(-1500)//顶点的电荷数。该参数决定是排斥还是吸引，数值越小越互相排斥
            .on("tick", tick)//指时间间隔，隔一段时间刷新一次画面
            .start(); //开始转换

            //    var svg = d3.select("body").append("svg")
            //.attr("width", width)
            //.attr("height", height);

            $(".wrap3_graph").children("svg").remove();
            var svg = d3.select(".wrap3_graph").append("svg").attr("width", width).attr("height", height);

            //箭头
            var marker =
            svg.append("marker")
            //.attr("id", function(d) { return d; })
                .attr("id", "resolved")
            //.attr("markerUnits","strokeWidth")//设置为strokeWidth箭头会随着线的粗细发生变化
                .attr("markerUnits", "userSpaceOnUse")
                .attr("viewBox", "0 -5 10 10")//坐标系的区域
                .attr("refX", 30)//箭头坐标
                .attr("refY", 0)
                .attr("markerWidth", 12)//标识的大小
                .attr("markerHeight", 12)
                .attr("orient", "auto")//绘制方向，可设定为：auto（自动确认方向）和 角度值
                .attr("stroke-width", 2)//箭头宽度
                .append("path")
                .attr("d", "M0,-5L10,0L0,5")//箭头的路径
                .attr('fill', '#a3a3a3'); //箭头颜色

            //设置连接线
            var edges_line = svg.selectAll(".edgepath")
            .data(force.links())
            .enter()
            .append("path")
            .attr({
                'd': function (d) { return 'M ' + d.source.x + ' ' + d.source.y + ' L ' + d.target.x + ' ' + d.target.y },
                'class': 'edgepath',
                //'fill-opacity':0,
                //'stroke-opacity':0,
                //'fill':'blue',
                //'stroke':'red',
                //   'stroke-dasharray':'5,5',
                'id': function (d, i) { return 'edgepath' + i; }
            })
            .style("stroke", function (d) {
                var lineColor;
                var strokedasharray;
                //根据关系的不同设置线条颜色
                if (d.effect == 1) {
                    lineColor = "#A254A2";
                } else if (d.effect == 2) {
                    lineColor = "#A254A2";
                } else if (d.effect == 3) {
                    lineColor = "#A254A2";
                } else if (d.effect == 4) {
                    lineColor = "#A254A2";
                }
                return lineColor;
            })
            .style("stroke-dasharray", function (d) {
                var strokeDasharray;
                //根据关系的不同设置实虚线条
                if (d.effect == 1 || d.effect == 3) {
                    strokeDasharray = "0";
                } else if (d.effect == 2) {
                    //alert(2);
                    strokeDasharray = "5,5";
                } else if (d.effect == 4) {
                    strokeDasharray = "10,10";
                }
                return strokeDasharray;
            })
            .style("stroke-width", function (d) {
                var strokeWidth;
                //根据关系的不同设置线条粗细
                if (d.effect == 1 || d.effect == 2 || d.effect == 4) {
                    strokeWidth = "1";
                } else if (d.effect == 3) {
                    strokeWidth = "3";
                }
                return strokeWidth;
            })
            .style("pointer-events", "none")
            .attr("marker-end", "url(#resolved)"); //根据箭头标记的id号标记箭头



            var edges_text = svg.append("g").selectAll(".edgelabel")
            .data(force.links())
            .enter()
            .append("text")
            .append('textPath')
            .attr('xlink:href', function (d, i) { return '#edgepath' + i })
            //        .attr("x", function (d) { return (d.source.x + d.target.x) / 2; })
            //         .attr("y", function (d) { return (d.source.y + d.target.y) / 2; })
            .text(function (d) {
                var r = '';
                switch (d.effect) {
                    case 0:
                        r = '有标准作用';
                        break;
                    case '1':
                        r = '有过剩作用';
                        break;
                    case '2':
                        r = '有不足作用';
                        break;
                    case '3':
                        r = '有害作用';
                        break;
                }
                return '　　　　　' + d.type;
            })
            //.style("pointer-events", "none")
            .attr("class", "linetext")


            //.attr('xlink:href', function (d, i) { return '#edgepath' + i })

             .style("pointer-events", "none")
              .style("padding-left", "50px")
            ;



            var drag = force.drag()
                            .on("dragstart", function (d, i) {
                                d.fixed = true;

                                console.log(d.ID);
                                console.log(d.x);
                            })
                            .on("dragend", function (d, i) {
                                //console.log("拖拽状态：结束");
                                d.x = 50
                            })
                            .on("drag", function (d, i) {
                                //console.log("拖拽状态：进行中");
                            });

            var circle = svg.append("g").selectAll("image")
            .data(force.nodes())//表示使用force.nodes数据
            .enter().append("image")
            .attr({
                "width": 100, "height": 40
            })
            .attr(
            "xlink:href", function (node) {
                var ElementNode = $scope.LeafNodes["n" + node.id];
                if (!IsNum(ElementNode.EleX) && (!IsNum(ElementNode.EleY))) {
                    node.fixed = true;  //这里可以固定，并且设置位置----baoqiang
                    node.px = ElementNode.x;
                    node.py = ElementNode.y;
                }

                var result = '/pages/assets/images/rect.png';
                if (node.showType == 'ZP') {

                    result = '/pages/assets/images/rect2.png';
                }
                else if (node.showType == 'CXT') {
                    result = '/pages/assets/images/rect3.png';
                }
                else {
                    result = '/pages/assets/images/rect.png';
                }
                return result
            } //水平圆角
            )
            .attr(
            "ry", function (node) {
                var rx = 0;
                if (node.showType == 'ZP') {
                    rx = 12.5;
                }
                else if (node.showType == 'CXT') {
                    rx = 0;
                }
                else {
                    rx = 0;
                }
                return rx
            } //水平圆角
            )
            .call(force.drag);         //将当前选中的元素传到drag函数中，使顶点可以被拖动

            //圆圈的提示文字
            circle.append("svg:title")
            .text(function (node) {
                var link = $scope.links[node.index];
                if (typeof (link) == undefined) {
                    if (node.name == link.source.name && link.effect == "主营产品") {
                        return "双击可查看详情"
                    }
                }

            });

            /* 绘制右下角箭头*/
            var rect01 = svg.append("marker")
            .attr("refX", 250)//箭头坐标
            .attr("refY", 300)
            .attr("markerWidth", 12)//标识的大小
            .attr("markerHeight", 12)
            .attr("orient", "auto")//绘制方向，可设定为：auto（自动确认方向）和 角度值
            .attr("stroke-width", 2)//箭头宽度
            .append("path")
            .attr("d", "M0,-5L10,0L0,5")//箭头的路径
            .attr('fill', '#666'); //箭头颜色



            var text = svg.append("g").selectAll("text")
            .data(force.nodes())
            //返回缺失元素的占位对象（placeholder），指向绑定的数据中比选定元素集多出的一部分元素。
            .enter()
            .append("text")
            .attr("dy", ".35em")
            .attr("text-anchor", "middle")//在圆圈中加上数据  
            .style('fill', function (node) {
                var color; //文字颜色
                var link = $scope.links[node.index];
                if (typeof (link) == undefined) {
                    if (node.name == link.source.name && link.effect == "主营产品") {
                        color = "#B43232";
                    } else {
                        color = "#A254A2";
                    }
                }
                return color;
            }).attr('x', function (d) {
                // console.log(d.name+"---"+ d.name.length);
                var re_en = /[a-zA-Z]+/g;
                //如果是全英文，不换行
                // if(typeof(d.name.match())==undefined){
                if (d.name.match(re_en)) {
                    d3.select(this).append('tspan')
                        .attr('x', 0)
                        .attr('y', 2)
                        .text(function () { return d.name; });
                }
                    //如果小于四个字符，不换行
                else if (d.name.length <= 6) {
                    d3.select(this).append('tspan')
                        .attr('x', 0)
                        .attr('y', 2)
                        .text(function () { return d.name; });
                } else {
                    var top = d.name.substring(0, 6);
                    var bot = d.name.substring(6, d.name.length);

                    d3.select(this).text(function () { return ''; });

                    d3.select(this).append('tspan')
                        .attr('x', 0)
                        .attr('y', -7)
                        .text(function () { return top; });

                    d3.select(this).append('tspan')
                        .attr('x', 0)
                        .attr('y', 10)
                        .text(function () { return bot; });
                }

            });

            function tick() {
                if (typeof (circle.attr()) != undefined && typeof (text.attr()) != undefined) {
                    circle.attr("transform", transform1); //圆圈
                    text.attr("transform", transform2); //顶点文字
                }

                edges_line.attr('d', function (d) {
                    var path = 'M ' + d.source.x + ' ' + d.source.y + ' L ' + d.target.x + ' ' + d.target.y;
                    return path;
                });

                edges_text.attr('transform', function (d, i) {
                    //            if (d.target.x < d.source.x) {
                    //                bbox = this.getBBox();
                    //                rx = bbox.x + bbox.width / 2;
                    //                ry = bbox.y + bbox.height / 2;
                    //                return 'rotate(180 ' + rx + ' ' + ry + ')';
                    //            }
                    //            else {
                    //                return 'rotate(0)';
                    //            }
                    return 'rotate(0)';
                });
                //edges_text.attr("x", function (d) { return 50; return (d.source.x + d.target.x) / 2; })
                //edges_text.attr("y", function (d) { return 50; return (d.source.y + d.target.y) / 2; })
            }

            //设置连接线的坐标,使用椭圆弧路径段双向编码
            function linkArc(d) {
                //var dx = d.target.x - d.source.x,
                // dy = d.target.y - d.source.y,
                // dr = Math.sqrt(dx * dx + dy * dy);
                //return "M" + d.source.x + "," + d.source.y + "A" + dr + "," + dr + " 0 0,1 " + d.target.x + "," + d.target.y;
                //打点path格式是：Msource.x,source.yArr00,1target.x,target.y  

                return 'M ' + d.source.x + ' ' + d.source.y + ' L ' + d.target.x + ' ' + d.target.y
            }
            //设置圆圈和文字的坐标
            function transform1(d) {
                var aa = d.x - 50;
                var bb = d.y - 20;
                return "translate(" + aa + "," + bb + ")";
            }
            function transform2(d) {
                return "translate(" + (d.x) + "," + d.y + ")";
            }

            function getShowType(link, type) {
                var showType = "YJ";
                if (link.direction == "YJ2ZP" && type == "target") {
                    showType = 'ZP';
                }
                else if (link.direction == "CXT2YJ" && type == "source") {
                    showType = 'CXT';
                }
                else {
                    showType = 'YJ';
                }
                return showType;
            }

            function GetNodePos(name) {
                for (var n in links111) {
                    //alert(links111[n].source);
                    if (links111[n].source == name) {
                        //alert(links111[n]);
                        return links111[n];
                    }
                }
            }

            //判断是否为数字
            function IsNum(s) {
                if (s != null && s != "") {
                    return !isNaN(s);
                }
                return false;
            }

            //map  end
        }




    });//end

