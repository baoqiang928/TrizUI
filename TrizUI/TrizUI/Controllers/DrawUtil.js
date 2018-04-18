angular.module("myApp")
    .controller('DrawController', function ($scope) {

        var links = [
        { ID: "197", source: "电机", target: "大链轮", effect: "1", type: "转动" },
        { ID: "198", source: "小链轮", target: "滚筒", effect: "2", type: "转动" },
        { ID: "199", source: "大链轮", target: "链条", effect: "1", type: "驱动" },
        { ID: "201", source: "螺母", target: "导向架", effect: "1", type: "带动" },
        { ID: "202", source: "丝杠", target: "螺母", effect: "1", type: "移动" },
        { ID: "203", source: "链轮轴", target: "丝杠", effect: "1", type: "转动" },
        { ID: "yuanjian204", source: "小链轮", target: "链轮轴", effect: "1", type: "转动" },
        { ID: "yuanjian232", source: "电机", target: "链条", effect: "2", type: "驱动" },
        { ID: "yuanjian241", source: "滚筒", target: "链条", effect: "1", type: "12" },
        { ID: "yuanjian244", source: "导向架", target: "电机", effect: "1", type: "23" },
        { ID: "YuanJian113", source: "超系统元件", target: "电机", effect: "1", type: "222", direction: "CXT2YJ" },
        { ID: "YuanJian114", source: "超系统元件", target: "大链轮", effect: "1", type: "33", direction: "CXT2YJ" }];

        var nodes = {};

        links.forEach(function (link) {
            link.source = nodes[link.source] || (nodes[link.source] = { name: link.source, showType: getShowType(link, "source") });
            link.target = nodes[link.target] || (nodes[link.target] = { name: link.target, showType: getShowType(link, "target") });

        });
        var width = 1000,
        height = 900;

        var force = d3.layout.force()//layout将json格式转化为力学图可用的格式
        .nodes(d3.values(nodes))//设定节点数组
        .links(links)//设定连线数组
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

        /* 将连接线设置为曲线
        var path = svg.append("g").selectAll("path")
        .data(force.links())
        .enter().append("path")
        .attr("class", function(d) { return "link " + d.type; })
        .style("stroke",function(d){
        //console.log(d);
        return "#A254A2";//连接线的颜色
        })
        .attr("marker-end", function(d) { return "url(#" + d.type + ")"; });
        */

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

        //    var edges_text = svg.append("g").selectAll(".edgelabel")
        //        .data(force.links())
        //        .enter()
        //        .append("text")
        //        .style("pointer-events", "none")
        //        //.attr("class","linetext")
        //        .attr({
        //            'class': 'edgelabel',
        //            'id': function (d, i) { return 'edgepath' + i; },
        //            'dx': 55,
        //            'dy': 0
        //            //'font-size':10,
        //            //'fill':'#aaa'
        //        });

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


        //设置线条上的文字
        //     edges_text.append('textPath')
        //     .attr('xlink:href',function(d,i) {return '#edgepath'+i})
        //     .style("pointer-events", "none")
        //     .text(function(d){return d.effect;});


        //    edges_text.attr("x", function (d) { return (d.source.x + d.target.x) / 2; });
        //    edges_text.attr("y", function (d) { return (d.source.y + d.target.y) / 2; });  
        //     edges_text.style("fill-opacity", function (d) {
        //         return '测试一下';
        //     });  



        //圆圈
        //     var circle = svg.append("g").selectAll("rect")
        //        .data(force.nodes())//表示使用force.nodes数据
        //        .enter().append("rect")
        //        .attr({
        //            "width": 100, "height": 40
        //        })
        //        .attr(
        //            "rx", function (node) {
        //                var rx = 0;
        //                if (node.showType == 'ZP') {
        //                    rx = 12.5;
        //                }
        //                else if (node.showType == 'CXT') {
        //                    rx = 0;
        //                }
        //                else {
        //                    rx = 0;
        //                }
        //                return rx
        //            } //水平圆角
        //        )
        //        .attr(
        //            "ry", function (node) {
        //                var rx = 0;
        //                if (node.showType == 'ZP') {
        //                    rx = 12.5;
        //                }
        //                else if (node.showType == 'CXT') {
        //                    rx = 0;
        //                }
        //                else {
        //                    rx = 0;
        //                }
        //                return rx
        //            } //水平圆角
        //        )
        //        .style("fill", function (node) {
        //            var color; //圆圈背景色
        //            var link = links[node.index];
        //            color = "#F9EBF9";
        //            return color;
        //        })
        //        .style('stroke', function (node) {
        //            var color; //圆圈线条的颜色
        //            var link = links[node.index];
        //            if (typeof (link) == undefined) {
        //                if (link.source.name && node.name == link.source.name && link.effect == 1) {
        //                    color = "#B43232";
        //                } else {
        //                    color = "#A254A2";
        //                }
        //            }
        //            return color;
        //        })
        //        .call(force.drag);   //将当前选中的元素传到drag函数中，使顶点可以被拖动

        var drag = force.drag()
                        .on("dragstart", function (d, i) {
                            d.fixed = true;

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
        //        .attr({
        //            "px": 10, "py": 10
        //        })
        //        .attr({
        //            "fixed": true
        //        })

        //.attr("xlink:href", "rect.png")
        .attr(
        "xlink:href", function (node) {
            //node.px = 10;
            //                node.fixed = true;  //这里可以固定，并且设置位置----baoqiang
            //                node.px = 10;
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
        //        .style("fill", function (node) {
        //            var color; //圆圈背景色
        //            var link = links[node.index];
        //            color = "#F9EBF9";
        //            return color;
        //        })
        //        .style('stroke', function (node) {
        //            var color; //圆圈线条的颜色
        //            var link = links[node.index];
        //            if (typeof (link) == undefined) {
        //                if (link.source.name && node.name == link.source.name && link.effect == 1) {
        //                    color = "#B43232";
        //                } else {
        //                    color = "#A254A2";
        //                }
        //            }
        //            return color;
        //        })
        .call(force.drag);         //将当前选中的元素传到drag函数中，使顶点可以被拖动















        /*
        circle.append("text")  
        .attr("dy", ".35em")  
        .attr("text-anchor", "middle")//在圆圈内添加文字  
        .text(function(d) { 
        //console.log(d);
        return d.name; 
        }); */

        //圆圈的提示文字
        circle.append("svg:title")
        .text(function (node) {
            var link = links[node.index];
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

        // .style({
        //     "stroke":"#d99999",
        //     "stroke-width":.5,
        //     "fill":"#f6e8e9"
        // });

        /* 绘制右下角矩形*/
        // var rect1 = svg.append("rect")
        //     .attr({
        //         "x": 400, "y": 360,
        //         "width": 100, "height": 25,
        //         "rx": 0,//水平圆角
        //         "ry": 0//竖直圆角
        //     })
        //     .style({
        //         "stroke": "#d99999",
        //         "stroke-width": .5,
        //         "fill": "#f6e8e9"
        //     });

        // rect1.append("text")
        //     .attr("dy", ".35em")
        //     .attr("text-anchor", "middle")//在圆圈内添加文字  
        //     .attr("fill", "rgb(180, 50, 50)")
        //     .append('tspan')
        //     .text(function (d) {
        //         //console.log(d);
        //         return "yuanjian";
        //     });
        // var rect2 = svg.append("rect")
        //     .attr({
        //         "x": 400, "y": 390,
        //         "width": 100, "height": 25,
        //         "rx": 12.5,//水平圆角
        //         "ry": 12.5//竖直圆角
        //     })
        //     .style({
        //         "stroke": "#d99999",
        //         "stroke-width": .5,
        //         "fill": "#f6e8e9"
        //     });
        // var rect3 = svg.append("rect")
        //     .attr({
        //         "x": 400, "y": 420,
        //         "width": 100, "height": 25,
        //         "rx": 5,//水平圆角
        //         "ry": 10//竖直圆角
        //     })
        //     .style({
        //         "stroke": "#d99999",
        //         "stroke-width": .5,
        //         "fill": "#f6e8e9"
        //     });
        //   rect.append("svg:title")  
        //         .text("qqq");  

        var text = svg.append("g").selectAll("text")
        .data(force.nodes())
        //返回缺失元素的占位对象（placeholder），指向绑定的数据中比选定元素集多出的一部分元素。
        .enter()
        .append("text")
        .attr("dy", ".35em")
        .attr("text-anchor", "middle")//在圆圈中加上数据  
        .style('fill', function (node) {
            var color; //文字颜色
            var link = links[node.index];
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

            // }

            //直接显示文字    
            /*.text(function(d) { 
            return d.name; */
        });

        /*  将文字显示在圆圈的外面 
        var text2 = svg.append("g").selectAll("text")
        .data(force.links())
        //返回缺失元素的占位对象（placeholder），指向绑定的数据中比选定元素集多出的一部分元素。
        .enter()
        .append("text")
        .attr("x", 150)//设置文字坐标
        .attr("y", ".50em")
        .text(function(d) { 
        //console.log(d);
        //return d.name; 
        //return d.effect;
        console.log(d);
        return  '1111';
        });*/
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

        $rootScope.$on("CallParentMethod", function () {
            $scope.aa();
        });
        function aa()
        {
            alert(2);
        }

    });