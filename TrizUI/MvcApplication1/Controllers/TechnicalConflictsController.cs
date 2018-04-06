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
    public class TechnicalConflictsController : ApiController
    {
        // GET api/TechnicalConflicts/5
        public TechnicalConflictInfo Get(string id)
        {
            return new TechnicalConflictLogic().GetByID(id);
        }

        // GET api/TechnicalConflicts
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<TechnicalConflictInfo> TechnicalConflictInfoList = new TechnicalConflictLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = TechnicalConflictInfoList
            };
        }

        // POST api/TechnicalConflicts
        public int Post([FromBody]TechnicalConflictInfo TechnicalConflictInfo)
        {
            return new TechnicalConflictLogic().SaveTechnicalConflict(TechnicalConflictInfo);
        }

        public int Put([FromBody]TechnicalConflictInfo TechnicalConflictInfo)
        {
            return new TechnicalConflictLogic().SaveTechnicalConflict(TechnicalConflictInfo);
        }

        // DELETE api/TechnicalConflicts/5
        public void Delete(int id)
        {
            new TechnicalConflictLogic().DeleteTechnicalConflict(id);
        }

        // DELETE api/TechnicalConflicts/5
        public void Delete(string ids)
        {
            new TechnicalConflictLogic().DeleteTechnicalConflict(ids);
        }

    }
}


