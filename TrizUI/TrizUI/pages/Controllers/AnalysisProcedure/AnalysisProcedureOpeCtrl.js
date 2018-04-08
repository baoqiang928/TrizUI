angular.module("myApp")
    .controller('AnalysisProcedureOpeCtrl', function ($scope, $location, requestService, $state, locals, $rootScope, $stateParams) {

        $scope.Option = function () {
            Name: "";
            Value: "";
            Selected: "";
        };
        $scope.CurrentProjectID = locals.get("ProjectID");
        if ($stateParams.ProcedureID == null) $stateParams.ProcedureID = guid();
        $scope.ControlList = [];//决定了显示什么控件
        function ControlInfo() {
            this.ID = "";
            this.ProcedureID = $stateParams.ProcedureID;
            this.SerialNum = "";
            this.ProjectID = locals.get("ProjectID");
            this.TemplateName = "";
            this.DisplayName = "";
            this.Options = [];
            this.Code = "";
            this.RadioValue = "";
            this.InputValueTypeID = "";//标准解 对应的TypeID
            this.InputValue = "";//标准解输入框的输入内容
            this.TypeID = "";//标准解对应的TypeID，过滤树。
        };

        function NeedClearCurrentControl(Code) {
            //目前来说，只有条件判断控件，需要清空，因为会有不同的选择项
            if (Code.indexOf("j") == 0) return true;
            return false;
        }
        $scope.Choose = function (Code) {
            if (NeedClearCurrentControl(Code)) {
                //1 从ControlList当前位置删除后面所有内容
                ClearAfterThatInControlList(GetControlByCode(Code));
                //2 把新值补充到最后
                $scope.ControlList.push(GetControlByCode(Code));
            }
            //3 计算出下一个显示的控件，加入到ControlList里面。
            if (typeof (GetNextControl(Code)) != "undefined")
                $scope.ControlList.push(GetNextControl(Code));
        }

        //2 从ControlList当前位置删除后面所有内容
        function ClearAfterThatInControlList(ControlInfo) {
            var StartDeleteIndex = 999;
            for (var i = 0; i < $scope.ControlList.length; i++) {
                if ($scope.ControlList[i].Code == ControlInfo.Code) {
                    StartDeleteIndex = i;
                }
                if (StartDeleteIndex < 999) {
                    if ($scope.ControlList[i].ID == "") continue;
                    //delete from database.
                    requestService.delete("AnalysisProcedures", $scope.ControlList[i].ID).then(function (data) { });
                }
            }
            $scope.ControlList.splice(StartDeleteIndex, $scope.ControlList.length - StartDeleteIndex + 1);
        }

        //根据值就可找到控件
        function GetControlByCode(Code) {
            //如果j开头，并且是四位，则前两位是控件名称。
            if ((Code.indexOf("j") == 0) && (Code.length == 4)) {
                return CreateRadioCtrl(Code);
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

        function CreateRadioCtrl(RadioValue) {
            Name = RadioValue.substring(0, 2);
            if (Name == "j1") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "需要做的工作";
                ctl.Code = "j1";
                ctl.RadioValue = RadioValue;

                var op = new $scope.Option();
                op.Name = "预测改变的潜力";
                op.Value = "j1c1";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "系统改进";
                op.Value = "j1c2";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "添加检测、测量功能";
                op.Value = "j1c3";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "改变的规模";
                ctl.Code = "j2";
                ctl.RadioValue = RadioValue;

                var op = new $scope.Option();
                op.Name = "超系统和子系统的改变";
                op.Value = "j2c1";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "最小改变";
                op.Value = "j2c2";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j3") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "相互作用";
                ctl.Code = "j3";
                ctl.RadioValue = RadioValue;

                var op = new $scope.Option();
                op.Name = "缺乏";
                op.Value = "j3c1";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "不充分";
                op.Value = "j3c2";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "有害";
                op.Value = "j3c3";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j4") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "充分？";
                ctl.Code = "j4";
                ctl.RadioValue = RadioValue;

                var op = new $scope.Option();
                op.Name = "否";
                op.Value = "j4c1";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "是";
                op.Value = "j4c2";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);

                return ctl;
            }
            if (Name == "j5") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "judge.html";
                ctl.DisplayName = "解充分吗？";
                ctl.Code = "j5";
                ctl.Value = "j5";
                ctl.RadioValue = RadioValue;

                var op = new $scope.Option();
                op.Name = "是/想更好？";
                op.Value = "j5c1";
                op.Selected = RadioValue == op.Value ? "active" : "";
                ctl.Options.push(op);
                op = new $scope.Option();
                op.Name = "否";
                op.Value = "j5c2";
                op.Selected = RadioValue == op.Value ? "active" : "";
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
                ctl.TypeID = "2";
                return ctl;
            }
            if (name == "solution3") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解3";
                ctl.Code = "solution3";
                ctl.InputValue = "";
                ctl.TypeID = "3";
                return ctl;
            }
            if (name == "solution4") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解4";
                ctl.Code = "solution4";
                ctl.InputValue = "";
                ctl.TypeID = "4";
                return ctl;
            }
            if (name == "solution5") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解5";
                ctl.Code = "solution5";
                ctl.InputValue = "";
                ctl.TypeID = "5";
                return ctl;
            }
            if (name == "solution1.1") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1.1";
                ctl.Code = "solution1.1";
                ctl.InputValue = "";
                ctl.TypeID = "11";
                return ctl;
            }
            if (name == "solution1or2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1或2";
                ctl.Code = "solution1or2";
                ctl.InputValue = "";
                ctl.TypeID = "102";
                return ctl;
            }
            if (name == "solution1.2") {
                var ctl = new ControlInfo();
                ctl.TemplateName = "standardsolution.html";
                ctl.DisplayName = "标准解1.2";
                ctl.Code = "solution1.2";
                ctl.InputValue = "";
                ctl.TypeID = "12";
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
            return $scope.ctrls[Code];
        }

        $scope.ProblemShortDesriptionCtrl = new ControlInfo();
        $scope.ProblemShortDesriptionCtrl.DisplayName = "问题的简洁描述";
        function guid() {
            function S4() {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            }
            return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
        }

        $scope.Save = function () {
            for (var i = 0; i < $scope.ControlList.length; i++) {
                $scope.ControlList[i].SerialNum = i;
                $scope.ControlList[i].InputValueTypeID = $scope.ControlList[i].InputValueTypeID.replace("f", "");
                console.log("$scope.ControlList[i]", $scope.ControlList[i]);
                if ($scope.ControlList[i].ID == "") {
                    requestService.add("AnalysisProcedures", $scope.ControlList[i]).then(function (data) { });
                    continue;
                }
                requestService.update("AnalysisProcedures", $scope.ControlList[i]).then(function (data) { });
            }
            requestService.add("AnalysisProcedures", $scope.ProblemShortDesriptionCtrl).then(function (data) { });
            alert('保存完毕。');
            $rootScope.$broadcast("ShareObjectEvent", 1);
        }

        $scope.data = {
            currentPage: "1",
            itemsPerPage: "9999",
            ProjectID: locals.get("ProjectID")
        };



        var GetAnalysisProcedures = function () {
            console.log("$stateParams.ProcedureID", $stateParams.ProcedureID);
            $scope.data.ProcedureID = $stateParams.ProcedureID;
            console.log("$scope.data", $scope.data);
            requestService.lists("AnalysisProcedures", $scope.data).then(function (data) {
                $scope.ControlList = [];
                console.log("data.Results", data.Results);
                for (var i = 0; i < data.Results.length; i++) {
                    var ctl = new ControlInfo();
                    ctl.ID = data.Results[i].ID;
                    ctl.ProjectID = data.Results[i].ProjectID;
                    ctl.SerialNum = data.Results[i].SerialNum;
                    ctl.TemplateName = data.Results[i].TemplateName;
                    ctl.DisplayName = data.Results[i].DisplayName;
                    ctl.Code = data.Results[i].Code;
                    ctl.RadioValue = data.Results[i].RadioValue;
                    ctl.InputValue = data.Results[i].InputValue;
                    ctl.Options = GetOptionsByValue(data.Results[i].RadioValue);
                    if (data.Results[i].DisplayName == "问题的简洁描述") {
                        $scope.ProblemShortDesriptionCtrl = ctl;
                        continue;
                    }
                    $scope.ControlList.push(ctl);
                }
                console.log("$scope.ControlList", $scope.ControlList);
                if ($scope.ControlList.length == 0)
                    $scope.ControlList.push(CreateRadioCtrl("j1", ""));
            });
        }

        GetAnalysisProcedures();
        //$scope.SerialNum = "SerialNum";
        $scope.$on("RefreshMap", function (event, msg) {
            $scope.$broadcast("StartRefreshMap", msg);
        });



        //////////////////////////////////////////////////////////////////
        function GetOptionsByValue(RadioValue) {
            if (RadioValue == "") return;
            return CreateRadioCtrl(RadioValue).Options;
        }


        //树
        $scope.TreeData = [];

        //获取所有叶子节点集合（所有标准解）
        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: $scope.CurrentProjectID,
            Name: "",
            Note: "",
            Remark: "",
            TypeID: ""
        };

        //获取所有叶子节点集合（所有标准解）  End
        $scope.ClearTypeID = function () {
            $scope.data.TypeID = "";
            $scope.TypeName = "";
        };
        $scope.data.TypeID = "";
        $scope.TypeName = "";
        $scope.CurrentObject = "";
        $scope.SelectItem = function (CurrentNode) {
            //$scope.CurrentObject.InputValue = CurrentNode.$modelValue.ID;
            $scope.CurrentObject.InputValue = CurrentNode.$modelValue.title;
            $scope.CurrentObject.InputValueTypeID = CurrentNode.$modelValue.ID;
            //$scope.TypeName = CurrentNode.$modelValue.title;
            $('#modal-table').modal('hide');
        };
        
        $scope.SelectType = function (c) {
            $scope.CurrentObject = c;
            $('#modal-table').modal('show');
        };
        //树 end

    });//end


