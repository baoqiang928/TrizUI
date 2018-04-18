angular.module('myApp')
    .controller('SeparationPrincipleListCtrl', function ($scope, $rootScope, $location, requestService, $state, locals, $stateParams) {
        $scope.CurrentProjectID = $stateParams.CurrentProjectID;
        if ($stateParams.CurrentProjectID == "")
            $scope.CurrentProjectID = locals.get("ProjectID");
        $scope.PageTitle = $stateParams.Title;

        var $assets = "assets";//this will be used in fuelux.tree-sampledata.js


        var DataSourceTree = function (options) {
            this._data = options.data;
            this._delay = options.delay;
        }

        DataSourceTree.prototype.data = function (options, callback) {
            var parent_id = null
            var self = this;
            var $data = null;

            if (!("name" in options) && !("type" in options)) {
                $scope.data = {
                    TreeTypeID: $stateParams.TreeTypeID,
                    ProjectID: "0",
                };
                requestService.lists("DictionaryBigTrees", $scope.data).then(function (data) {
                    console.log("js22", data.Results);
                    eval(data.Results);
                    callback({ data: TreeData });
                });

                //$data = aaa_data;//this._data;//the root tree
                return;
            }

            if ("type" in options && options.type == "folder") {
                if ("additionalParameters" in options && "children" in options.additionalParameters) {
                    parent_id = options.additionalParameters['id'];
                }
                else {
                    $data = {}//no data
                }
            }

            if (parent_id != null)//this setTimeout is only for mimicking some random delay
            {
                $scope.data = {
                    FatherID: parent_id
                };
                requestService.lists("DictionaryBigTrees", $scope.data).then(function (data) {
                    eval(data.Results);
                    console.log("js11", data.Results);
                    callback({ data: TreeData });
                });
                //setTimeout(function () { callback({ data: $data }); }, parseInt(Math.random() * 500) + 200);
            }
            //we have used static data here
            //but you can retrieve your data dynamically from a server using ajax call
            //checkout examples/treeview.html and examples/treeview.js for more info
        };


        var tree_data = {}
        var treeDataSource = new DataSourceTree({ data: tree_data });



        $('#tree1').ace_tree({
            //dataSource: remoteDateSource,
            dataSource: treeDataSource,
            multiSelect: false,
            loadingHTML: '<div class="tree-loading"><i class="icon-refresh icon-spin blue"></i></div>',
            'open-icon': 'icon-minus',
            'close-icon': 'icon-plus',
            'selectable': true,
            'selected-icon': 'icon-ok',
            'unselected-icon': 'icon-remove'
        });


        $scope.SelectedNodeName = "";
        $scope.nodeData = [];

        $('#tree1').on('loaded', function (evt, data) {
        });

        $('#tree1').on('opened', function (evt, data) {
            requestService.getobj("DictionaryTrees", data.id).then(function (data) {
                $scope.nodeData = data;
                $scope.SelectedNodeName = data.Name;
            });
        });

        $('#tree1').on('closed', function (evt, data) {
            requestService.getobj("DictionaryTrees", data.id).then(function (data) {
                $scope.nodeData = data;
                $scope.SelectedNodeName = data.Name;
            });
        });

        $('#tree1').on('selected', function (evt, data) {
            requestService.getobj("DictionaryTrees", data.info[0].id).then(function (data) {
                $scope.nodeData = data;
            });
        });


        $scope.newSubItem = function () {
            var tree = $('#tree1').data('tree');
            var output = '';
            var items = tree.selectedItems();
            console.log("selectedItems", items);
            for (var i in items) if (items.hasOwnProperty(i)) {
                var item = items[i];
                //output += item.additionalParameters['id'] + ":"+ item.name+"\n";
                output += item.name + "\n";
                item.name += "aaaaaaa";
            }



            //默认展开第一层节点
            //$("#tree1").find(".tree-folder-header").each(function () {
            //    console.log("$(this).parent()", $(this).parent());
            //    if ($(this).parent().css("display") == "block") {
            //        $(this).trigger("click");
            //    }
            //});

            //unf('a');
            //function unf(dep) {
            //    // $("#tree1").find('.tree-selected').each(function () {
            //    $("#tree1").find('.tree-folder-name').each(function () {
            //        $(this).html('aaaa');
            //        console.log("this", this);
            //        //$(this).find('.tree-branch').each(function () {
            //        //    console.log("tree-label", $(this).find('.tree-branch-name').find('.tree-label').html());
            //        //});
            //    });
            //}



            //$('#modal-tree-items').modal('show');
            //$('#tree-value').css({ 'width': '98%', 'height': '200px' }).val(output);

        };

        $scope.UpdateCurrentNodeName = function (NewName) {
            $("#tree1").find('.tree-folder-name').each(function () {
                if ($(this).html() == $scope.SelectedNodeName) {
                    $(this).html(NewName);
                    $scope.SelectedNodeName = NewName;
                }
                //$(this).find('.tree-branch').each(function () {
                //    console.log("tree-label", $(this).find('.tree-branch-name').find('.tree-label').html());
                //});
            });
        };


    });//end