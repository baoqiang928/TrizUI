angular.module('myApp')
    .controller('SeparationPrincipleOpeCtrl', function ($scope, $rootScope, $location, requestService, $state, locals, $stateParams) {
        $scope.CurrentProjectID = "0";//$scope.CurrentProjectID;
        $scope.PageTitle = $stateParams.Title;


        $scope.DictionaryTreeInfo = function () {
            this.ProjectID = $scope.CurrentProjectID;
            this.TreeTypeID = $stateParams.TreeTypeID;
            this.Name = "";
            this.Note = "";
        }

        $scope.DictionaryTreeInfoList = [];

        $scope.QueryData = {
            ProjectID: "0",
            TreeTypeID: $stateParams.TreeTypeID,
            OpeType: "GetFatherNodes"
        };
        var GetDictionaryTreeInfoList = function () {
            $scope.QueryData.TreeTypeID = $stateParams.TreeTypeID;
            requestService.lists("DictionaryTrees", $scope.QueryData).then(function (data) {
                $scope.DictionaryTreeInfoList = data;
            });
        }
        $scope.InventInfoList = [];
        var GetInventDictionaryTreeInfoList = function () {
            $scope.QueryData.TreeTypeID = "1";
            requestService.lists("DictionaryTrees", $scope.QueryData).then(function (data) {
                $scope.InventInfoList = data;
                GetDictionaryTreeInfoList();
            });
        }
        GetInventDictionaryTreeInfoList();

        $scope.click = function ($event, id, obj) {
            var checkbox = $event.target;
            if (obj.Note.substr(obj.Note.Length - 1, 1) != ";") {
                obj.Note = obj.Note + ";";
            }
            if ((";" + obj.Note + ";").indexOf(";" + id + ";") < 0) {
                if (checkbox.checked) {
                    obj.Note = obj.Note + ";" + id + ";";
                }
            }
            if (!checkbox.checked) {
                obj.Note = obj.Note.replace(";" + id + ";", ";");
            }
            for (var i = 0; i < 10; i++) {
                obj.Note = obj.Note.replace(";;", ";");
            }
        };

        $scope.cb = function (id, ids) {
            if ((";" + ids + ";").indexOf(";" + id + ";") < 0) {
                return false;
            }
            return true;
        };

        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }

        $scope.AddDictionaryTreeInfo = function () {
            var newobj = new $scope.DictionaryTreeInfo();
            $scope.DictionaryTreeInfoList.push(newobj);
        }

        $scope.DeleteDictionaryTreeInfo = function (index) {
            bootbox.confirm("要删除当前的记录？", function (result) {
                if (result) {
                    requestService.delete("DictionaryTrees", $scope.DictionaryTreeInfoList[index].ID).then(function (data) { });
                    $scope.DictionaryTreeInfoList.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.SaveRelInfo = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}

            for (var i = 0; i < $scope.DictionaryTreeInfoList.length; i++) {
                var DictionaryTreeInfo = $scope.DictionaryTreeInfoList[i];
                DictionaryTreeInfo.SerialNum = i;
                requestService.add("DictionaryTrees", DictionaryTreeInfo).then(function (data) {
                    if (DictionaryTreeInfo.ID == "") {
                        DictionaryTreeInfo.ID = data;
                    }
                });
            }
            alert("保存成功。");
        };




    });