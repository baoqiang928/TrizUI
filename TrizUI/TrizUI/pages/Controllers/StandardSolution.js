﻿angular.module("myApp")
    .controller('StandardSolutionCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.aaa = false;
        $scope.bbb = false;
        $scope.bbb = true;

        $scope.Option = function () {
            Name: "";
            Value: "";
            Selected: "";
        };

        $scope.ControlList = [];//决定了显示什么控件
        function ControlInfo() {
            this.ID = "";
            this.SerialNum = "";
            this.ProjectID = locals.get("ProjectID");
            this.TemplateName = "";
            this.DisplayName = "";
            this.Options = [];
            this.Code = "";
            this.RadioValue = "";
            this.InputValue = "";//标准解输入框的输入内容
        };

        $scope.ControlList.push(CreateRadioCtrl("j1", ""));

        $scope.NextStep = function () {
            console.log("$scope.ControlList", $scope.ControlList);
        }
        $scope.ControlCodeList = [];//已选控件值路径

        $scope.Choose = function (Code) {
            ////1 从ControlCodeList当前位置截断后面的所有内容
            //ClearAfterThatInControlCodeList(Code);
            //console.log("ClearAfterThatInControlCodeList-ControlCodeList", $scope.ControlCodeList);
            //2 从ControlList当前位置删除后面所有内容
            ClearAfterThatInControlList(GetControlByCode(Code));
            console.log("ClearAfterThatInControlList-ControlList", $scope.ControlList);
            //3 把新值补充到最后
            $scope.ControlList.push(GetControlByCode(Code));
            console.log("$scope.ControlList.push", $scope.ControlList);
            //$scope.ControlCodeList.push(Code);
            //console.log("$scope.ControlCodeList.push", $scope.ControlCodeList);
            //4 计算出下一个显示的控件，加入到ControlList里面。
            $scope.ControlList.push(GetNextControl(Code));
            console.log("$scope.ControlList", $scope.ControlList);

        }

        //2 从ControlList当前位置删除后面所有内容
        function ClearAfterThatInControlList(ControlInfo) {
            for (var i = 0; i < $scope.ControlList.length; i++) {
                if ($scope.ControlList[i].Code == ControlInfo.Code) {
                    $scope.ControlList.splice(i, $scope.ControlList.length - i + 1);
                    return;
                }
            }
        }

        //根据值就可找到控件
        function GetControlByCode(Code) {
            //如果j开头，并且是四位，则前两位是控件名称。
            if ((Code.indexOf("j") == 0) && (Code.length == 4)) {
                return CreateRadioCtrl(Code.substring(0, 2), Code);
            }
            return CreateCtrl(Code);
        }

        $scope.ctrls = {};
        INI();
        function INI() {

            $scope.ctrls["solution1.1"] = CreateCtrl("solution3");

            $scope.ctrls["solution1.2"] = CreateCtrl("solution3");

            $scope.ctrls["solution1or2"] = CreateCtrl("solution3");

            $scope.ctrls["solution2"] = CreateRadioCtrl("j4");

            $scope.ctrls["solution3"] = CreateRadioCtrl("j5");

            $scope.ctrls["solution4"] = CreateCtrl("solution3");


            $scope.ctrls["j1c1"] = CreateRadioCtrl("j2");
            $scope.ctrls["j1c2"] = CreateCtrl("model");
            $scope.ctrls["j1c3"] = CreateCtrl("solution4");

            $scope.ctrls["j2c1"] = CreateCtrl("solution3");
            $scope.ctrls["j2c2"] = CreateCtrl("solution2");

            $scope.ctrls["j3c1"] = CreateCtrl("solution1.1");
            $scope.ctrls["j3c2"] = CreateCtrl("solution1or2");
            $scope.ctrls["j3c3"] = CreateCtrl("solution1.2");

            $scope.ctrls["j4c1"] = CreateCtrl("solution3");
            $scope.ctrls["j4c2"] = CreateRadioCtrl("j5");

            $scope.ctrls["j5c1"] = CreateCtrl("solution5");

            $scope.ctrls["model"] = CreateRadioCtrl("j3");


        }

        function CreateRadioCtrl(Name, Code) {
            if (Name == "j1") {
                var ctl = new ControlInfo();
                console.log("ctl", ctl);
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "需要做的工作";
                ctl.Code = "j1";
                ctl.RadioValue = Code;

                var op = new $scope.Option();
                op.Name = "预测改变的潜力";
                op.Value = "j1c1";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "系统改进";
                op.Value = "j1c2";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "添加检测、测量功能";
                op.Value = "j1c3";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);

                console.log("ctl", ctl);
                return ctl;
            }
            if (Name == "j2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "改变的规模";
                ctl.Code = "j2";
                ctl.RadioValue = Code;

                var op = new $scope.Option();
                op.Name = "超系统和子系统的改变";
                op.Value = "j2c1";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "最小改变";
                op.Value = "j2c2";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j3") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "相互作用";
                ctl.Code = "j3";
                ctl.RadioValue = Code;

                var op = new $scope.Option();
                op.Name = "缺乏";
                op.Value = "j3c1";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "不充分";
                op.Value = "j3c2";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "有害";
                op.Value = "j3c3";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j4") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "充分？";
                ctl.Code = "j4";
                ctl.RadioValue = Code;

                var op = new $scope.Option();
                op.Name = "否";
                op.Value = "j4c1";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "是";
                op.Value = "j4c2";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j5") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "解充分吗？";
                ctl.Code = "j5";
                ctl.Value = "j5";
                ctl.RadioValue = Code;

                var op = new $scope.Option();
                op.Name = "是/想更好？";
                op.Value = "j5c1";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "否";
                op.Value = "j5c2";
                op.Selected = Code == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
        }

        function CreateCtrl(name) {
            if (name == "solution2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解2";
                ctl.Code = "solution2";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution3") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解3";
                ctl.Code = "solution3";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution4") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解4";
                ctl.Code = "solution4";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution5") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解5";
                ctl.Code = "solution5";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution1.1") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1.1";
                ctl.Code = "solution1.1";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution1or2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1或2";
                ctl.Code = "solution1or2";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "solution1.2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1.2";
                ctl.Code = "solution1.2";
                ctl.InputValue = "";
                return ctl;
            }
            if (name == "model") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "model.html";
                ctl.DisplayName = "物质-场模型";
                ctl.Code = "model";
                ctl.InputValue = "";
                return ctl;
            }



        }

        function GetNextControl(Code) {
            console.log("$scope.ctrls", $scope.ctrls);
            return $scope.ctrls[Code];
        }


        $scope.Save = function () {
            for (var i = 0; i < $scope.ControlList.length; i++) {
                $scope.ControlList[i].SerialNum = i;
                if ($scope.ControlList[i].ID == "") {
                    requestService.add("AnalysisProcedures", $scope.ControlList[i]).then(function (data) { });
                    continue;
                }
                requestService.update("AnalysisProcedures", $scope.ControlList[i]).then(function (data) { });
            }
            alert('保存完毕。');
        }


        $scope.data = {
            currentPage: "1",
            itemsPerPage: "9999",
            ProjectID: locals.get("ProjectID")
        };

        var GetAnalysisProcedures = function () {
            requestService.lists("AnalysisProcedures", $scope.data).then(function (data) {
                console.log("data.Results", data.Results);
            });
        }

        GetAnalysisProcedures();
        //////////////////////////////////////////////////////////////////


    });//end


