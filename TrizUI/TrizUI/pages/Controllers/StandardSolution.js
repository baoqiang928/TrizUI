angular.module("myApp")
    .controller('StandardSolutionCtrl', function ($scope, $location) {

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




















            //$("div[id^=Option]").addClass('hide');
            //alert(which);
            if (which == "10")
            {
                $("div[id^=Option10]").removeClass('hide');
                //隱藏其他的
                $("div[id^=Option11]").addClass('hide');
                $("div[id^=Option12]").addClass('hide');
                $("div[id^=Option13]").addClass('hide');
            }
            
            if (which == "101") {
                $("div[id^=StandardSolution1]").removeClass('hide');
                $("label[id^=DisplayLabel1]").html("第3类标准解");
                //顯示 方案是否有效
                $("div[id^=SolutionWork1]").removeClass('hide');
                //HideBehindControls(which);
            }

            //第一個方案 
            //無效
            if (which == "invalid1") {
                //预测改变的潜力(label1) - 超系统或子系统的改变(label4) - 第3类标准解(DisplayLabel1) - 無效 - end
                if($("label[id=label1]").attr('class').indexOf("active")>0)
                {
                    if ($("label[id=label4]").attr('class').indexOf("active") > 0) {
                        $("div[id^=StandardSolution2]").addClass('hide');
                        $("div[id^=SolutionWork2]").addClass('hide');
                        return;
                    }
                }
            }
            //有效
            if (which == "valid1") {
                //预测改变的潜力(label1) - 超系统或子系统的改变(label4) - 第3类标准解(DisplayLabel1) - 有效 - 第5类标准解(DisplayLabel2)
                if ($("label[id=label1]").attr('class').indexOf("active") > 0) {
                    if ($("label[id=label4]").attr('class').indexOf("active") > 0) {
                        $("label[id^=DisplayLabel2]").html("第5类标准解");
                        $("div[id^=StandardSolution2]").removeClass('hide');
                        $("div[id^=SolutionWork2]").removeClass('hide');
                        return;
                    }
                }
            }




            if (which == "102") {
                $("div[id^=StandardSolution1]").removeClass('hide');
                $("label[id^=DisplayLabel1]").html("第2类标准解");
                //HideBehindControls(which);
            }

            //$('.user-profile').parent().addClass('hide');
            //$('#user-profile-' + which).parent().removeClass('hide');
        });

    });