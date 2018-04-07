angular.module('myApp')
    .controller('DicInfoOpeCtrl', function ($scope, $location, requestService, $state, locals) {
        $scope.CurrentProjectID = locals.get("ProjectID");
        $scope._simpleConfig = {
            //初始化编辑器内容  
            content: '<p>test1</p>',
            //是否聚焦 focus默认为false  
            focus: true,
            //首行缩进距离,默认是2em  
            indentValue: '2em',
            //初始化编辑器宽度,默认1000  
            initialFrameWidth: '100%',
            //初始化编辑器高度,默认320  
            initialFrameHeight: 520,
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

        $scope.SaveInfo = function (id) {
            console.log("$scope.$parent.nodeData.Note", $scope.$parent.nodeData.Note);
            requestService.update("DictionaryTrees", $scope.$parent.nodeData).then(function (data) {
                if ($scope.$parent.CurrentNode.$modelValue.ID = $scope.$parent.nodeData.ID)
                {
                    $scope.$parent.CurrentNode.$modelValue.title = $scope.$parent.nodeData.Name;
                }
                alert("保存成功。");
            });
        };


    });