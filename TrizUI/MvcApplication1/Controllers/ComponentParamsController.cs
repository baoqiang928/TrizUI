using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class ComponentParamsController : ApiController
    {
        // GET api/ComponentParams/5
        public ComponentParamInfo Get(string id)
        {
            return new ComponentParamLogic().GetByID(id);
        }

        // GET api/ComponentParams
        public object Get([FromUri]string ProjectID,string ParamType,string Disabled, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ComponentParamInfo> ComponentParamInfoList = new ComponentParamLogic().Query(ProjectID,ParamType,Disabled, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ComponentParamInfoList
            };
        }

        // POST api/ComponentParams
        public void Post([FromBody]ComponentParamInfo ComponentParamInfo)
        {
            new ComponentParamLogic().SaveComponentParam(ComponentParamInfo);
        }

        public void Put([FromBody]ComponentParamInfo ComponentParamInfo)
        {
            new ComponentParamLogic().SaveComponentParam(ComponentParamInfo);
        }

        // DELETE api/ComponentParams/5
        public void Delete(int id)
        {
            new ComponentParamLogic().DeleteComponentParam(id);
        }

        // DELETE api/ComponentParams/5
        public void Delete(string ids)
        {
            new ComponentParamLogic().DeleteComponentParam(ids);
        }

    }
}


