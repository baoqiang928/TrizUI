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
    public class AnalysisProceduresController : ApiController
    {
        // GET api/AnalysisProcedures/5
        public AnalysisProcedureInfo Get(string id)
        {
            return new AnalysisProcedureLogic().GetByID(id);
        }

        // GET api/AnalysisProcedures
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<AnalysisProcedureInfo> AnalysisProcedureInfoList = new AnalysisProcedureLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = AnalysisProcedureInfoList
            };
        }

        // POST api/AnalysisProcedures
        public void Post([FromBody]AnalysisProcedureInfo AnalysisProcedureInfo)
        {
            new AnalysisProcedureLogic().SaveAnalysisProcedure(AnalysisProcedureInfo);
        }

        public void Put([FromBody]AnalysisProcedureInfo AnalysisProcedureInfo)
        {
            new AnalysisProcedureLogic().SaveAnalysisProcedure(AnalysisProcedureInfo);
        }

        // DELETE api/AnalysisProcedures/5
        public void Delete(int id)
        {
            new AnalysisProcedureLogic().DeleteAnalysisProcedure(id);
        }

        // DELETE api/AnalysisProcedures/5
        public void Delete(string ids)
        {
            new AnalysisProcedureLogic().DeleteAnalysisProcedure(ids);
        }

    }
}


