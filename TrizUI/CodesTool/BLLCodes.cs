using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class BLLCodes
    {
        #region codes
        string codes = @"using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class {BusinessObjectInfo.ObjName}Logic
    {
        public void Delete{BusinessObjectInfo.ObjName}(int id)
        {
            new {BusinessObjectInfo.ObjName}DAL().Delete(id);
        }

        public void Delete{BusinessObjectInfo.ObjName}(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new {BusinessObjectInfo.ObjName}DAL().Delete(int.Parse(id));
            }
        }

        public int Save{BusinessObjectInfo.ObjName}({BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
            if ({BusinessObjectInfo.ObjName}Info.ID == null)
            {
                return new {BusinessObjectInfo.ObjName}DAL().Add({BusinessObjectInfo.ObjName}Info);
            }
            new {BusinessObjectInfo.ObjName}DAL().Update({BusinessObjectInfo.ObjName}Info);
            return {BusinessObjectInfo.ObjName}Info.ID ?? 0;
        }

        public {BusinessObjectInfo.ObjName}Info GetByID(string ID)
        {
           return new {BusinessObjectInfo.ObjName}DAL().GetByID(int.Parse(ID));
        }
        public List<{BusinessObjectInfo.ObjName}Info> Query({QueryParamsDefine}, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new {BusinessObjectInfo.ObjName}DAL().Query({QueryParams}, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}

";
        #endregion
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            string CodeSection1 = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Query)) continue;
                CodeSection += "string " + BusinessObjectInfo.Name + ",";
                CodeSection1 += BusinessObjectInfo.Name + ",";
            }
            CodeSection = CodeSection.TrimEnd(',');
            CodeSection1 = CodeSection1.TrimEnd(',');

            codes = codes.Replace("{QueryParamsDefine}", CodeSection);
            codes = codes.Replace("{QueryParams}", CodeSection1);


            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName);
            return codes;
        }
    }
}
