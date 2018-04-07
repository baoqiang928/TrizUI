angular.module("myApp")
    .controller('StandardSolutionOpeCtrl', function ($scope, $location, requestService, $stateParams, $state, locals) {
        $scope._simpleConfig = {
            //初始化编辑器内容  
            content: '<p>test1</p>',
            //是否聚焦 focus默认为false  
            focus: true,
            //首行缩进距离,默认是2em  
            indentValue: '2em',
            //初始化编辑器宽度,默认1000  
            initialFrameWidth: 1000,
            //初始化编辑器高度,默认320  
            initialFrameHeight: 820,
            //编辑器初始化结束后,编辑区域是否是只读的，默认是false  
            readonly: false,
            //启用自动保存  
            enableAutoSave: false,
            //自动保存间隔时间， 单位ms  
            saveInterval: 500,
            //是否开启初始化时即全屏，默认关闭  
            fullscreen: false,
            //图片操作的浮层开关，默认打开  
            imagePopup: true,
            //提交到后台的数据是否包含整个html字符串  
            allHtmlEnabled: false,
            //额外功能添加                 
            functions: ['map', 'insertimage', 'insertvideo', 'attachment',
            , 'insertcode', 'webapp', 'template',
            'background', 'wordimage']
        };
        $scope.CurrentProjectID = locals.get("ProjectID");

        var Sources = "StandardSolutions";
        $scope.data = {
            ProjectID: locals.get("ProjectID"),
            SerialNum: "0",
            Name: "",
            Note: "",
            Remark: "",
            TypeID: "0"
        };
        if ($stateParams.ID != null) {
            requestService.getobj(Sources, $stateParams.ID).then(function (data) {
                $scope.data = data;
                console.log("data", data);
            });
        }
        $scope.Save = function () {
            if (!$('#validation-form').valid()) {
                return false;
            }
            if ($stateParams.ID == "") {
                requestService.add(Sources, $scope.data).then(function (data) {
                    $state.go("Solution");
                });
                return;
            }
            requestService.update(Sources, $scope.data).then(function (data) {
                $state.go("Solution");
            });
        };

        //树
        $scope.TreeData = [];
        var GetTreeNodes = function () {
            $scope.QueryData = {
                ProjectID: locals.get("ProjectID"),
                TypeID: ""//这个参数就是为了定位webapi方法的
            };
            requestService.lists("StandardSolutionExamples", $scope.QueryData).then(function (data) {
                $scope.TreeData = strToJson(data.json);
                //console.log("$scope.nodeData", $scope.TreeData);
            });
        };
        GetTreeNodes();
        function strToJson(str) {
            var json = (new Function("return " + str))();
            return json;
        }
        $scope.SelectItem = function (CurrentNode) {
            $scope.data.TypeID = CurrentNode.$modelValue.ID;
            $scope.data.TypeName = CurrentNode.$modelValue.title;
            $('#modal-table').modal('hide');
        };
        $scope.SelectType = function () {
            $('#modal-table').modal('show');
        };
        //树 end


        $('#validation-form').validate({
            errorElement: 'div',
            errorClass: 'help-block',
            focusInvalid: false,
            rules: {
                Name: {
                    required: true,
                    maxlength: 200
                },
                Note: {
                    maxlength: 4000
                },
                Remark: {
                    maxlength: 1000
                }
            },

            messages: {
                SerialNum: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Name: {
                    required: "请填写名称。",
                    maxlength: "输入内容过多，请重新输入。"
                },
                Note: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                Remark: {
                    maxlength: "输入内容过多，请重新输入。"
                },
                TypeID: {
                    required: "请填写所属分类ID。",
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

