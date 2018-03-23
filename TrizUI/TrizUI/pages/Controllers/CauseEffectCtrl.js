angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.PreSectionComponentList = "";
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];
        $scope.ComponentRelInfoList = [];
        $scope.ComponentRelInfoListSection = [];
        $scope.SrcComponentInfo = function () {
            this.ID = "";
            this.Name = "";
        }
        $scope.SrcComponentInfoList = [];

        $scope.ConflictInfo = function () {
            RelComponentName: "";
            RelComponentParamName: "";
            CurrentConfig: "";
            ChangeConfig: "";
            CurrentProblem: "";
            NewProblem: "";
        }
        $scope.ConflictInfoList = [];


        var objSrcComponentInfo = new $scope.SrcComponentInfo();
        objSrcComponentInfo.ID = "1";
        objSrcComponentInfo.Name = "缆绳";
        $scope.SrcComponentInfoList.push(objSrcComponentInfo);

        objSrcComponentInfo = new $scope.SrcComponentInfo();
        objSrcComponentInfo.ID = "2";
        objSrcComponentInfo.Name = "导向架";
        $scope.SrcComponentInfoList.push(objSrcComponentInfo);

        objSrcComponentInfo = new $scope.SrcComponentInfo();
        objSrcComponentInfo.ID = "3";
        objSrcComponentInfo.Name = "卷筒";
        $scope.SrcComponentInfoList.push(objSrcComponentInfo);

        objSrcComponentInfo = new $scope.SrcComponentInfo();
        objSrcComponentInfo.ID = "4";
        objSrcComponentInfo.Name = "人";
        $scope.SrcComponentInfoList.push(objSrcComponentInfo);
        //保存
        $scope.Save = function () {
            GenerateMap();
        };
        //生成图
        function GenerateMap() {
            $scope.SVGHeight = ($scope.ComponentRelInfoListSection.length + 1) * 450;
            $scope.GetComponentParamsPosition();
            $scope.Draw();
        }
        //save end

        //初级功能参数列表 
        $scope.ComponentParamInfo = function () {
            this.ID = "";  //ID
            this.ProjectID = $scope.CurrentProjectID;  //ID
            this.ComponentName = "";  //问题相关元件
            this.ParamName = "";//参数名称
            this.ParamType = "独立变量";//参数类型
            this.Disabled = "";
        }

        $scope.ComponentParamInfoList = [];

        var newobj = new $scope.ComponentParamInfo();

        $scope.ComponentParamInfoList.push(newobj);

        $scope.ADDParamInfoOperate = function () {
            var newobj1 = new $scope.ComponentParamInfo();
            $scope.ComponentParamInfoList.push(newobj1);
        }

        var RelListFromPreSection = [];

        $scope.SaveParamInfoOperate = function () {
            $scope.ClearComponentRelInfoListAndSection();
            $scope.InsertComponentToRelInfoList();
            $scope.InsertComponentRelInfoListToSection();
            RelListFromPreSection = [];
            for (var j = 0; j < $scope.ComponentParamInfoList.length; j++) {
                if ($scope.ComponentParamInfoList[j].ParamType == "非独立变量") {
                    var componentRelInfo = new $scope.ComponentRelInfo();
                    componentRelInfo.ImpactComponentName = $scope.ComponentParamInfoList[j].ComponentName;
                    componentRelInfo.ImpactParamName = $scope.ComponentParamInfoList[j].ParamName;
                    componentRelInfo.ParamType = $scope.ComponentParamInfoList[j].ParamType;
                    RelListFromPreSection.push(componentRelInfo);
                }
            }

            //set disabled
            $scope.SetComponentParamInfoListDisabled(true);

            //save to database
            $scope.SaveToComponentParamInfoListDB();
        }

        $scope.SetPosition = function () {
            var y = $scope.SVGHeight - 10;
            for (var j = 0; j < $scope.ComponentParamInfoList.length; j++) {

                $scope.ComponentParamInfoList[j].x = 0;
                $scope.ComponentParamInfoList[j].y = y;
            }
        };

        $scope.SetComponentParamInfoListDisabled = function (flag) {
            for (var j = 0; j < $scope.ComponentParamInfoList.length; j++) {
                $scope.ComponentParamInfoList[j].Disabled = flag;
            }
        };

        $scope.ClearComponentRelInfoListAndSection = function () {
            $scope.ComponentRelInfoList = [];
            $scope.ComponentRelInfoListSection = [];
        };

        $scope.InsertComponentToRelInfoList = function () {
            var componentRelInfo = new $scope.ComponentRelInfo();
            $scope.ComponentRelInfoList.push(componentRelInfo);
        };

        $scope.InsertComponentRelInfoListToSection = function () {
            $scope.ComponentRelInfoListSection.push($scope.ComponentRelInfoList);
        };

        $scope.DeleteComponentParamInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    console.log("$scope.ComponentParamInfoList", $scope.ComponentParamInfoList);
                    requestService.delete("ComponentParams", $scope.ComponentParamInfoList[index].ID).then(function (data) {
                    });
                    $scope.ComponentParamInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }

        $scope.UpdateParamInfoOperate = function () {
            bootbox.confirm("修改操作会清除当前分析结果之后的内容，确认该操作吗？", function (result) {
                if (result) {
                    $scope.$apply(function () {
                        $scope.ComponentRelInfoList = [];
                        $scope.ComponentRelInfoListSection = [];
                        $scope.ConflictInfoList = [];
                        $scope.SetComponentParamInfoListDisabled(false);
                    });
                }
            });
        }

        $scope.SaveToComponentParamInfoListDB = function () {
            for (var i = 0; i < $scope.ComponentParamInfoList.length; i++) {
                if ($scope.ComponentParamInfoList[i].ID == "") {
                    requestService.add("ComponentParams", $scope.ComponentParamInfoList[i]).then(function (data) {

                    });
                }
                else {
                    requestService.update("ComponentParams", $scope.ComponentParamInfoList[i]).then(function (data) {

                    });
                }
            }

        };


        var GetComponentParams = function () {
            var data = {
                currentPage: "",
                itemsPerPage: "",
                ProjectID: $scope.CurrentProjectID,
                ParamType: "",
                Disabled: ""
            };
            data.currentPage = 1;
            data.itemsPerPage = 999;
            requestService.lists("ComponentParams", data).then(function (data) {
                $scope.ComponentParamInfoList = data.Results;
            });
        }
        GetComponentParams();
        //End

        //功能参数列表
        $scope.ComponentRelInfo = function () {
            this.ComponentID = "";//问题相关元件
            this.ComponentName = "";//元件特征参数
            this.ImpactComponentName = "";//影响该参数元件
            this.ImpactParamName = "";//参数类型
            this.ParamType = "独立变量";
            this.Disabled = "";
        }


        $scope.ADDRelOperate = function (i) {
            var componentRelInfo1 = new $scope.ComponentRelInfo();
            $scope.ComponentRelInfoListSection[i].push(componentRelInfo1);
        };
        $scope.DelRelOperate = function (SectionIndex, Index) {
            bootbox.confirm("确认删除该条记录吗？", function (result) {
                if (result) {
                    $scope.$apply(function () {
                        $scope.ComponentRelInfoListSection[SectionIndex].splice(Index, 1);
                    });
                }
            });
        };

        $scope.UpdateSectionOperate = function (i) {
            bootbox.confirm("修改操作会清除当前分析结果之后的内容，确认该操作吗？", function (result) {
                if (result) {
                    //cleare section after i.
                    $scope.ComponentRelInfoListSection.splice(i + 1, $scope.ComponentRelInfoListSection.length - i - 1);

                    //clear conflict list
                    $scope.ConflictInfoList = [];

                    //set disabled
                    for (var j = 0; j < $scope.ComponentRelInfoListSection[i].length; j++) {
                        $scope.ComponentRelInfoListSection[i][j].Disabled = "";
                    }

                    $scope.$apply();
                }
            });
        }


        $scope.SaveRelOperate = function (i) {
            //disabled
            $scope.SetDisabledBySectionIndex(i);

            //如果不存在非独立变量，则不生成新的
            if (ExistNotDependentParam(i)) {
                var ComponentRelInfoList1 = [];
                ComponentRelInfoList1.push(new $scope.ComponentParamInfo());
                $scope.ComponentRelInfoListSection.push(ComponentRelInfoList1);
            }
            else {
                //生成冲突列表 
                GenerateConflictList();
            }
        };
        function ExistNotDependentParam(i) {
            for (var j = 0; j < $scope.ComponentRelInfoListSection[i].length; j++) {
                if ($scope.ComponentRelInfoListSection[i][j].ParamType == "非独立变量") {
                    return true;
                }
            }
            return false;
        }
        //$scope.SetOrder = function (i) {


        //};

        $scope.PreSectionComponentList = function (i) {
            if (i == 0) {
                return RelListFromPreSection;
            }
            return $scope.ComponentRelInfoListSection[i - 1];
        };

        $scope.SetDisabledBySectionIndex = function (i) {
            for (var j = 0; j < $scope.ComponentRelInfoListSection[i].length; j++) {
                $scope.ComponentRelInfoListSection[i][j].Disabled = true;
            }
        };

        //End

        //冲突列表
        function GenerateConflictList() {
            $scope.ConflictInfoList = [];
            for (var SectionIndex = 0; SectionIndex < $scope.ComponentRelInfoListSection.length; SectionIndex++) {
                for (var i = 0; i < $scope.ComponentRelInfoListSection[SectionIndex].length; i++) {
                    if ($scope.ComponentRelInfoListSection[SectionIndex][i].ParamType != "独立变量") continue;
                    var NewConflictInfo = new $scope.ConflictInfo();
                    NewConflictInfo.RelComponentName = $scope.ComponentRelInfoListSection[SectionIndex][i].ImpactComponentName;
                    NewConflictInfo.RelComponentParamName = $scope.ComponentRelInfoListSection[SectionIndex][i].ImpactParamName;
                    $scope.ConflictInfoList.push(NewConflictInfo);
                }
            }
        }

        $scope.SaveConflict = function () {
            GenerateMap();
        };
        //冲突列表  End



        //相互作用表
        //map 
        $scope.SVGWidth = 800;
        $scope.SVGHeight = 900;
        $scope.ComponentsForMapNodeXY = {};//檢索使用
        $scope.ComponentParam = {};
        $scope.GetComponentParamsPosition = function () {
            var curBottom = $scope.SVGHeight;
            //第一层
            var SpaceY = 200; //垂直间距
            var n = {};
            n.x = $scope.SVGWidth / 2;
            n.y = curBottom - 20;
            n.name = $scope.CurrentProblemDes;
            $scope.ComponentsForMapNodeXY[$scope.CurrentProblemDes] = n;
            curBottom = n.y;
            //第二层
            var delta = ($scope.SVGWidth / ($scope.ComponentParamInfoList.length + 1));
            for (var i = 0; i < $scope.ComponentParamInfoList.length; i++) {
                var n = {};
                n.x = delta * (i + 1);
                n.y = curBottom - SpaceY;
                n.name = $scope.ComponentParamInfoList[i].ComponentName + " " + $scope.ComponentParamInfoList[i].ParamName;
                $scope.ComponentsForMapNodeXY[n.name] = n;
            }
            curBottom = curBottom - SpaceY;
            //第三层 以后
            for (var SectionIndex = 0; SectionIndex < $scope.ComponentRelInfoListSection.length; SectionIndex++) {
                var CptParamList = $scope.ComponentRelInfoListSection[SectionIndex];
                delta = ($scope.SVGWidth / (CptParamList.length + 1));
                //获得一个排序后的list
                var NewList = [];
                NewList = SetOrder(CptParamList, SectionIndex);
                for (var i = 0; i < NewList.length; i++) {
                    var n = {};
                    n.x = delta * (i + 1);
                    n.y = curBottom - SpaceY;
                    n.name = NewList[i].ImpactComponentName + " " + NewList[i].ImpactParamName;
                    $scope.ComponentsForMapNodeXY[n.name] = n;
                }
                curBottom = curBottom - SpaceY;
            }

            //改变设置
            console.log("$scope.ConflictInfoList", $scope.ConflictInfoList);
            for (var j = 0; j < $scope.ConflictInfoList.length; j++) {
                var n = $scope.ComponentsForMapNodeXY[$scope.ConflictInfoList[j].RelComponentName + " " + $scope.ConflictInfoList[j].RelComponentParamName];
                var newn = {};
                newn.x = n.x;
                newn.y = n.y - SpaceY / 4;
                newn.name = $scope.ConflictInfoList[j].RelComponentName + " " + $scope.ConflictInfoList[j].RelComponentParamName + " " + $scope.ConflictInfoList[j].ChangeConfig;
                $scope.ComponentsForMapNodeXY[newn.name] = newn;
            }

            //新的问题
            for (var j = 0; j < $scope.ConflictInfoList.length; j++) {
                var n = $scope.ComponentsForMapNodeXY[$scope.ConflictInfoList[j].RelComponentName + " " + $scope.ConflictInfoList[j].RelComponentParamName + " " + $scope.ConflictInfoList[j].ChangeConfig];
                var newn = {};
                newn.x = n.x;
                newn.y = n.y - SpaceY / 4;
                newn.name = $scope.ConflictInfoList[j].NewProblem;
                $scope.ComponentsForMapNodeXY[newn.name] = newn;
            }

            console.log("$scope.ComponentsForMapNodeXY", $scope.ComponentsForMapNodeXY);
        };

        function SetOrder(list, index) {
            var newlist = [];
            //功能参数列表 第一行
            if (index == 0) {
                for (var i = 0; i < $scope.ComponentParamInfoList.length; i++) {
                    for (var j = 0; j < list.length; j++) {
                        if (list[j].ComponentName == $scope.ComponentParamInfoList[i].ComponentName + " " + $scope.ComponentParamInfoList[i].ParamName) {
                            newlist.push(list[j]);
                        }
                    }
                }
                return newlist;
            }

            for (var i = 0; i < $scope.ComponentRelInfoListSection[index - 1].length; i++) {
                for (var j = 0; j < list.length; j++) {
                    if (list[j].ComponentName == $scope.ComponentRelInfoListSection[index - 1][i].ImpactComponentName + " " + $scope.ComponentRelInfoListSection[index - 1][i].ImpactParamName) {
                        newlist.push(list[j]);
                    }
                }
            }
            return newlist;

        }

        $scope.CurrentProblemDes = "";

        //requestService.getobj(Sources, $scope.CurrentProjectID).then(function (data) {
        //    $scope.CurrentProblemDes = data.ProblemDescription;
        //});



        $scope.links = [];
        function ConvertToMapLinks() {
            $scope.links = [];
            console.log("$scope.ComponentParamInfoList", $scope.ComponentParamInfoList);
            //来源一：初级功能参数列表
            for (var i = 0; i < $scope.ComponentParamInfoList.length; i++) {
                var link = {};
                link.ID = i;
                link.source = $scope.CurrentProblemDes;
                link.target = $scope.ComponentParamInfoList[i].ComponentName + " " + $scope.ComponentParamInfoList[i].ParamName;
                link.effect = "1";
                link.type = "";
                link.direction = "";
                link.ProjectID = $scope.CurrentProjectID;
                link.SourceID = 999999;
                link.TargetID = i;
                $scope.links.push(link);
            }

            //来源二：功能参数列表 
            for (var SectionIndex = 0; SectionIndex < $scope.ComponentRelInfoListSection.length; SectionIndex++) {
                var CptParamList = $scope.ComponentRelInfoListSection[SectionIndex];
                for (var i = 0; i < CptParamList.length; i++) {
                    var link = {};
                    link.ID = i;
                    link.source = CptParamList[i].ComponentName;
                    link.target = CptParamList[i].ImpactComponentName + " " + CptParamList[i].ImpactParamName;
                    link.effect = "1";
                    link.type = "";
                    link.direction = "";
                    link.ProjectID = $scope.CurrentProjectID;
                    link.SourceID = 999999;
                    link.TargetID = i;
                    $scope.links.push(link);
                }
            }

            //来源三：冲突列表 - 改变设置
            for (var i = 0; i < $scope.ConflictInfoList.length; i++) {
                var link = {};
                link.ID = i;
                link.source = $scope.ConflictInfoList[i].RelComponentName + " " + $scope.ConflictInfoList[i].RelComponentParamName;
                link.target = $scope.ConflictInfoList[i].RelComponentName + " " + $scope.ConflictInfoList[i].RelComponentParamName + " " + $scope.ConflictInfoList[i].ChangeConfig;
                link.effect = "1";
                link.type = "";
                link.direction = "";
                link.ProjectID = $scope.CurrentProjectID;
                link.SourceID = 999999;
                link.TargetID = i;
                $scope.links.push(link);
            }

            //来源四：冲突列表 - 新的问题
            for (var i = 0; i < $scope.ConflictInfoList.length; i++) {
                var link = {};
                link.ID = i;
                link.source = $scope.ConflictInfoList[i].RelComponentName + " " + $scope.ConflictInfoList[i].RelComponentParamName + " " + $scope.ConflictInfoList[i].ChangeConfig;
                link.target = $scope.ConflictInfoList[i].NewProblem;
                link.effect = "1";
                link.type = "";
                link.direction = "";
                link.ProjectID = $scope.CurrentProjectID;
                link.SourceID = 999999;
                link.TargetID = i;
                $scope.links.push(link);
            }
            console.log("$scope.links", $scope.links);
        }

        $scope.Draw = function () {

            ConvertToMapLinks();

            var nodes = {};

            $scope.links.forEach(function (link) {
                link.source = nodes[link.source] || (nodes[link.source] = { id: link.SourceID, name: link.source, showType: getShowType(link, "source") });
                link.target = nodes[link.target] || (nodes[link.target] = { id: link.TargetID, name: link.target, showType: getShowType(link, "target") });
            });

            //var width = 800,
            //height = 900;

            $scope.force = d3.layout.force()//layout将json格式转化为力学图可用的格式
            .nodes(d3.values(nodes))//设定节点数组
            .links($scope.links)//设定连线数组
            .size([$scope.SVGWidth, $scope.SVGHeight])//作用域的大小
            .linkDistance(150)//连接线长度
            .charge(-1500)//顶点的电荷数。该参数决定是排斥还是吸引，数值越小越互相排斥
            .on("tick", tick)//指时间间隔，隔一段时间刷新一次画面
            .start(); //开始转换

            //var svg = d3.select("body").append("svg")
            //.attr("width", width)
            //.attr("height", height);
            //width = $(".wrap3_graph").width(),
            //height = $(".wrap3_graph").height();
            $(".wrap3_graph").children("svg").remove();
            var svg = d3.select(".wrap3_graph").append("svg").attr("width", $scope.SVGWidth).attr("height", $scope.SVGHeight);
            //var svg = d3.select(".wrap3_graph").append("svg").attr("width", width).attr("height", height).attr("background-color", "aqua");
            //var svg = d3.select(".wrap3_graph").append("svg").attr("width", "100%").attr("height", "100%");
            //alert($(".wrap3_graph").width());
            //alert($(".wrap3_graph").height());


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
            .data($scope.force.links())
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
            .data($scope.force.links())
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

            var drag = $scope.force.drag()
                            .on("dragstart", function (d, i) {
                                d.fixed = true;
                            })
                            .on("dragend", function (d, i) {
                                //console.log("拖拽状态：结束");
                                //d.x = 50
                            })
                            .on("drag", function (d, i) {
                                //console.log("拖拽状态：进行中");
                            });

            var circle = svg.append("g").selectAll("image")
            .data($scope.force.nodes())//表示使用force.nodes数据
            .enter().append("image")
            .attr({
                "width": 100, "height": 40
            })
            .attr(
            "xlink:href", function (node) {
                console.log("node.name", node.name + "aaa");
                var ConponentParamNode = $scope.ComponentsForMapNodeXY[node.name];
                console.log("ConponentParamNode", ConponentParamNode);
                if (IsNum(ConponentParamNode.x) && (IsNum(ConponentParamNode.y))) {
                    node.fixed = true;  //这里可以固定，并且设置位置----baoqiang
                    node.px = ConponentParamNode.x;
                    node.py = ConponentParamNode.y;
                }
                //node.fixed = true;

                //node.px = node.x;
                //node.py = node.y;
                //node.px = width/2;
                //node.py = height - 40;
                //node.px = 0;
                //node.px = 0;

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
            .call($scope.force.drag);         //将当前选中的元素传到drag函数中，使顶点可以被拖动

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
            .data($scope.force.nodes())
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

            //判断是否为数字
            function IsNum(s) {
                if (s != null && s != "") {
                    return !isNaN(s);
                }
                return false;
            }

            //map  end
        }

        //map End








    });//end






