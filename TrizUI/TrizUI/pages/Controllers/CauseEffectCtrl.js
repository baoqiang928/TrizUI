angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];
        $scope.ComponentRelInfoListSection = [];
        $scope.SrcComponentInfo = function () {
            this.ID = "";
            this.Name = "";
        }
        $scope.SrcComponentInfoList = [];

        $scope.ConflictInfo = function () {
            ID: "";
            ProjectID: $scope.CurrentProjectID;  //ID
            RelComponentName: "";
            RelComponentParamName: "";
            CurrentConfig: "";
            ChangeConfig: "";
            CurrentProblem: "";
            NewProblem: "";
            Visible: "True";
        }
        $scope.ConflictInfoList = [];



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
        $scope.RelListFromPreSection = [];

        //End

        //功能参数列表
        $scope.ComponentRelInfo = function () {
            this.SectionID = "";
            this.ProjectID = $scope.CurrentProjectID;
            this.ComponentID = "";//问题相关元件
            this.ComponentParamName = "";//元件特征参数
            this.ImpactComponentName = "";//影响该参数元件
            this.ImpactParamName = "";//参数类型
            this.ParamType = "独立变量";
            this.Disabled = "";
        }

        $scope.data = {
            ProjectID: locals.get("ProjectID"),
            ProblemDescription: "",
            AltinativeProblem: "",
            TechConflict: "",
            PhyConflict: ""
        };
        
        $scope.SaveCurrentProblemDes = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}
            console.log("data", data);
            requestService.add("CauseEffectCurProblems", data).then(function (data) { });
            return;
        };

    });//end