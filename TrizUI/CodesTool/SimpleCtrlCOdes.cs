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

        var newobj = new $scope.{ObjName}();
        $scope.{ObjName}List.push(newobj);

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
                    requestService.delete({Sources}, scope.ComponentRelInfoListSection[SectionIndex][Index].ID).then(function (data) { });
                    $scope.{ObjName}List.splice(index, 1);
                    $scope.$apply();
                }
            });
        }
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
