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
    public class ConflictMatrixsController : ApiController
    {
        // GET api/ConflictMatrixs/5
        public ConflictMatrixInfo Get(string id)
        {
            return new ConflictMatrixLogic().GetByID(id);
        }
        public object Get([FromUri]string ImproveCharacter, string DeteriorateCharacter)
        {
            List<ConflictMatrixInfo> ConflictMatrixInfoList = new ConflictMatrixLogic().Query(ImproveCharacter, DeteriorateCharacter);
            if (ConflictMatrixInfoList.Count > 0) return ConflictMatrixInfoList[0].ConflictIDs;
            return new object();
        }
        // GET api/ConflictMatrixs
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ConflictMatrixInfo> ConflictMatrixInfoList = new ConflictMatrixLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems, ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ConflictMatrixInfoList
            };
        }

        // POST api/ConflictMatrixs
        public int Post([FromBody]ConflictMatrixInfo ConflictMatrixInfo)
        {
            return new ConflictMatrixLogic().SaveConflictMatrix(ConflictMatrixInfo);
        }

        public int Put([FromBody]ConflictMatrixInfo ConflictMatrixInfo)
        {
            return new ConflictMatrixLogic().SaveConflictMatrix(ConflictMatrixInfo);
        }

        // DELETE api/ConflictMatrixs/5
        public void Delete(int id)
        {
            new ConflictMatrixLogic().DeleteConflictMatrix(id);
        }

        // DELETE api/ConflictMatrixs/5
        public void Delete(string ids)
        {
            new ConflictMatrixLogic().DeleteConflictMatrix(ids);
        }

    }
}


