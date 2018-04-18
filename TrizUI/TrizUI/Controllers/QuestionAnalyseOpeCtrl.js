angular.module("myApp")
    .controller('QuestionAnalyseOpeCtrl', function ($scope, $location, requestService, $stateParams, $state, locals) {
        var Sources = "QuestionAnalyses";
        $scope.data = {
            ProjectID: "",
            IdealResolution1: "",
            IdealResolution2: "",
            IdealResolution3: "",
            IdealResolution4: "",
            IdealResolution5: "",
            BasicQuestion1: "",
            BasicQuestion2: "",
            BasicQuestion3: "",
            BasicQuestion4: "",
            AgainstObject1: "",
            AgainstObject2: "",
            AgainstObject3: "",
            AgainstObject4: "",
            AgainstObject5: "",
            Constriction1: "",
            Constriction2: "",
            Constriction3: "",
            Constriction4: "",
            Constriction5: "",
            ResolutionImportance1: "",
            ResolutionImportance2: "",
            ResolutionImportance3: "",
            ResolutionImportance4: "",
            ResolutionImportance5: ""
        };
        $scope.Group2Disabled = true;
        $scope.Group3Disabled = true;
        $scope.Group4Disabled = true;
        $scope.Group5Disabled = true;
        $scope.InputChanged = function () {
            if (Group1InputedCount() > 2) {
                SetGroup2Background("");
                $scope.Group2Disabled = false;
            }
            else {
                SetGroup2Background("header-color-grey");
                $scope.Group2Disabled = true;
            }

            if (Group2InputedCount() > 2) {
                SetGroup3Background("");
                $scope.Group3Disabled = false;
            }
            else {
                SetGroup3Background("header-color-grey");
                $scope.Group3Disabled = true;
            }

            if (Group3InputedCount() > 2) {
                SetGroup4Background("");
                $scope.Group4Disabled = false;
            }
            else {
                SetGroup4Background("header-color-grey");
                $scope.Group4Disabled = true;
            }

            if (Group4InputedCount() > 2) {
                SetGroup5Background("");
                $scope.Group5Disabled = false;
            }
            else {
                SetGroup5Background("header-color-grey");
                $scope.Group5Disabled = true;
            }
        }
        

        function Group1InputedCount() {
            var i = 0;
            console.log("$scope.data", $scope.data);
            if (($scope.data.AgainstObject1 != "") && ($scope.data.AgainstObject1 != null)) {
                i = i + 1;
            }
            if (($scope.data.AgainstObject2 != "") && ($scope.data.AgainstObject2 != null)) {
                i = i + 1;
            }
            if (($scope.data.AgainstObject3 != "") && ($scope.data.AgainstObject3 != null)) {
                i = i + 1;
            }
            if (($scope.data.AgainstObject4 != "") && ($scope.data.AgainstObject4 != null)) {
                i = i + 1;
            }
            if (($scope.data.AgainstObject5 != "") && ($scope.data.AgainstObject5 != null)) {
                i = i + 1;
            }
            return i;
        }
        function Group2InputedCount() {
            var i = 0;
            if (($scope.data.Constriction1 != "") && ($scope.data.Constriction1 != null)) {
                i = i + 1;
            }
            if (($scope.data.Constriction2 != "") && ($scope.data.Constriction2 != null)) {
                i = i + 1;
            }
            if (($scope.data.Constriction3 != "") && ($scope.data.Constriction3 != null)) {
                i = i + 1;
            }
            if (($scope.data.Constriction4 != "") && ($scope.data.Constriction4 != null)) {
                i = i + 1;
            }
            if (($scope.data.Constriction5 != "") && ($scope.data.Constriction5 != null)) {
                i = i + 1;
            }
            return i;
        }
        function Group3InputedCount() {
            var i = 0;
            if (($scope.data.ResolutionImportance1 != "") && ($scope.data.ResolutionImportance1 != null)) {
                i = i + 1;
            }
            if (($scope.data.ResolutionImportance2 != "") && ($scope.data.ResolutionImportance2 != null)) {
                i = i + 1;
            }
            if (($scope.data.ResolutionImportance3 != "") && ($scope.data.ResolutionImportance3 != null)) {
                i = i + 1;
            }
            if (($scope.data.ResolutionImportance4 != "") && ($scope.data.ResolutionImportance4 != null)) {
                i = i + 1;
            }
            if (($scope.data.ResolutionImportance5 != "") && ($scope.data.ResolutionImportance5 != null)) {
                i = i + 1;
            }
            return i;
        }
        function Group4InputedCount() {
            var i = 0;
            if (($scope.data.IdealResolution1 != "") && ($scope.data.IdealResolution1 != null)) {
                i = i + 1;
            }
            if (($scope.data.IdealResolution2 != "") && ($scope.data.IdealResolution2 != null)) {
                i = i + 1;
            }
            if (($scope.data.IdealResolution3 != "") && ($scope.data.IdealResolution3 != null)) {
                i = i + 1;
            }
            if (($scope.data.IdealResolution4 != "") && ($scope.data.IdealResolution4 != null)) {
                i = i + 1;
            }
            if (($scope.data.IdealResolution5 != "") && ($scope.data.IdealResolution5 != null)) {
                i = i + 1;
            }
            return i;
        }
        function Group5InputedCount() {
            var i = 0;
            if (($scope.data.BasicQuestion1 != "") && ($scope.data.BasicQuestion1 != null)) {
                i = i + 1;
            }
            if (($scope.data.BasicQuestion2 != "") && ($scope.data.BasicQuestion2 != null)) {
                i = i + 1;
            }
            if (($scope.data.BasicQuestion3 != "") && ($scope.data.BasicQuestion3 != null)) {
                i = i + 1;
            }
            if (($scope.data.BasicQuestion4 != "") && ($scope.data.BasicQuestion4 != null)) {
                i = i + 1;
            }
            return i;
        }

        function SetGroup2Background(color) {
            $scope.Group2Background = color;
        }
        function SetGroup3Background(color) {
            $scope.Group3Background = color;
        }
        function SetGroup4Background(color) {
            $scope.Group4Background = color;
        }
        function SetGroup5Background(color) {
            $scope.Group5Background = color;
        }


        $scope.ProjectID = locals.get("ProjectID");
        if ($scope.ProjectID != null) {
            requestService.getobj(Sources, $scope.ProjectID).then(function (data) {
                $scope.data = data;
                $scope.InputChanged();
            });
        }

        $scope.Save = function () {
            if (!$('#validation-form').valid()) {
                return false;
            }
            $scope.data.ProjectID = locals.get("ProjectID");
            requestService.add(Sources, $scope.data).then(function (data) {
                alert("保存成功。");
                return;
            });

        };


        $('#validation-form').validate({
            errorElement: 'div',
            errorClass: 'help-block',
            focusInvalid: false,
            rules: {
                IdealResolution1: {
                    maxlength: 500
                },
                IdealResolution2: {
                    maxlength: 500
                },
                IdealResolution3: {
                    maxlength: 500
                },
                IdealResolution4: {
                    maxlength: 500
                },
                IdealResolution5: {
                    maxlength: 500
                },
                BasicQuestion1: {
                    maxlength: 500
                },
                BasicQuestion2: {
                    maxlength: 500
                },
                BasicQuestion3: {
                    maxlength: 500
                },
                BasicQuestion4: {
                    maxlength: 500
                },
                AgainstObject1: {
                    maxlength: 500
                },
                AgainstObject2: {
                    maxlength: 500
                },
                AgainstObject3: {
                    maxlength: 500
                },
                AgainstObject4: {
                    maxlength: 500
                },
                AgainstObject5: {
                    maxlength: 500
                },
                Constriction1: {
                    maxlength: 500
                },
                Constriction2: {
                    maxlength: 500
                },
                Constriction3: {
                    maxlength: 500
                },
                Constriction4: {
                    maxlength: 500
                },
                Constriction5: {
                    maxlength: 500
                },
                ResolutionImportance1: {
                    maxlength: 500
                },
                ResolutionImportance2: {
                    maxlength: 500
                },
                ResolutionImportance3: {
                    maxlength: 500
                },
                ResolutionImportance4: {
                    maxlength: 500
                },
                ResolutionImportance5: {
                    maxlength: 500
                }
            },

            messages: {
                ProjectID: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                IdealResolution1: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                IdealResolution2: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                IdealResolution3: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                IdealResolution4: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                IdealResolution5: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                BasicQuestion1: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                BasicQuestion2: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                BasicQuestion3: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                BasicQuestion4: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                AgainstObject1: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                AgainstObject2: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                AgainstObject3: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                AgainstObject4: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                AgainstObject5: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Constriction1: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Constriction2: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Constriction3: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Constriction4: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Constriction5: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                ResolutionImportance1: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                ResolutionImportance2: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                ResolutionImportance3: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                ResolutionImportance4: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                ResolutionImportance5: {
                    maxlength: "输入内容过多，请重新输入。"
                }
            },

            invalidHandler: function (event, validator) { //display error alert on form submit   
                $('.alert-danger', $('.login-form')).show();
            },

            highlight: function (e) {
                $(e).closest('.form-group').removeClass('has-info').addClass('has-error');
            },

            success: function (e) {
                $(e).closest('.form-group').removeClass('has-error').addClass('has-info');
                $(e).remove();
            },

            errorPlacement: function (error, element) {
                if (element.is(':checkbox') || element.is(':radio')) {
                    var controls = element.closest('div[class*="col-"]');
                    if (controls.find(':checkbox,:radio').length > 1) controls.append(error);
                    else error.insertAfter(element.nextAll('.lbl:eq(0)').eq(0));
                }
                else if (element.is('.select2')) {
                    error.insertAfter(element.siblings('[class*="select2-container"]:eq(0)'));
                }
                else if (element.is('.chosen-select')) {
                    error.insertAfter(element.siblings('[class*="chosen-container"]:eq(0)'));
                }
                else error.insertAfter(element.parent());
            },

            submitHandler: function (form) {
            },
            invalidHandler: function (form) {
            }
        });


    });//end

