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

        $scope.Change = function (index, ImpactElementType, ProblemElementID, ProblemElementName, ProblemElementParam)
        {
            if (ImpactElementType == "非独立变量")
            {
                $scope.AddDependentParam(index, ProblemElementID, ProblemElementName, ProblemElementParam)
            }
        }

        //$scope.FunctionImpactRelList1 = [];

        //$scope.FunctionImpactRelInfo = {
        //    ID: "33",
        //    ProblemElementName: "333",//问题相关元件
        //    ProblemElementParam: "",//元件特征参数
        //    ImpactElementName: "",//影响该参数元件
        //    ImpactElementParam: "",//元件特征参数
        //    ImpactElementType: ""//参数类型
        //}
        //$scope.FunctionImpactRelList1.push($scope.FunctionImpactRelInfo);
        //$scope.FunctionImpactRelInfo = {
        //    ID: "44",
        //    ProblemElementName: "444",//问题相关元件
        //    ProblemElementParam: "",//元件特征参数
        //    ImpactElementName: "",//影响该参数元件
        //    ImpactElementParam: "",//元件特征参数
        //    ImpactElementType: ""//参数类型
        //}
        //$scope.FunctionImpactRelList1.push($scope.FunctionImpactRelInfo);
        //$scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList1);


        //var Thread_num = 5;
        //for (var i = 1; i <= Thread_num; i++) {
        //    eval("$scope.FunctionImpactRelList" + i + "= [];");
        //    eval("$scope.FunctionImpactRelList" + i + ".push($scope.FunctionImpactRelInfo);");
        //    eval("$scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList" + i + ");");
        //}

        //console.log($scope.FunctionImpactRelSectionList);

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

            if ($scope.FunctionImpactRelSectionList.length >= (NextSectionIndex+1)) {
                $scope.FunctionImpactRelSectionList[NextSectionIndex].push($scope.FunctionImpactRelInfo);
                return;
            }

            AddNewSection(NextSectionIndex);

            console.log($scope.FunctionImpactRelSectionList);

        };

        //增加新的 功能参数列表 
        function AddNewSection(SectionIndex) {
            eval("$scope.FunctionImpactRelList" + SectionIndex + "= [];");
            eval("$scope.FunctionImpactRelList" + SectionIndex + ".push($scope.FunctionImpactRelInfo);");
            eval("$scope.FunctionImpactRelSectionList.push($scope.FunctionImpactRelList" + SectionIndex + ");");
        }

        $scope.DeleteFunctionImpactRelInfo = function (SectionIndex,index) {
            $scope.FunctionImpactRelSectionList[SectionIndex].splice(index,1);
        }


    });//end