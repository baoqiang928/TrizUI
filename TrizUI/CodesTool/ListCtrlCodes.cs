using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class ListCtrlCodes
    {
        #region codes
        string codes = @"angular.module(""myApp"")
    .controller('{BusinessObjectInfo.ObjName}Ctrl', function ($scope, $location, requestService, $state) {
        var Sources = ""{BusinessObjectInfo.ObjName}s"";
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
            currentPage: """",
            itemsPerPage: """",
            {$scope.data.properties}
        };

        var Get{BusinessObjectInfo.ObjName}s = function () {
            $scope.data.currentPage = $scope.paginationConf.currentPage;
            $scope.data.itemsPerPage = $scope.paginationConf.itemsPerPage;
            requestService.lists(Sources, $scope.data).then(function (data) {
                $scope.{BusinessObjectInfo.ObjName}s = data.Results;
                $scope.paginationConf.totalItems = data.TotalItems;
                $scope.paginationConf.pagesLength = data.PagesLength;
            });
        }

        $scope.$watch('paginationConf.currentPage + paginationConf.itemsPerPage', Get{BusinessObjectInfo.ObjName}s);

        $scope.Query = function () {
            Get{BusinessObjectInfo.ObjName}s();
        }

        $scope.Delete = function (ID) {
            bootbox.confirm(""要删除当前的记录？"", function (result) {
                requestService.delete(Sources, ID).then(function (data) {
                    Get{BusinessObjectInfo.ObjName}s();
                });
            });
        }

        $scope.BatchDelete = function () {
            var ids = """";
            $('input[name=""ck""]:checked').each(function () {
                ids = $(this).val() + ""^"" + ids;
            });

            if (ids == """") {
                Alert(""请选择记录。"");
                return;
            }
            bootbox.confirm(""要删除选中的所有记录？"", function (result) {
                if (result) {
                    requestService.batchdelete(Sources, ids).then(function (data) {
                        Get{BusinessObjectInfo.ObjName}s();
                        $scope.one = false;
                        $scope.all = false;
                    });
                }
            });

        }

        $scope.Update = function (ID) {
            $state.go(""{BusinessObjectInfo.ObjName}Add"", { ID: ID });
        }

    });//end


";
        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Query)) continue;
                CodeSection += @"
                         {BusinessObjectInfo.Name}: """",
                    ";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
            }
            CodeSection = CodeSection.Trim().TrimEnd(',');
            codes = codes.Replace("{$scope.data.properties}", CodeSection);

            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName);
            return codes;
        }
    }
}
