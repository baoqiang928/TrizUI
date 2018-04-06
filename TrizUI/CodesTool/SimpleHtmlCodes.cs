using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class SimpleHtmlCodes
    {
        #region MyRegion
        string codes = @"
                                <table id=""sample-table-2"" class=""table table-striped table-bordered table-hover"">
                                    <thead>
                                        <tr>
                                            <th>11111111111111111111</th>
                                            <th>2222222222222222222</th>
                                            <th>33333333333333333</th>
                                            <th>
                                                <div class=""visible-md visible-lg hidden-sm hidden-xs action-buttons"">
                                                    <a class=""blue"" style=""cursor: pointer"" ng-click=""{add_codes}"">
                                                        <i class=""icon-plus bigger-130""></i>
                                                    </a>
                                                </div>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr ng-repeat=""{ng-repeat_codes}"">
                                            {td_codes}
                                            <td>
                                                <div class=""visible-md visible-lg hidden-sm hidden-xs action-buttons"">
                                                    <a class=""blue"" style=""cursor: pointer"" ng-click=""{add_codes}"">
                                                        <i class=""icon-plus bigger-130""></i>
                                                    </a>

                                                    <a class=""red"" style=""cursor: pointer"" ng-click=""{del_codes}"">
                                                        <i class=""icon-trash bigger-130""></i>
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
";

        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string tds_codes = "";
            string td_codes = @"
<td><input type=""text"" class=""col-xs-12 col-sm-12 col-md-12"" ng-model=""{objname}.{proname}"" /></td>";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                tds_codes = tds_codes + td_codes.Replace("{objname}", BusinessObjectInfo.ObjName).Replace("{proname}", BusinessObjectInfo.Name);
            }
            codes = codes.Replace("{td_codes}",tds_codes);
            codes = codes.Replace("{ng-repeat_codes}", BusinessObjectInfoList[0].ObjName + " in "+ BusinessObjectInfoList[0].ObjName + "List|orderBy:'SerialNum'");
            codes = codes.Replace("{add_codes}", "Add"+ BusinessObjectInfoList[0].ObjName + "()");
            codes = codes.Replace("{del_codes}", "Delete"+ BusinessObjectInfoList[0].ObjName + "($index)");
            return codes;
        }


    }
}
