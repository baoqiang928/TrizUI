using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class OpeCtrlCodes
    {
        #region codes
        string codes = @"angular.module(""myApp"")
    .controller('{BusinessObjectInfo.ObjName}OpeCtrl', function ($scope, $location, requestService, $stateParams, $state) {
        var Sources = ""{BusinessObjectInfo.ObjName}s"";
        $scope.data = {
            {$scope.data.properties}
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

            if ($stateParams.ID == """") {
                requestService.add(Sources, $scope.data).then(function (data) {
                    $state.go(""{BusinessObjectInfo.ObjName}List"");
                });
                return;
            }

            requestService.update(Sources, $scope.data).then(function (data) {
                $state.go(""{BusinessObjectInfo.ObjName}List"");
            });
        };


        $('#validation-form').validate({
            errorElement: 'div',
            errorClass: 'help-block',
            focusInvalid: false,
            rules: {
                {rulles}
            },

            messages: {
                {messages}               
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
                    var controls = element.closest('div[class*=""col-""]');
                    if (controls.find(':checkbox,:radio').length > 1) controls.append(error);
                    else error.insertAfter(element.nextAll('.lbl:eq(0)').eq(0));
                }
                else if (element.is('.select2')) {
                    error.insertAfter(element.siblings('[class*=""select2-container""]:eq(0)'));
                }
                else if (element.is('.chosen-select')) {
                    error.insertAfter(element.siblings('[class*=""chosen-container""]:eq(0)'));
                }
                else error.insertAfter(element.parent());
            },

            submitHandler: function (form) {
            },
            invalidHandler: function (form) {
            }
        });


    });//end
";
        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            string CodeSection1 = "";
            string CodeSection2 = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName

                //{$scope.data.properties}
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Operate)) continue;

                CodeSection += @"{BusinessObjectInfo.Name}: """",        
                    ";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);

                //{rulles}
                if (BusinessObjectInfo.Name != "CreateDateTime")
                {
                    //允许空
                    if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Mondantory) && (BusinessObjectInfo.Name != "CreateDateTime"))
                    {
                        CodeSection1 += @"{BusinessObjectInfo.Name}: {
                                        maxlength: {BusinessObjectInfo.Length}
                                    },
                    ";
                        CodeSection1 = CodeSection1.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
                        CodeSection1 = CodeSection1.Replace("{BusinessObjectInfo.Length}", BusinessObjectInfo.Length);

                        //{message}
                        CodeSection2 += @"{BusinessObjectInfo.Name}: {
                                        maxlength: ""输入内容过多，请重新输入。""
                                    },
                    ";
                        CodeSection2 = CodeSection2.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);

                        continue;
                    }

                    CodeSection1 += @"{BusinessObjectInfo.Name}: {
                                        required: true,
                                        maxlength: {BusinessObjectInfo.Length}
                                    },
                    ";
                    CodeSection1 = CodeSection1.Replace("{BusinessObjectInfo.Length}", BusinessObjectInfo.Length);
                    CodeSection1 = CodeSection1.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
                }
                //{messages}
                if (BusinessObjectInfo.Name == "CreateDateTime") continue;
                CodeSection2 += @"{BusinessObjectInfo.Name}: {
                                        required: ""请填写{BusinessObjectInfo.Description}。"",
                                        maxlength: ""输入内容过多，请重新输入。""
                                    },
                    ";
                CodeSection2 = CodeSection2.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);
            }

            CodeSection = CodeSection.Trim().TrimEnd(',');
            CodeSection1 = CodeSection1.Trim().TrimEnd(',');
            CodeSection2 = CodeSection2.Trim().TrimEnd(',');
            codes = codes.Replace("{$scope.data.properties}", CodeSection);
            codes = codes.Replace("{rulles}", CodeSection1);
            codes = codes.Replace("{messages}", CodeSection2);

            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName);
            return codes;
        }
    }
}
