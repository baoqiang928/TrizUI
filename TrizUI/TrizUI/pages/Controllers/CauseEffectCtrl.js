//function ComponentParamInfo() {
//    this.ComponentName = "";
//    this.ParamName = "";
//    this.ParamType = "";
//    this.Disabled = "";
//}


angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {

        $scope.ComponentParamInfo = function () {
            this.ComponentName = "";
            this.ParamName = "";
            this.ParamType = "";
            this.Disabled = ""
        }

        $scope.ComponentParamInfoList = [];

        var newobj = new $scope.ComponentParamInfo();
        $scope.ComponentParamInfoList.push(newobj);

        $scope.AddComponentParamInfo = function () {
            var newobj = new $scope.ComponentParamInfo();
            $scope.ComponentParamInfoList.push(newobj);
        }

        $scope.DeleteComponentParamInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    $scope.ComponentParamInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }



















        $scope.Sources = "FunEleMutualReacts";
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];

        ini();
        $scope.ComponentRelInfoList = ComponentRelInfoList;
        $scope.ComponentRelInfoListSection = ComponentRelInfoListSection;

        var users = [{ name: 'Hank' }, { name: 'Francisco' }];
        $scope.yyy = [{ name: '11' }, { name: '222' }];
        //var a = {
        //    name: 'bbb'
        //};
        var users1 = [];
        users1.push(users);
        $scope.getUsers = function (i) {
            //users.push(a);
            console.log("i", i);
            return users1[i];
        };

        $scope.GetPrevComponentParamNames = function (a) {
            alert(a);
        }
        $scope.bbb = function () {
            $scope.yyy.push({ name: '333' });
            console.log("yyy", $scope.yyy);
        }
        $scope.test = function () {
            users = [{ name: 'aaa' }, { name: 'bbb' }];
        }

        $scope.aalist = [];
        $scope.RelInfo = new ComponentRelInfo();
        $scope.GetPrevComponentNames = function () {


            //var RelInfo = new ComponentRelInfo();
            $scope.RelInfo.ComponentID = 1;//问题相关元件
            $scope.RelInfo.ComponentName = "导向架";//问题相关元件
            $scope.RelInfo.ComponentParamName = "移动速度";//元件特征参数
            $scope.RelInfo.ImpactParamComponentName = "";//影响该参数元件
            $scope.RelInfo.ImpactParamName = "";//元件特征参数
            $scope.RelInfo.ParamType = "非独立变量";//参数类型
            $scope.Disabled = false;//是否禁止编辑

            //var aalist = [];
            $scope.aalist.push($scope.RelInfo);

            //var RelInfo1 = new ComponentRelInfo();
            //RelInfo1.ComponentID = 1;//问题相关元件
            //RelInfo1.ComponentName = "电机";//问题相关元件
            //RelInfo1.ComponentParamName = "转速";//元件特征参数
            //RelInfo1.ImpactParamComponentName = "";//影响该参数元件
            //RelInfo1.ImpactParamName = "";//元件特征参数
            //RelInfo1.ParamType = "非独立变量";//参数类型
            //RelInfo1.Disabled = false;//是否禁止编辑
            //aalist.push(RelInfo1);

            return $scope.aalist;
        }


        $scope.GetPrevComponentParamNames = function (name) {
            //var RelInfo = new ComponentRelInfo();
            //RelInfo.ComponentID = 1;//问题相关元件
            //RelInfo.ComponentName = "导向架";//问题相关元件
            //RelInfo.ComponentParamName = "移动速度";//元件特征参数
            //RelInfo.ImpactParamComponentName = "";//影响该参数元件
            //RelInfo.ImpactParamName = "";//元件特征参数
            //RelInfo.ParamType = "非独立变量";//参数类型
            //RelInfo.Disabled = false;//是否禁止编辑

            //var aalist = [];
            //aalist.push(RelInfo);

            //var RelInfo1 = new ComponentRelInfo();
            //RelInfo1.ComponentID = 1;//问题相关元件
            //RelInfo1.ComponentName = "电机";//问题相关元件
            //RelInfo1.ComponentParamName = "转速";//元件特征参数
            //RelInfo1.ImpactParamComponentName = "";//影响该参数元件
            //RelInfo1.ImpactParamName = "";//元件特征参数
            //RelInfo1.ParamType = "非独立变量";//参数类型
            //RelInfo1.Disabled = false;//是否禁止编辑
            //aalist.push(RelInfo1);

            //for (var i = 0; i < aalist.length; i++) {
            //    if (aalist[i].ComponentName == name)
            //        return aalist[i];
            //}
            //return;
        }


        //增加并列功能参数
        $scope.AddNewComponentRel = function (SectionIndex, index, ComponentID, ComponentName, ComponentParam) {
            var RelInfo = new ComponentRelInfo();
            RelInfo.ComponentID = ComponentID;//问题相关元件
            RelInfo.ComponentName = ComponentName;//问题相关元件
            RelInfo.ComponentParamName = ComponentParam;//元件特征参数
            RelInfo.ImpactParamComponentName = "";//影响该参数元件
            RelInfo.ImpactParamName = "";//元件特征参数
            RelInfo.ParamType = "独立变量";//参数类型
            RelInfo.Disabled = false;//是否禁止编辑

            $scope.ComponentRelInfoListSection[SectionIndex].splice(index + 1, 0, RelInfo);
        }

        //删除按钮事件
        $scope.DeleteComponentRel = function (SectionIndex, index) {
            $scope.ComponentRelInfoListSection[SectionIndex].splice(index, 1);
        }

        //$scope.ImpactElementTypeChange = function (CurrentSectionIndex, ImpactElementType, ImpactElementID, ImpactElementName, ImpactElementParam) {
        //    if (ImpactElementType == "非独立变量") {
        //        $scope.AddDependentParam(CurrentSectionIndex, ImpactElementID, ImpactElementName, ImpactElementParam);
        //    }
        //    else {
        //        DeleteOtherImpactRelInFollowSections(CurrentSectionIndex, ImpactElementName);
        //    }
        //}

        //$scope.DisabledInput = function (ImpactElementType) {
        //    if (ImpactElementType == "非独立变量") {
        //        return true;
        //    }
        //    return false;
        //}

        //$scope.ModifyImpactElementParamInOtherSection = function (CurSectionIndex, ImpactElementType, ImpactElementName, ImpactElementParam) {
        //    if (ImpactElementType == "非独立变量") {
        //        var i = CurSectionIndex + 1;
        //        for (var j = 0; j < $scope.FunctionImpactRelSectionList[i].length; j++) {
        //            if ($scope.FunctionImpactRelSectionList[i] == null) continue;
        //            if ($scope.FunctionImpactRelSectionList[i][j] == null) continue;
        //            if ($scope.FunctionImpactRelSectionList[i][j].ProblemElementName == ImpactElementName) {
        //                $scope.FunctionImpactRelSectionList[i][j].ProblemElementParam = ImpactElementParam;
        //            }
        //        }
        //    }
        //}
        ////增加一个非独立变量，会自动增加一组参数列表，并在下一个参数列表增加一行
        //$scope.AddDependentParam = function (CurrentSectionIndex, ElementID, ElementName, ElementParam) {

        //    $scope.FunctionImpactRelInfo = {
        //        ID: "",
        //        ProblemElementID: ElementID,
        //        ProblemElementName: ElementName,//问题相关元件
        //        ProblemElementParam: ElementParam,//元件特征参数
        //        ImpactElementID: "",//影响该参数元件ID
        //        ImpactElementName: "",//影响该参数元件
        //        ImpactElementParam: "",//元件特征参数
        //        ImpactElementType: "独立变量"//参数类型
        //    }

        //    //如果不存在组参数列表，则增加。
        //    var NextSectionIndex = CurrentSectionIndex + 1;

        //    if ($scope.FunctionImpactRelSectionList.length >= (NextSectionIndex + 1)) {
        //        $scope.FunctionImpactRelSectionList[NextSectionIndex].push($scope.FunctionImpactRelInfo);
        //        return;
        //    }
        //    AddNewSection(NextSectionIndex);
        //};

        ////增加新的 功能参数列表 
        //function AddNewSection(SectionIndex) {
        //    eval("$scope.FunctionImpactRelList" + SectionIndex + "= [];");
        //    eval("$scope.FunctionImpactRelList" + SectionIndex + ".push($scope.FunctionImpactRelInfo);");
        //    eval("$scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList" + SectionIndex + ");");
        //}



        ////增加并列功能参数
        //$scope.AddBrother = function (SectionIndex, index, ElementID, ElementName, ElementParam) {
        //    $scope.FunctionImpactRelInfo = {
        //        ID: "",
        //        ProblemElementID: ElementID,
        //        ProblemElementName: ElementName,//问题相关元件
        //        ProblemElementParam: ElementParam,//元件特征参数
        //        ImpactElementID: "",//影响该参数元件ID
        //        ImpactElementName: "",//影响该参数元件
        //        ImpactElementParam: "",//元件特征参数
        //        ImpactElementType: "独立变量"//参数类型
        //    }
        //    $scope.FunctionImpactRelSectionList[SectionIndex].splice(index + 1, 0, $scope.FunctionImpactRelInfo);
        //}

        ////删除其他的相关的作用关系
        //function DeleteOtherImpactRelInFollowSections(SectionIndex, ImpactElementName) {
        //    for (var i = SectionIndex + 1; i < $scope.FunctionImpactRelSectionList.length; i++) {
        //        if ($scope.FunctionImpactRelSectionList == null) continue;
        //        if ($scope.FunctionImpactRelSectionList[i] == null) continue;
        //        for (var j = 0; j < $scope.FunctionImpactRelSectionList[i].length; j++) {
        //            if ($scope.FunctionImpactRelSectionList[i] == null) continue;
        //            if ($scope.FunctionImpactRelSectionList[i][j] == null) continue;
        //            if ($scope.FunctionImpactRelSectionList[i][j].ProblemElementName == ImpactElementName) {
        //                var CurImpactElementName = $scope.FunctionImpactRelSectionList[i][j].ImpactElementName;
        //                //$scope.FunctionImpactRelSectionList[i][j].ImpactElementParam = "delete";
        //                $scope.FunctionImpactRelSectionList[i].splice(j, 1);
        //                j = j - 1;
        //                if (typeof ($scope.FunctionImpactRelSectionList[i].length) != "undefined") {
        //                    if ($scope.FunctionImpactRelSectionList[i].length == 0) {
        //                        $scope.FunctionImpactRelSectionList.splice(i, 1);
        //                        i = i - 1;
        //                    }
        //                }
        //                DeleteOtherImpactRelInFollowSections(i, CurImpactElementName);
        //                if ($scope.FunctionImpactRelSectionList[i] == null) break;
        //            }
        //        }
        //    }
        //}

    });//end

//-------------

function ComponentRelInfo() {
    this.ComponentID = "";
    this.ComponentName = "";//问题相关元件
    this.ComponentParamName = "";//元件特征参数
    this.ImpactParamComponentID = "";//影响该参数元件ID
    this.ImpactParamComponentName = "";//影响该参数元件
    this.ImpactParamName = "";//元件特征参数
    this.ParamType = "";//参数类型
    this.Disabled = false;//是否允许编辑
}

var ComponentRelInfoList = [];
var ComponentRelInfoListSection = [];

function ini() {
    var a = new ComponentRelInfo();
    a.ComponentName = "asdf";//问题相关元件
    a.ComponentParamName = "sadf";//元件特征参数
    a.ImpactParamComponentName = "ccc";//影响该参数元件
    a.ImpactParamName = "sadfadfadsf";//元件特征参数
    a.ParamType = "独立变量";//参数类型
    a.Disabled = false;//是否禁止编辑

    ComponentRelInfoList.push(a);
    ComponentRelInfoListSection.push(ComponentRelInfoList);
}






