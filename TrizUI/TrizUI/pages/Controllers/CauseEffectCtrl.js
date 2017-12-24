angular.module('myApp')
    .controller('CauseEffectCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.Sources = "FunEleMutualReacts";
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.ParamTypes = [{ id: 1, name: '独立变量' }, { id: 2, name: '非独立变量' }];

        $scope.FunctionImpactRelInfo = {
            ID: "",
            ProblemElementID: "",
            ProblemElementName: "",//问题相关元件
            ProblemElementParam: "",//元件特征参数
            ImpactElementID: "",//影响该参数元件ID
            ImpactElementName: "",//影响该参数元件
            ImpactElementParam: "",//元件特征参数
            ImpactElementType: ""//参数类型
        }

        $scope.FunctionImpactRelList = [];
        $scope.FunctionImpactRelSectionList = [];

        $scope.FunctionImpactRelInfo = {
            ID: "1",
            ProblemElementID: "11",
            ProblemElementName: "111",//问题相关元件
            ProblemElementParam: "",//元件特征参数
            ImpactElementID: "",//影响该参数元件ID
            ImpactElementName: "",//影响该参数元件
            ImpactElementParam: "",//元件特征参数
            ImpactElementType: "独立变量"//参数类型
        }
        $scope.FunctionImpactRelList.push($scope.FunctionImpactRelInfo);
        $scope.FunctionImpactRelInfo = {
            ID: "2",
            ProblemElementID: "222",
            ProblemElementName: "222",//问题相关元件
            ProblemElementParam: "",//元件特征参数
            ImpactElementID: "",//影响该参数元件ID
            ImpactElementName: "",//影响该参数元件
            ImpactElementParam: "",//元件特征参数
            ImpactElementType: "独立变量"//参数类型
        }
        $scope.FunctionImpactRelList.push($scope.FunctionImpactRelInfo);

        $scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList);

        $scope.ImpactElementTypeChange = function (CurrentSectionIndex, ImpactElementType, ImpactElementID, ImpactElementName, ImpactElementParam) {
            if (ImpactElementType == "非独立变量") {
                $scope.AddDependentParam(CurrentSectionIndex, ImpactElementID, ImpactElementName, ImpactElementParam);
            }
            else {
                DeleteOtherImpactRelInFollowSections(CurrentSectionIndex, ImpactElementName);
            }
        }

        $scope.DisabledInput = function (ImpactElementType) {
            if (ImpactElementType == "非独立变量") {
                return true;
            }
            return false;
        }

        $scope.ModifyImpactElementParamInOtherSection = function (CurSectionIndex, ImpactElementType, ImpactElementName, ImpactElementParam) {
            if (ImpactElementType == "非独立变量") {
                var i = CurSectionIndex + 1;
                for (var j = 0; j < $scope.FunctionImpactRelSectionList[i].length; j++) {
                    if ($scope.FunctionImpactRelSectionList[i] == null) continue;
                    if ($scope.FunctionImpactRelSectionList[i][j] == null) continue;
                    if ($scope.FunctionImpactRelSectionList[i][j].ProblemElementName == ImpactElementName) {
                        $scope.FunctionImpactRelSectionList[i][j].ProblemElementParam = ImpactElementParam;
                    }
                }
            }
        }
            //增加一个非独立变量，会自动增加一组参数列表，并在下一个参数列表增加一行
            $scope.AddDependentParam = function (CurrentSectionIndex, ElementID, ElementName, ElementParam) {

                $scope.FunctionImpactRelInfo = {
                    ID: "",
                    ProblemElementID: ElementID,
                    ProblemElementName: ElementName,//问题相关元件
                    ProblemElementParam: ElementParam,//元件特征参数
                    ImpactElementID: "",//影响该参数元件ID
                    ImpactElementName: "",//影响该参数元件
                    ImpactElementParam: "",//元件特征参数
                    ImpactElementType: "独立变量"//参数类型
                }

                //如果不存在组参数列表，则增加。
                var NextSectionIndex = CurrentSectionIndex + 1;

                if ($scope.FunctionImpactRelSectionList.length >= (NextSectionIndex + 1)) {
                    $scope.FunctionImpactRelSectionList[NextSectionIndex].push($scope.FunctionImpactRelInfo);
                    return;
                }
                AddNewSection(NextSectionIndex);
            };

            //增加新的 功能参数列表 
            function AddNewSection(SectionIndex) {
                eval("$scope.FunctionImpactRelList" + SectionIndex + "= [];");
                eval("$scope.FunctionImpactRelList" + SectionIndex + ".push($scope.FunctionImpactRelInfo);");
                eval("$scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList" + SectionIndex + ");");
            }

            //删除按钮事件
            $scope.DeleteFunctionImpactRelInfo = function (SectionIndex, index) {
                DeleteOtherImpactRelInFollowSections(SectionIndex, $scope.FunctionImpactRelSectionList[SectionIndex][index].ImpactElementName);
                $scope.FunctionImpactRelSectionList[SectionIndex].splice(index,1);
            }

            //增加并列功能参数
            $scope.AddBrother = function (SectionIndex, index, ElementID, ElementName, ElementParam) {
                $scope.FunctionImpactRelInfo = {
                    ID: "",
                    ProblemElementID: ElementID,
                    ProblemElementName: ElementName,//问题相关元件
                    ProblemElementParam: ElementParam,//元件特征参数
                    ImpactElementID: "",//影响该参数元件ID
                    ImpactElementName: "",//影响该参数元件
                    ImpactElementParam: "",//元件特征参数
                    ImpactElementType: "独立变量"//参数类型
                }
                $scope.FunctionImpactRelSectionList[SectionIndex].splice(index + 1, 0, $scope.FunctionImpactRelInfo);
            }

            //删除其他的相关的作用关系
            function DeleteOtherImpactRelInFollowSections(SectionIndex, ImpactElementName) {
                for (var i = SectionIndex + 1; i < $scope.FunctionImpactRelSectionList.length; i++) {
                    if ($scope.FunctionImpactRelSectionList == null) continue;
                    if ($scope.FunctionImpactRelSectionList[i] == null) continue;
                    for (var j = 0; j < $scope.FunctionImpactRelSectionList[i].length; j++) {
                        if ($scope.FunctionImpactRelSectionList[i] == null) continue;
                        if ($scope.FunctionImpactRelSectionList[i][j] == null) continue;
                        if ($scope.FunctionImpactRelSectionList[i][j].ProblemElementName == ImpactElementName) {
                            var CurImpactElementName = $scope.FunctionImpactRelSectionList[i][j].ImpactElementName;
                            //$scope.FunctionImpactRelSectionList[i][j].ImpactElementParam = "delete";
                            $scope.FunctionImpactRelSectionList[i].splice(j, 1);
                            j = j - 1;
                            if (typeof ($scope.FunctionImpactRelSectionList[i].length) != "undefined") {
                                if ($scope.FunctionImpactRelSectionList[i].length == 0) {
                                    $scope.FunctionImpactRelSectionList.splice(i, 1);
                                    i = i - 1;
                                }
                            }
                            DeleteOtherImpactRelInFollowSections(i, CurImpactElementName);
                            if ($scope.FunctionImpactRelSectionList[i] == null) break;
                        }
                    }
                }
            }

        });//end