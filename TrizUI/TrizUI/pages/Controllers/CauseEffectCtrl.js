angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];
        $scope.ComponentRelInfoList = [];
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











    });//end






