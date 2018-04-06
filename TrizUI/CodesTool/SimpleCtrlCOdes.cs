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
            requestService.lists(""{Sources}"", $scope.data).then(function (data)
        {
                $scope.{ObjName}List = data.Results;
                if ($scope.{ObjName}List.length == 0) {
                    $scope.{ObjName}List.push(new $scope.{ObjName}());
                }
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
                    requestService.delete(""{Sources}"", $scope.{ObjName}List[index].ID).then(function (data) { });
                    $scope.{ObjName}List.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
        $scope.Save = function () {
            //if (!$('#validation-form').valid()) {
            //    return false;
            //}
            
            for (var i = 0; i < $scope.{ObjName}List.length; i++) {
                var {ObjName} = $scope.{ObjName}List[i];
                {ObjName}.SerialNum = i;
                requestService.add(""{Sources}"", {ObjName}).then(function (data) {
                    if ({ObjName}.ID == "") {
                        {ObjName}.ID = data;
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
                         this.{BusinessObjectInfo.Name}= """";";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
            }

            codes = codes.Replace("{property}", CodeSection);
            codes = codes.Replace("{Sources}", BusinessObjectInfoList[0].ObjName.Replace("Info","s"));
            return codes;
        }
    }
}
