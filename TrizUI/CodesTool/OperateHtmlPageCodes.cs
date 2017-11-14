using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class OperateHtmlPageCodes
    {
        #region codes
        string codes = @"<div class=""page-content"" ng-controller=""{BusinessObjectInfo.ObjName}OpeCtrl"">
    <div class=""page-header"">
        <h1>{BusinessObjectInfo.ObjDes}信息维护
        </h1>
    </div>
    <!-- /.page-header -->
    <div class=""row"">
        <div class=""col-xs-12"">
            <!-- PAGE CONTENT BEGINS -->
            <form class=""form-horizontal"" id=""validation-form"" role=""form"">
            
                {OperateItem}

                <div class=""space-4""></div>

                <div class=""clearfix form-actions"">
                    <div class=""col-md-offset-3 col-md-9"">
                        <button class=""btn btn-info"" type=""button"" ng-click=""Save()"">
                            <i class=""icon-ok bigger-110""></i>
                            保存
                        </button>
                        &nbsp; &nbsp; &nbsp;
						<button class=""btn"" id=""BtnGetQRCode"" type=""reset"" onclick=""window.history.back()"">
                            <i class=""icon-arrow-left bigger-110""></i>
                            返回
                        </button>
                    </div>
                </div>

            </form>

            <!-- PAGE CONTENT ENDS -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</div>

";
        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Description
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Operate)) continue;
                string ngif = "";
                if (BusinessObjectInfo.Name.Contains("CreateDateTime")) ngif = "ng-if=\"data.CreateDateTime != ''\"";
                CodeSection += @"
                <div class=""form-group"" {ng-if}>
                    <label class=""col-sm-3 control-label no-padding-right"" for=""form-field-1"">{BusinessObjectInfo.Description}</label>

                    <div class=""col-sm-9"">
                        <div class=""clearfix"">
                            <input type=""text"" id=""{id}"" name=""{name}"" class=""col-xs-10 col-sm-5"" data-ng-model=""data.{BusinessObjectInfo.Name}"" />
                        </div>
                    </div>
                </div>                                        
                    ".Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{BusinessObjectInfo.Description}", BusinessObjectInfo.Description).Replace("{id}", BusinessObjectInfo.Name).Replace("{name}", BusinessObjectInfo.Name).Replace("{ng-if}", ngif);
            }

            codes = codes.Replace("{OperateItem}", CodeSection);
            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName).Replace("{BusinessObjectInfo.ObjDes}", BusinessObjectInfoList[0].ObjDes);
            return codes;
        }
    }
}
