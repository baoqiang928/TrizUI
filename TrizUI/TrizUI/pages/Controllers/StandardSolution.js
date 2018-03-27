angular.module("myApp")
    .controller('StandardSolutionCtrl', function ($scope, $location) {
        $scope.aaa = false;
        $scope.bbb = false;
        $scope.bbb = true;

        $scope.data = [
            {
                fieldTypeId: 2,
                title: 'first name'
            },
            {
                fieldTypeId: 1,
                title: 'this is text area'
            }
        ];

        $scope.aaa = function () {
            var a = {};
            a.fieldTypeId = 2;
            a.title = "asdfadsf";
            $scope.data.push(a);
        }
        $scope.bbb = function () {
            alert(1);
        }
        //////////////////////////////////////////////////////////////////

        ClearAndHide("改变的规则|物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");

        $scope.Query = function () {
            alert('Query');
            //$location.path("/AddProject");
        }

        $scope.toggle = function () {
            alert(1);
            $scope.visible = !$scope.visible;
        }

        ////////////////////
        //change profile
        $('[data-toggle="buttons"] .btn').on('click', function (e) {

            var target = $(this).find('input[type=radio]');
            var which = target.val();

            alert(which);


            //1 预测改变的潜力  
            if (which == "10") {
                ClearAndHide("改变的规则|物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("改变的规则");
            }

            //1.1 预测改变的潜力 - 超系统或子系统的改变(改变的规则)
            if (which == "101") {
                ClearAndHide("物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                Display("方案是否有效1");
                SetSolution("标准解1:第3类标准解");
            }

            //1.1.1 预测改变的潜力 - 超系统或子系统的改变(改变的规则) - 有效
            if (IsSelected("预测改变的潜力") && IsSelected("超系统或子系统的改变") && (which == "valid1")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第5类标准解");
            }

            //1.1.2 预测改变的潜力 - 超系统或子系统的改变(改变的规则) - 无效
            if (IsSelected("预测改变的潜力") && IsSelected("超系统或子系统的改变") && (which == "invalid1")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解2|方案是否有效2|标准解3|方案是否有效3");
            }


            //1.2 预测改变的潜力 - 最小改变(改变的规则)
            if (which == "102") {
                ClearAndHide("物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                Display("方案是否有效1");
                SetSolution("标准解1:第2类标准解");
            }

            //1.2.1 预测改变的潜力 - 最小改变(改变的规则) - 第2类标准解 有效
            if (IsSelected("预测改变的潜力") && IsSelected("最小改变") && (which == "valid1")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第5类标准解");
            }

            //1.2.2 预测改变的潜力 - 最小改变(改变的规则) - 第2类标准解 无效
            if (IsSelected("预测改变的潜力") && IsSelected("最小改变") && (which == "invalid1")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第3类标准解");
            }

            //1.2.2.1 预测改变的潜力 - 最小改变(改变的规则) - 第2类标准解 无效 - 第3类标准解
            if (IsSelected("预测改变的潜力") && IsSelected("最小改变") && IsSelected("labelinvalid1") && (which == "valid2")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解3|方案是否有效3");
                SetSolution("标准解2:第5类标准解");
            }

            //1.2.2.2 预测改变的潜力 - 最小改变(改变的规则) - 第3类标准解 无效
            if (IsSelected("预测改变的潜力") && IsSelected("最小改变") && (which == "invalid2")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解3|方案是否有效3");
            }


            //3 添加检测、测量功能  
            if (which == "12") {
                ClearAndHide("改变的规则|物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                SetSolution("标准解1:第4类标准解");

                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第3类标准解");
            }

            //3.1 添加检测、测量功能 -  第3类标准解 有效
            if (IsSelected("添加检测测量功能") && (which == "valid2")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解3|方案是否有效3");
                Display("标准解3");
                Display("方案是否有效3");
                SetSolution("标准解3:第5类标准解");
            }

            //3.2 添加检测、测量功能 -  第3类标准解 无效
            if (IsSelected("添加检测测量功能") && (which == "invalid2")) {
                ClearAndHide("物质-场模型|相互作用类型|标准解3|方案是否有效3");
            }


            //2 系统改进  
            if (which == "11") {
                ClearAndHide("改变的规则|物质-场模型|相互作用类型|标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("物质-场模型");
                Display("相互作用类型");
            }

            //2.1 系统改进 - 缺乏     
            if (which == "211") {
                ClearAndHide("标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                SetSolution("标准解1:第1.1类标准解");

                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第3类标准解");
            }

            ////2.1.1 系统改进 - 缺乏  -  有效  
            if (IsSelected("系统改进") && IsSelected("缺乏") && (which == "valid2")) {
                ClearAndHide("标准解3|方案是否有效3");

                Display("标准解3");
                Display("方案是否有效3");
                SetSolution("标准解3:第5类标准解");
            }

            ////2.1.2 系统改进 - 缺乏  -  无效  
            if (IsSelected("系统改进") && IsSelected("缺乏") && (which == "invalid2")) {
                ClearAndHide("标准解3|方案是否有效3");
            }



            //2.2 系统改进 - 有害       
            if (which == "212") {
                ClearAndHide("标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                SetSolution("标准解1:第1.2类标准解");

                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第3类标准解");
            }

            ////2.2.1 系统改进 - 有害  -  有效  
            if (IsSelected("系统改进") && IsSelected("有害") && (which == "valid2")) {
                ClearAndHide("标准解3|方案是否有效3");

                Display("标准解3");
                Display("方案是否有效3");
                SetSolution("标准解3:第5类标准解");
            }

            ////2.2.2 系统改进 - 有害  -  无效  
            if (IsSelected("系统改进") && IsSelected("有害") && (which == "invalid2")) {
                ClearAndHide("标准解3|方案是否有效3");
            }





            //2.3 系统改进 - 不充分        
            if (which == "213") {
                ClearAndHide("标准解1|方案是否有效1|标准解2|方案是否有效2|标准解3|方案是否有效3");
                Display("标准解1");
                SetSolution("标准解1:第1或2类标准解");

                Display("标准解2");
                Display("方案是否有效2");
                SetSolution("标准解2:第3类标准解");
            }

            ////2.3.1 系统改进 - 不充分  -  有效  
            if (IsSelected("系统改进") && IsSelected("不充分") && (which == "valid2")) {
                ClearAndHide("标准解3|方案是否有效3");

                Display("标准解3");
                Display("方案是否有效3");
                SetSolution("标准解3:第5类标准解");
            }

            ////2.3.2 系统改进 - 不充分  -  无效  
            if (IsSelected("系统改进") && IsSelected("不充分") && (which == "invalid2")) {
                ClearAndHide("标准解3|方案是否有效3");
            }





            ////$("div[id^=Option]").addClass('hide');
            ////alert(which);
            //if (which == "10") {
            //    $("div[id^=Option10]").removeClass('hide');
            //    //隱藏其他的
            //    $("div[id^=Option11]").addClass('hide');
            //    $("div[id^=Option12]").addClass('hide');
            //    $("div[id^=Option13]").addClass('hide');
            //}

            //if (which == "101") {
            //    $("div[id^=StandardSolution1]").removeClass('hide');
            //    $("label[id^=DisplayLabel1]").html("第3类标准解");
            //    //顯示 方案是否有效
            //    $("div[id^=SolutionWork1]").removeClass('hide');
            //    //HideBehindControls(which);
            //}

            ////第一個方案 
            ////無效
            //if (which == "invalid1") {
            //    //预测改变的潜力(label1) - 超系统或子系统的改变(label4) - 第3类标准解(DisplayLabel1) - 無效 - end
            //    if ($("label[id=label1]").attr('class').indexOf("active") > 0) {
            //        if ($("label[id=label4]").attr('class').indexOf("active") > 0) {
            //            $("div[id^=StandardSolution2]").addClass('hide');
            //            $("div[id^=SolutionWork2]").addClass('hide');
            //            return;
            //        }
            //    }
            //}
            ////有效
            //if (which == "valid1") {
            //    //预测改变的潜力(label1) - 超系统或子系统的改变(label4) - 第3类标准解(DisplayLabel1) - 有效 - 第5类标准解(DisplayLabel2)
            //    if ($("label[id=label1]").attr('class').indexOf("active") > 0) {
            //        if ($("label[id=label4]").attr('class').indexOf("active") > 0) {
            //            $("label[id^=DisplayLabel2]").html("第5类标准解");
            //            $("div[id^=StandardSolution2]").removeClass('hide');
            //            $("div[id^=SolutionWork2]").removeClass('hide');
            //            return;
            //        }
            //    }
            //}




            //if (which == "102") {
            //    $("div[id^=StandardSolution1]").removeClass('hide');
            //    $("label[id^=DisplayLabel1]").html("第2类标准解");
            //    //HideBehindControls(which);
            //}

            //$('.user-profile').parent().addClass('hide');
            //$('#user-profile-' + which).parent().removeClass('hide');
        });


        function ConvertNameStrToID(v) {
            if (v == "改变的规则") return "Option10";
            if (v == "标准解1") return "StandardSolution1";
            if (v == "方案是否有效1") return "SolutionIsValid1";
            if (v == "标准解2") return "StandardSolution2";
            if (v == "方案是否有效2") return "SolutionIsValid2";
            if (v == "标准解3") return "StandardSolution3";
            if (v == "方案是否有效3") return "SolutionIsValid3";
            if (v == "物质-场模型") return "Option20";
            if (v == "相互作用类型") return "Option21";


            if (v == "预测改变的潜力") return "label1";
            if (v == "系统改进") return "label2";
            if (v == "添加检测测量功能") return "label3";

            if (v == "超系统或子系统的改变") return "label4";
            if (v == "最小改变") return "label5";

            if (v == "缺乏") return "label7";
            if (v == "有害") return "label8";
            if (v == "不充分") return "label9";

            return v;
        }

        function ClearAndHide(v) {
            var scores = v.split("|");
            var arrLength = scores.length;
            var sum = 0;
            var average = null;
            for (var i = 0; i < arrLength; i++) {
                v = scores[i];
                //alert(ConvertNameStrToID(v));
                $('div[id=' + ConvertNameStrToID(v) + ']').addClass('hide');
                //alert($('div[id=' + ConvertNameStrToID(v) + ']').children());
                //$('div[id=' + ConvertNameStrToID(v) + ']').children("label").removeClass('active');
                //alert(ConvertNameStrToID(v));
                $('div[id=' + ConvertNameStrToID(v) + ']').find("label").each(function () {
                    //alert($(this).attr("class"));
                    $(this).removeClass('active');
                });
            }
        }

        function Display(v) {
            var scores = v.split("|");
            var arrLength = scores.length;
            var sum = 0;
            var average = null;
            for (var i = 0; i < arrLength; i++) {
                v = scores[i];
                $('div[id=' + ConvertNameStrToID(v) + ']').removeClass('hide');
            }
        }

        function SetSolution(v) {
            var scores = v.split(":");
            //alert(ConvertNameStrToID(scores[0]));
            //$("label[id^=" + ConvertNameStrToID(scores[0]) + "]").html(scores[1]);
            $("div[id=" + ConvertNameStrToID(scores[0]) + "]").children("label").html(scores[1]);
        }

        function IsSelected(v) {
            if ($("label[id=" + ConvertNameStrToID(v) + "]").attr('class').indexOf("active") > 0) {
                return true;
            }
            return false;
        }

    });


