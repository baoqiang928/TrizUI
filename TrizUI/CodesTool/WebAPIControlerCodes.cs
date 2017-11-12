using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class WebAPIControlerCodes
    {
        #region codes
        string codes = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class {BusinessObjectInfo.ObjName}sController : ApiController
    {
        // GET api/{BusinessObjectInfo.ObjName}s/5
        public {BusinessObjectInfo.ObjName}Info Get(string id)
        {
            return new {BusinessObjectInfo.ObjName}Logic().GetByID(id);
        }

        // GET api/{BusinessObjectInfo.ObjName}s
        public object Get([FromUri]{QueryParamsDefine}, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<{BusinessObjectInfo.ObjName}Info> {BusinessObjectInfo.ObjName}InfoList = new {BusinessObjectInfo.ObjName}Logic().Query({QueryParams}, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = {BusinessObjectInfo.ObjName}InfoList
            };
        }

        // POST api/{BusinessObjectInfo.ObjName}s
        public void Post([FromBody]{BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
            new {BusinessObjectInfo.ObjName}Logic().Save{BusinessObjectInfo.ObjName}({BusinessObjectInfo.ObjName}Info);
        }

        public void Put([FromBody]{BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
            new {BusinessObjectInfo.ObjName}Logic().Save{BusinessObjectInfo.ObjName}({BusinessObjectInfo.ObjName}Info);
        }

        // DELETE api/{BusinessObjectInfo.ObjName}s/5
        public void Delete(int id)
        {
            new {BusinessObjectInfo.ObjName}Logic().Delete{BusinessObjectInfo.ObjName}(id);
        }

        // DELETE api/{BusinessObjectInfo.ObjName}s/5
        public void Delete(string ids)
        {
            new {BusinessObjectInfo.ObjName}Logic().Delete{BusinessObjectInfo.ObjName}(ids);
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
