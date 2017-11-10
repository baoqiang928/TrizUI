angular.module("myApp")
    .controller('ProjectOpeCtrl', function ($scope, $location, requestService, $stateParams, $state) {
        var Sources = "Projects";
        $scope.data = {
            Name: "",
            Code: "",
            Owner: "",
            Department: ""
        };

        requestService.getobj(Sources, $stateParams.ID).then(function (data) {
            $scope.data = data;
        });

        $scope.Save = function () {

            //alert($('#validation-form').valid());

            if (!$('#validation-form').valid()) {
                return false;
            }



            if ($stateParams.ID == "") {
                requestService.add(Sources, $scope.data).then(function (data) {
                    $state.go("ProjectList");
                });
                return;
            }

            requestService.update(Sources, $scope.data).then(function (data) {
                $state.go("ProjectList");
            });
        };


        $('#validation-form').validate({
            errorElement: 'div',
            errorClass: 'help-block',
            focusInvalid: false,
            rules: {
                email: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength: 5
                },
                password2: {
                    required: true,
                    minlength: 5,
                    equalTo: "#password"
                },
                name: {
                    required: true
                },
                phone: {
                    required: true,
                    phone: 'required'
                },
                url: {
                    required: true,
                    url: true
                },
                comment: {
                    required: true
                },
                state: {
                    required: true
                },
                platform: {
                    required: true
                },
                subscription: {
                    required: true
                },
                gender: 'required',
                agree: 'required'
            },

            messages: {
                name: {
                    required: "请填写项目名称。",
                },
                email: {
                    required: "Please provide a valid email.",
                    email: "Please provide a valid email."
                },
                password: {
                    required: "Please specify a password.",
                    minlength: "Please specify a secure password."
                },
                subscription: "Please choose at least one option",
                gender: "Please choose gender",
                agree: "Please accept our policy"
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