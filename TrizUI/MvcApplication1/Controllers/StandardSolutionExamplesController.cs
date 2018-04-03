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
    public class StandardSolutionExamplesController : ApiController
    {
        // GET api/StandardSolutionExamples/5
        public StandardSolutionExampleInfo Get(string id)
        {
            return new StandardSolutionExampleLogic().GetByID(id);
        }

        public object Get([FromUri]int ProjectID,string TypeID)
        {
            string json = new StandardSolutionExampleLogic().GetTreeData(ProjectID.ToString(), TypeID);
            return new
            {
                json = json,
                ProjectID = ProjectID
            };
        }

        // GET api/StandardSolutionExamples
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<StandardSolutionExampleInfo> StandardSolutionExampleInfoList = new StandardSolutionExampleLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = StandardSolutionExampleInfoList
            };
        }

        // POST api/StandardSolutionExamples
        public int Post([FromBody]StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            return new StandardSolutionExampleLogic().SaveStandardSolutionExample(StandardSolutionExampleInfo);
        }

        public void Put([FromBody]StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            new StandardSolutionExampleLogic().SaveStandardSolutionExample(StandardSolutionExampleInfo);
        }

        // DELETE api/StandardSolutionExamples/5
        public void Delete(int id)
        {
            new StandardSolutionExampleLogic().DeleteStandardSolutionExample(id);
        }

        // DELETE api/StandardSolutionExamples/5
        public void Delete(string ids)
        {
            new StandardSolutionExampleLogic().DeleteStandardSolutionExample(ids);
        }

    }
}


