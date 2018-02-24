angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.aaa = "";
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];

        $scope.SrcComponentInfo = function () {
            this.ID = "";
            this.Name = "";
        }
        $scope.SrcComponentInfoList = [];

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
            this.ComponentName = "";
            this.ParamName = "";
            this.ParamType = "";
            this.Disabled = "";
        }

        $scope.ComponentParamInfoList = [];

        var newobj = new $scope.ComponentParamInfo();

        $scope.ComponentParamInfoList.push(newobj);

        $scope.AddComponentParamInfo = function () {
            var newobj1 = new $scope.ComponentParamInfo();
            $scope.ComponentParamInfoList.push(newobj1);
        }

        $scope.DeleteComponentParamInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    $scope.ComponentParamInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        //End

        //功能参数列表
        $scope.ComponentRelInfo = function () {
            this.ComponentID = "";//问题相关元件
            this.ComponentName = "";//元件特征参数
            this.ComponentParammName = "";//影响该参数元件
            this.ImpactComponentName = "";//元件特征参数
            this.ImpactParammName = "";//参数类型
            this.ParamType = "";
            this.Disabled = "";
            this.abcd = "";
        }

        $scope.ComponentRelInfoList = [];
        $scope.ComponentRelInfoListSection = [];

        $scope.SaveComponentParamInfoOperate = function () {
            $scope.ClearComponentRelInfoListAndSection();
            $scope.InsertComponentToRelInfoList();
            $scope.InsertComponentRelInfoListToSection();
        }

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

        //End


        $scope.aaa = function () {
            console.log("aaa", $scope.ComponentParamInfoList);
        };














    });//end

var person = {
    name: "dongjc",
    age: 32,
    Introduce: function () { alert("My name is " + this.name + ".I'm " + this.age); }
};


//var ComponentParamInfo = {
//    ComponentName : "",
//    ParamName: "",
//    ParamType: "",
//    Disabled: ""
//}

//function ComponentParamInfo() {
//    this.ComponentName = "";
//    this.ParamName = "";
//    this.ParamType = "";
//    this.Disabled = "";
//}

//ComponentParamInfo
//function fffInfo() {
//}
//fffInfo.prototype.ComponentName = "1";
//fffInfo.prototype.ParamName = "2";
//fffInfo.prototype.ParamType = "3";
//fffInfo.prototype.Disabled = "";
////ComponentParamInfo.prototype.sayName = function () {
////    alert(this.name);
////};



//function ComponentRelInfo() {
//}

//ComponentRelInfo.prototype.ComponentID = "";//问题相关元件
//ComponentRelInfo.prototype.ComponentName = "";//元件特征参数
//ComponentRelInfo.prototype.ComponentParammName = "";//影响该参数元件
//ComponentRelInfo.prototype.ImpactComponentName = "";//元件特征参数
//ComponentRelInfo.prototype.ImpactParammName = "";//参数类型
//ComponentRelInfo.prototype.ParamType = "";
//ComponentRelInfo.prototype.Disabled = "";
//ComponentRelInfo.prototype.abcd = "";





