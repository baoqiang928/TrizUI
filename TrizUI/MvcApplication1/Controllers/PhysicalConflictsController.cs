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
    public class PhysicalConflictsController : ApiController
    {
        // GET api/PhysicalConflicts/5
        public PhysicalConflictInfo Get(string id)
        {
            return new PhysicalConflictLogic().GetByID(id);
        }

        // GET api/PhysicalConflicts
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<PhysicalConflictInfo> PhysicalConflictInfoList = new PhysicalConflictLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = PhysicalConflictInfoList
            };
        }

        // POST api/PhysicalConflicts
        public int Post([FromBody]PhysicalConflictInfo PhysicalConflictInfo)
        {
            return new PhysicalConflictLogic().SavePhysicalConflict(PhysicalConflictInfo);
        }

        public int Put([FromBody]PhysicalConflictInfo PhysicalConflictInfo)
        {
            return new PhysicalConflictLogic().SavePhysicalConflict(PhysicalConflictInfo);
        }

        // DELETE api/PhysicalConflicts/5
        public void Delete(int id)
        {
            new PhysicalConflictLogic().DeletePhysicalConflict(id);
        }

        // DELETE api/PhysicalConflicts/5
        public void Delete(string ids)
        {
            new PhysicalConflictLogic().DeletePhysicalConflict(ids);
        }

    }
}


