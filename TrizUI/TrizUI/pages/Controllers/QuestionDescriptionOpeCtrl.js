angular.module("myApp")
    .controller('QuestionDescriptionOpeCtrl', function ($scope, $location, requestService, $stateParams, $state, locals) {
        var Sources = "QuestionDescriptions";
        $scope.data = {
            ProjectID: "",
            Note: "",
            CustomerDes: "",
            Environment: "",
            InitialProblemDes: "",
            RelativeDemand: "",
            PotentialProblem: "",
            GapOfPerformanceRequirment: ""
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
                Note: {
                    required: true,
                    maxlength: 500
                },
                CustomerDes: {
                    maxlength: 500
                },
                Environment: {
                    maxlength: 500
                },
                InitialProblemDes: {
                    maxlength: 500
                },
                RelativeDemand: {
                    maxlength: 500
                },
                PotentialProblem: {
                    maxlength: 500
                },
                GapOfPerformanceRequirment: {
                    maxlength: 500
                }
            },

            messages: {
                Note: {
                    required: "请填写问题描述。",
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

