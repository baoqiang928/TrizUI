using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class ListHtmlPageCodes
    {
        #region codes
        string codes = @"<div class=""page-content"" ng-controller=""{BusinessObjectInfo.ObjName}Ctrl"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <!-- PAGE CONTENT BEGINS -->
            <div class=""row"">
                <div class=""col-xs-12"">
                    <h3 class=""header smaller lighter blue"">项目管理</h3>
                    {QueryControl}

                    <p>
                        <button class=""btn btn-primary"" ng-click=""Query()"">查询</button>
                        <button class=""btn btn-primary"" ui-sref=""{BusinessObjectInfo.ObjName}Add"">增加</button>
                        <button class=""btn btn-primary"" ng-click=""BatchDelete()"">删除</button>
                    </p>
                    <div class=""table-responsive"">
                        <table id=""sample-table-2111"" class=""table table-striped table-bordered table-hover"">
                            <thead>
                                <tr>
                                    <th class=""center"">
                                        <label>
                                            <input type=""checkbox"" class=""ace"" ng-model=""all"" ng-checked=""one""/>
                                            <span class=""lbl""></span>
                                        </label>
                                    </th>
                                    {ListItems}
                                    <th></th>
                                </tr>
                            </thead>

                            <tbody>
                                
                                <tr ng-repeat=""{BusinessObjectInfo.ObjName} in {BusinessObjectInfo.ObjName}s"">
                                    <td class=""center"">
                                        <label>
                                            <input type=""checkbox"" class=""ace"" name=""ck"" id=""{{{BusinessObjectInfo.ObjName}.ID}}"" value=""{{{BusinessObjectInfo.ObjName}.ID}}"" ng-checked=""all"" ng-click=""updateSelection($event,{BusinessObjectInfo.ObjName}.ID)"" />
                                            <span class=""lbl""></span>
                                        </label>
                                    </td>

                                    {ListColNames}

                                    <td>
                                        <div class=""visible-md visible-lg hidden-sm hidden-xs action-buttons"">

                                            <a class=""green"" href="""" ng-click=""Update({BusinessObjectInfo.ObjName}.ID)"">
                                                <i class=""icon-pencil bigger-130"">修改</i>
                                            </a>

                                            <a class=""red"" href=""#"" ng-click=""Delete({BusinessObjectInfo.ObjName}.ID)"">
                                                <i class=""icon-trash bigger-130"">删除</i>
                                            </a>

                                            <a class=""red"" href=""#"">
                                                <i class=""icon-legal bigger-130"">当前项目</i>
                                            </a>

                                        </div>


                                    </td>
                                </tr>

                                <tr>
                                    <td colspan=""999"">
                                        <tm-pagination conf=""paginationConf""></tm-pagination>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
            <!-- PAGE CONTENT ENDS -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</div>

<!-- inline scripts related to this page -->

";
        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            int i = 0;
            bool HaveEnded = false;
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Query)) continue;

                if (i == 0)
                {
                    CodeSection += "<p>";
                }

                CodeSection += @"
                        <label style=""display: inline-block; width: 60px; text-align: right;"">{BusinessObjectInfo.Description}</label>
                        <input type=""text"" ng-model=""data.{BusinessObjectInfo.Name}"" />                    
                    ".Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);

                if (i == 1)
                {
                    CodeSection += "</p>";
                    HaveEnded = true;
                    i = 0;
                    continue;
                }
                i = i + 1;
                HaveEnded = false;
            }

            if (!HaveEnded)
            {
                CodeSection += "</p>";
            }

            codes = codes.Replace("{QueryControl}", CodeSection);

            //列头
            CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.List)) continue;

                CodeSection += @"
                        <th>{BusinessObjectInfo.Description}</th>                  
                    ".Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);
            }
            codes = codes.Replace("{ListItems}", CodeSection);

            //绑定字段
            CodeSection = "";
            i=0;
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.List)) continue;

                if (i == 0)
                {
                    CodeSection += @"
                                    <td>
                                        <a href="""" ng-click=""Update({BusinessObjectInfo.ObjName}.ID)"">{{{BusinessObjectInfo.ObjName}.{BusinessObjectInfo.Name}}}</a>
                                    </td>
                    ".Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);
                    i = i + 1;
                    continue;
                }

                CodeSection += @"
                        <td>{{{BusinessObjectInfo.ObjName}.{BusinessObjectInfo.Name}}}</td>                  
                    ".Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description);
            }
            codes = codes.Replace("{ListColNames}", CodeSection);



            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName);
            return codes;
        }
    }
}
