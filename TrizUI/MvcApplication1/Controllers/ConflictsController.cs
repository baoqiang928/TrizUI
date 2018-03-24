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
    public class ConflictsController : ApiController
    {
        // GET api/Conflicts/5
        public ConflictInfo Get(string id)
        {
            return new ConflictLogic().GetByID(id);
        }

        // GET api/Conflicts
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ConflictInfo> ConflictInfoList = new ConflictLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ConflictInfoList
            };
        }

        // POST api/Conflicts
        public void Post([FromBody]ConflictInfo ConflictInfo)
        {
            new ConflictLogic().SaveConflict(ConflictInfo);
        }

        public void Put([FromBody]ConflictInfo ConflictInfo)
        {
            new ConflictLogic().SaveConflict(ConflictInfo);
        }

        // DELETE api/Conflicts/5
        public void Delete(int id)
        {
            new ConflictLogic().DeleteConflict(id);
        }

        // DELETE api/Conflicts/5
        public void Delete(string ids)
        {
            new ConflictLogic().DeleteConflict(ids);
        }

    }
}


