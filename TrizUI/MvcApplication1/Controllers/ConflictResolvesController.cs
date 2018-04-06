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
    public class ConflictResolvesController : ApiController
    {
        // GET api/ConflictResolves/5
        public ConflictResolveInfo Get(string id)
        {
            return new ConflictResolveLogic().GetByID(id);
        }

        // GET api/ConflictResolves
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ConflictResolveInfo> ConflictResolveInfoList = new ConflictResolveLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ConflictResolveInfoList
            };
        }

        // POST api/ConflictResolves
        public int Post([FromBody]ConflictResolveInfo ConflictResolveInfo)
        {
            return new ConflictResolveLogic().SaveConflictResolve(ConflictResolveInfo);
        }

        public int Put([FromBody]ConflictResolveInfo ConflictResolveInfo)
        {
            return new ConflictResolveLogic().SaveConflictResolve(ConflictResolveInfo);
        }

        // DELETE api/ConflictResolves/5
        public void Delete(int id)
        {
            new ConflictResolveLogic().DeleteConflictResolve(id);
        }

        // DELETE api/ConflictResolves/5
        public void Delete(string ids)
        {
            new ConflictResolveLogic().DeleteConflictResolve(ids);
        }

    }
}


