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

        $scope.ProjectID = locals.get("ProjectID");
        if ($scope.ProjectID != null) {
            requestService.getobj(Sources, $scope.ProjectID).then(function (data) {
                $scope.data = data;
            });
        }

        $scope.Save = function () {
            if (!$('#validation-form').valid()) {
                return false;
            }
            $scope.data.ProjectID = locals.get("ProjectID");
            requestService.add(Sources, $scope.data).then(function (data) {
                Alert("保存成功。");
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
                IdealResolution1: {
                    maxlength: "aaaaaaaaaaaaaaaaaaaa"
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

