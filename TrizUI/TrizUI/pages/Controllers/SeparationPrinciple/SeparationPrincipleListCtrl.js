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



        //eval('var a = 2341;');
        //alert(a);

        var aaa_data = {
            '1': { id: '1', name: 'For Sale', type: 'folder' },
            'vehicles': { id: '2', name: 'Vehicles', type: 'folder' },
            'clothing': { id: '3', name: 'Clothing', type: 'item' }
        }
        aaa_data['1']['additionalParameters'] = {
            'id': "1",
            'children': {
                //'appliances': { name: 'Appliances', type: 'item' },
                //'arts-crafts': { name: 'Arts & Crafts', type: 'item' },
                //'clothing': { name: 'Clothing', type: 'item' },
                //'computers': { name: 'Computers', type: 'item' },
                //'jewelry': { name: 'Jewelry', type: 'item' },
                //'office-business': { name: 'Office & Business', type: 'item' },
                //'sports-fitness': { name: 'Sports & Fitness', type: 'item' }
            }
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
                    console.log("js", data.Results);
                    eval(data.Results);
                    callback({ data: TreeData });
                });

                $data = aaa_data;//this._data;//the root tree
                return;
            }

            if ("type" in options && options.type == "folder") {
                if ("additionalParameters" in options && "children" in options.additionalParameters) {
                    console.log("options", options);
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
                    callback({ data: TreeData });
                });
                //setTimeout(function () { callback({ data: $data }); }, parseInt(Math.random() * 500) + 200);
            }
            //we have used static data here
            //but you can retrieve your data dynamically from a server using ajax call
            //checkout examples/treeview.html and examples/treeview.js for more info
        };

        var tree_data = {
            'for-sale': { name: 'For Sale', type: 'folder' },
            'vehicles': { name: 'Vehicles', type: 'folder' },
            'rentals': { name: 'Rentals', type: 'folder' },
            'real-estate': { name: 'Real Estate', type: 'folder' },
            'pets': { name: 'Pets', type: 'folder' },
            'tickets': { name: 'Tickets', type: 'item' },
            'services': { name: 'Services', type: 'item' },
            'personals': { name: 'Personals', type: 'item' }
        }
        tree_data['for-sale']['additionalParameters'] = {
            'children': {
                'appliances': { name: 'Appliances', type: 'item' },
                'arts-crafts': { name: 'Arts & Crafts', type: 'item' },
                'clothing': { name: 'Clothing', type: 'item' },
                'computers': { name: 'Computers', type: 'item' },
                'jewelry': { name: 'Jewelry', type: 'item' },
                'office-business': { name: 'Office & Business', type: 'item' },
                'sports-fitness': { name: 'Sports & Fitness', type: 'item' }
            }
        }
        tree_data['vehicles']['additionalParameters'] = {
            'children': {
                'cars': { name: 'Cars', type: 'folder' },
                'motorcycles': { name: 'Motorcycles', type: 'item' },
                'boats': { name: 'Boats', type: 'item' }
            }
        }
        tree_data['vehicles']['additionalParameters']['children']['cars']['additionalParameters'] = {
            'children': {
                'classics': { name: 'Classics111', type: 'item' },
                'convertibles': { name: 'Convertibles', type: 'item' },
                'coupes': { name: 'Coupes', type: 'item' },
                'hatchbacks': { name: 'Hatchbacks', type: 'item' },
                'hybrids': { name: 'Hybrids', type: 'item' },
                'suvs': { name: 'SUVs', type: 'item' },
                'sedans': { name: 'Sedans', type: 'item' },
                'trucks': { name: 'Trucks', type: 'item' }
            }
        }

        tree_data['rentals']['additionalParameters'] = {
            'children': {
                'apartments-rentals': { name: 'Apartments', type: 'item' },
                'office-space-rentals': { name: 'Office Space', type: 'item' },
                'vacation-rentals': { name: 'Vacation Rentals', type: 'item' }
            }
        }
        tree_data['real-estate']['additionalParameters'] = {
            'children': {
                'apartments': { name: 'Apartments', type: 'item' },
                'villas': { name: 'Villas', type: 'item' },
                'plots': { name: 'Plots', type: 'item' }
            }
        }
        tree_data['pets']['additionalParameters'] = {
            'children': {
                'cats': { name: 'Cats', type: 'item' },
                'dogs': { name: 'Dogs', type: 'item' },
                'horses': { name: 'Horses', type: 'item' },
                'reptiles': { name: 'Reptiles', type: 'item' }
            }
        }

        var treeDataSource = new DataSourceTree({ data: tree_data });


        //ajax
        //var remoteUrl = '/business/function/getFuncsTreeAll';
        //var remoteDateSource = function (options, callback) {
        //                callback({ data: "" })
        //    alert(2);
        //    var parent_id = null
        //    if (!('text' in options || 'type' in options)) {
        //        parent_id = "0000";//load first level data
        //    }
        //    else if ('type' in options && options['type'] == 'folder') {//it has children
        //        if ('additionalParameters' in options && 'children' in options.additionalParameters)
        //            parent_id = options.additionalParameters['id']
        //    }

        //    if (parent_id !== null) {//根据父节点id，请求子节点
        //        alert(1);
        //        //$.ajax({
        //        //    url: remoteUrl,
        //        //    data: 'parent_id=' + parent_id,
        //        //    type: 'POST',
        //        //    dataType: 'json',
        //        //    success: function (response) {
        //        //        if (response.status == "OK")
        //        //            callback({ data: response.data })
        //        //    },
        //        //    error: function (response) {
        //        //        //console.log(response);
        //        //    }
        //        //})
        //    }
        //}
        //ajax end


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

        //$('#tree2').ace_tree({
        //    dataSource: treeDataSource2,
        //    loadingHTML: '<div class="tree-loading"><i class="icon-refresh icon-spin blue"></i></div>',
        //    'open-icon': 'icon-folder-open',
        //    'close-icon': 'icon-folder-close',
        //    'selectable': false,
        //    'selected-icon': null,
        //    'unselected-icon': null
        //});




        $('#tree1').on('loaded', function (evt, data) {
        });

        $('#tree1').on('opened', function (evt, data) {
            console.log("data", data);
            console.log("evt", evt);
            requestService.getobj("DictionaryTrees", data.id).then(function (data) {
                $scope.nodeData = data;
                //$scope.$broadcast("nodeData", data);
            });
        });

        $('#tree1').on('closed', function (evt, data) {
        });

        $('#tree1').on('selected', function (evt, data) {
            console.log("data", data);
            console.log("evt", evt);
            requestService.getobj("DictionaryTrees", data.info[0].id).then(function (data) {
                $scope.nodeData = data;
                //$scope.$broadcast("nodeData", data);
            });
        });



    });//end