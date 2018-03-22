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
    public class CauseEffectCurProblemsController : ApiController
    {
        // GET api/CauseEffectCurProblems/5
        public CauseEffectCurProblemInfo Get(string id)
        {
            return new CauseEffectCurProblemLogic().GetByProjectID(id);
        }

        // GET api/CauseEffectCurProblems
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<CauseEffectCurProblemInfo> CauseEffectCurProblemInfoList = new CauseEffectCurProblemLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = CauseEffectCurProblemInfoList
            };
        }

        // POST api/CauseEffectCurProblems
        public void Post([FromBody]CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {
            new CauseEffectCurProblemLogic().SaveCauseEffectCurProblem(CauseEffectCurProblemInfo);
        }

        public void Put([FromBody]CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {
            new CauseEffectCurProblemLogic().SaveCauseEffectCurProblem(CauseEffectCurProblemInfo);
        }

        // DELETE api/CauseEffectCurProblems/5
        public void Delete(int id)
        {
            new CauseEffectCurProblemLogic().DeleteCauseEffectCurProblem(id);
        }

        // DELETE api/CauseEffectCurProblems/5
        public void Delete(string ids)
        {
            new CauseEffectCurProblemLogic().DeleteCauseEffectCurProblem(ids);
        }

    }
}


