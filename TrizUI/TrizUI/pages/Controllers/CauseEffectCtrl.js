angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.PreSectionComponentList = "";
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];
        $scope.ComponentRelInfoList = [];
        $scope.ComponentRelInfoListSection = [];
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
            this.ParamType = "独立变量";
            this.Disabled = "";
        }

        $scope.ComponentParamInfoList = [];

        var newobj = new $scope.ComponentParamInfo();

        $scope.ComponentParamInfoList.push(newobj);

        $scope.AddComponentParamInfo = function () {
            var newobj1 = new $scope.ComponentParamInfo();
            $scope.ComponentParamInfoList.push(newobj1);
        }

        var RelListFromPreSection = [];
        $scope.SaveComponentParamInfoOperate = function () {
            $scope.ClearComponentRelInfoListAndSection();
            $scope.InsertComponentToRelInfoList();
            $scope.InsertComponentRelInfoListToSection();

            for (var j = 0; j < $scope.ComponentParamInfoList.length; j++) {
                if ($scope.ComponentParamInfoList[j].ParamType == "非独立变量")
                {
                    var componentRelInfo = new $scope.ComponentRelInfo();
                    componentRelInfo.ImpactComponentName = $scope.ComponentParamInfoList[j].ComponentName;
                    componentRelInfo.ImpactParamName = $scope.ComponentParamInfoList[j].ParamName;
                    componentRelInfo.ParamType = $scope.ComponentParamInfoList[j].ParamType;
                    RelListFromPreSection.push(componentRelInfo);
                }
            }
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
            this.ImpactComponentName = "";//影响该参数元件
            this.ImpactParamName = "";//参数类型
            this.ParamType = "独立变量";
            this.Disabled = "";
        }

       
        $scope.ADDRelOperate = function (i) {
            var componentRelInfo1 = new $scope.ComponentRelInfo();
            $scope.ComponentRelInfoListSection[i].push(componentRelInfo1);
        };

        $scope.SaveRelOperate = function (i) {
            //disabled
            console.log("i", i);
            console.log("$scope.ComponentRelInfoListSection", $scope.ComponentRelInfoListSection);
            $scope.SetDisabledBySectionIndex(i);

            var ComponentRelInfoList1 = [];
            ComponentRelInfoList1.push(new $scope.ComponentParamInfo());
            $scope.ComponentRelInfoListSection.push(ComponentRelInfoList1);
        };

        $scope.PreSectionComponentList = function (i) {
            if (i == 0)
            {               
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
//ComponentRelInfo.prototype.ComponentParamName = "";//影响该参数元件
//ComponentRelInfo.prototype.ImpactComponentName = "";//元件特征参数
//ComponentRelInfo.prototype.ImpactParamName = "";//参数类型
//ComponentRelInfo.prototype.ParamType = "";
//ComponentRelInfo.prototype.Disabled = "";





