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
    public class TechnicalConflictResolvesController : ApiController
    {
        // GET api/TechnicalConflictResolves/5
        public TechnicalConflictResolveInfo Get(string id)
        {
            return new TechnicalConflictResolveLogic().GetByID(id);
        }

        // GET api/TechnicalConflictResolves
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<TechnicalConflictResolveInfo> TechnicalConflictResolveInfoList = new TechnicalConflictResolveLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = TechnicalConflictResolveInfoList
            };
        }

        // POST api/TechnicalConflictResolves
        public int Post([FromBody]TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
            return new TechnicalConflictResolveLogic().SaveTechnicalConflictResolve(TechnicalConflictResolveInfo);
        }

        public int Put([FromBody]TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
            return new TechnicalConflictResolveLogic().SaveTechnicalConflictResolve(TechnicalConflictResolveInfo);
        }

        // DELETE api/TechnicalConflictResolves/5
        public void Delete(int id)
        {
            new TechnicalConflictResolveLogic().DeleteTechnicalConflictResolve(id);
        }

        // DELETE api/TechnicalConflictResolves/5
        public void Delete(string ids)
        {
            new TechnicalConflictResolveLogic().DeleteTechnicalConflictResolve(ids);
        }

    }
}


