angular.module("myApp")
    .controller('ProjectCtrl', function ($scope, $location, requestService, $state) {

        var Sources = "Projects";
        $scope.abcd = "1234";
        $scope.paginationConf = {
            currentPage: 1,
            totalItems: 8000,
            itemsPerPage: 15,
            pagesLength: 15,
            perPageOptions: [10, 20, 30, 40, 50],
            onChange: function () {
            }
        };

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            Name: "",
            Code: "",
            Owner: "",
            Department: "",
            FromDate: "",
            ToDate: ""
        };

        var GetProjects = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.projects = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', GetProjects);

        $scope.Query = function () {
            GetProjects();
        }

        $scope.Delete = function (ID) {
            requestService.delete(Sources, ID).then(function (data) {
                GetProjects();
            });
        }

        $scope.BatchDelete = function () {
            var ids = "";
            $('input[name="ck"]:checked').each(function () {
                //alert(1);
                //var sfruit=$(this).val();  
                //alert(sfruit);
                //var orders=sfruit.split(",");
            });

            //requestService.batchdelete(Sources, ids).then(function (data) {
            //    GetProjects();
            //});
        }


        $scope.Update = function (ID) {
            $state.go("ProjectAdd", { ID: ID });
        }

        $scope.selected = [];
        var updateSelected = function (action, id, name) {
            if (action == 'add' && $scope.selected.indexOf(id) == -1) {
                $scope.selected.push(id);
            }
            if (action == 'remove' && $scope.selected.indexOf(id) != -1) {
                var idx = $scope.selected.indexOf(id);
                $scope.selected.splice(idx, 1);
            }
        }

        $scope.updateSelection = function ($event, id) {
            var checkbox = $event.target;
            var action = (checkbox.checked ? 'add' : 'remove');
            updateSelected(action, id, checkbox.name);
            alert($scope.selected);
        }

        $scope.isSelected = function (id) {
            return $scope.selected.indexOf(id) >= 0;
        }

        //$("#checkall").click(
        //  function () {
        //      if (this.checked) {
        //          $("input[name='ck']").attr('checked', true);
        //      } else {
        //          $("input[name='ck']").attr('checked', false);
        //      }
        //  });

        //$(function(){  
        //    $("#checkall").click(function () {
        //        //第一种方法 全选全不选  
        //        if(this.checked){   
        //            $("input[name='ck']:checkbox").attr('checked',true);   
        //        }else{   
        //            $("input[name='ck']:checkbox").attr('checked', false);
        //        }  
        //        //第二种方法 全选全不选   
        //        $('[name=ck]:checkbox').attr('checked', this.checked);//checked为true时为默认显示的状态   
        //    });  
        //    $("#checkrev").click(function(){  
        //        //实现反选功能  
        //        $('[name=ck]:checkbox').each(function () {
        //            this.checked=!this.checked;  
        //        });  
        //    });   
        //});


    });