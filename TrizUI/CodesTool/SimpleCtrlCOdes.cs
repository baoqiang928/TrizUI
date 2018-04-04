using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class SimpleCtrlCodes
    {
        #region MyRegion
        string codes = @"
        $scope.{ObjName} = function()
        {
            {property}
        }

        $scope.{ObjName}List = [];

        $scope.data = {
            currentPage: "",
            itemsPerPage: "",
            ProjectID: locals.get(""ProjectID"")
        };

        var Get{ObjName}List = function () {
            $scope.data.currentPage = 1;
            $scope.data.itemsPerPage = ""999"";
            requestService.lists({Sources}, $scope.data).then(function (data)
        {
                $scope.{ObjName}List = data.Results;
        });
        }

        Get{ObjName}List();

        $scope.Add{ObjName} = function()
        {
            var newobj = new $scope.{ObjName}();
            $scope.{ObjName}List.push(newobj);
        }

        $scope.Delete{ObjName} = function(index)
        {
            bootbox.confirm(""要删除当前的记录？"", function(result) {
                if (result)
                {
                    requestService.delete({Sources}, scope.{ObjName}List[Index].ID).then(function (data) { });
                    $scope.{ObjName}List.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.Save = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}
            for (var i = 0; i < $scope.{ObjName}List[i].length; i++) {
                requestService.add({Sources}, $scope.{ObjName}List[i]).then(function (data) {
                    if ($scope.{ObjName}List[i].ID == "") {
                        $scope.{ObjName}List[i].ID = data;
                    }
                });
            }
        };
";
        #endregion

        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            codes = codes.Replace("{ObjName}", BusinessObjectInfoList[0].ObjName);
            string CodeSection = "";
            foreach (var BusinessObjectInfo in BusinessObjectInfoList)
            {
                CodeSection += @"
                         {BusinessObjectInfo.Name}: """";";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
            }

            codes = codes.Replace("{property}", CodeSection);
            codes = codes.Replace("{Sources}", BusinessObjectInfoList[0].ObjName.Replace("Info","s"));
            return codes;
        }
    }
}
