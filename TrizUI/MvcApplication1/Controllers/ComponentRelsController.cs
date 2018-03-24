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
    public class ComponentRelsController : ApiController
    {
        // GET api/ComponentRels/5
        public ComponentRelInfo Get(string id)
        {
            return new ComponentRelLogic().GetByID(id);
        }

        // GET api/ComponentRels
        public object Get([FromUri]string ProjectID,string SectionID,string ImpactParamName,string Disabled, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ComponentRelInfo> ComponentRelInfoList = new ComponentRelLogic().Query(ProjectID,SectionID,ImpactParamName,Disabled, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ComponentRelInfoList
            };
        }

        // POST api/ComponentRels
        public void Post([FromBody]ComponentRelInfo ComponentRelInfo)
        {
            new ComponentRelLogic().SaveComponentRel(ComponentRelInfo);
        }

        public void Put([FromBody]ComponentRelInfo ComponentRelInfo)
        {
            new ComponentRelLogic().SaveComponentRel(ComponentRelInfo);
        }

        // DELETE api/ComponentRels/5
        public void Delete(int id)
        {
            new ComponentRelLogic().DeleteComponentRel(id);
        }

        // DELETE api/ComponentRels/5
        public void Delete(string ids)
        {
            new ComponentRelLogic().DeleteComponentRel(ids);
        }

    }
}


