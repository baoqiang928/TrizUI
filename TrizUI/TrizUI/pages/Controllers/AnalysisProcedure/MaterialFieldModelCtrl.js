angular.module("myApp")
    .controller('MaterialFieldModelCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.MaterialFieldModelInfo = function()
        {
            ID: "";
            ProjectID: "";
            SerialNum: "";
            FunctionSubject: "";
            FunctionObject: "";
            RelationType: "";
            FieldName: "";
            FieldType: "";
            Symbol: "";
            Remark: "";
        }

        $scope.MaterialFieldModelInfoList = [];

        var newobj = new $scope.MaterialFieldModelInfo();
        $scope.MaterialFieldModelInfoList.push(newobj);

        $scope.AddMaterialFieldModelInfo = function()
        {
            var newobj = new $scope.MaterialFieldModelInfo();
            $scope.MaterialFieldModelInfoList.push(newobj);
        }

        $scope.DeleteMaterialFieldModelInfo = function(index)
        {
            bootbox.confirm("要删除当前的记录？", function(result) {
                if (result)
                {
                    $scope.MaterialFieldModelInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }

        //监听"ShareObjectEvent"事件
        $scope.$on("ShareObjectEvent", function (event, args) {
            $scope.Save(args);
        });
        $scope.Save = function (o) {
            console.log("o", o);
            alert(o);
        };

    });