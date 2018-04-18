angular.module("myApp")
    .controller('ProjectOpeCtrl', function ($scope, $location, requestService, $stateParams, $state, locals) {
        //alert(locals.get("firstpos"));
        var Sources = "Projects";
        $scope.data = {
            Code: "",
            Name: "",
            Owner: "",
            Department: "",
            CreateDateTime: ""
        };
        if ($stateParams.ID != null) {
            requestService.getobj(Sources, $stateParams.ID).then(function (data) {
                $scope.data = data;
            });
        }

        $scope.Save = function () {

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
                Code: {
                    required: true,
                    maxlength: 50
                },

                Name: {
                    required: true,
                    maxlength: 50
                },

                Owner: {
                    required: true,
                    maxlength: 50
                },

                Department: {
                    maxlength: 50
                }
            },

            messages: {
                Code: {
                    required: "请填写编号。",
                },

                Name: {
                    required: "请填写名称。",
                },

                Owner: {
                    required: "请填写负责人。",
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
            }
        });



    });//end
