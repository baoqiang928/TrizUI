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
    public class StandardSolutionsController : ApiController
    {
        // GET api/StandardSolutions/5
        public StandardSolutionInfo Get(string id)
        {
            return new StandardSolutionLogic().GetByID(id);
        }

        // GET api/StandardSolutions
        public object Get([FromUri]string ProjectID,string Name,string Note,string Remark,string TypeID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<StandardSolutionInfo> StandardSolutionInfoList = new StandardSolutionLogic().Query(ProjectID,Name,Note,Remark,TypeID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = StandardSolutionInfoList
            };
        }

        // POST api/StandardSolutions
        public void Post([FromBody]StandardSolutionInfo StandardSolutionInfo)
        {
            new StandardSolutionLogic().SaveStandardSolution(StandardSolutionInfo);
        }

        public void Put([FromBody]StandardSolutionInfo StandardSolutionInfo)
        {
            new StandardSolutionLogic().SaveStandardSolution(StandardSolutionInfo);
        }

        // DELETE api/StandardSolutions/5
        public void Delete(int id)
        {
            new StandardSolutionLogic().DeleteStandardSolution(id);
        }

        // DELETE api/StandardSolutions/5
        public void Delete(string ids)
        {
            new StandardSolutionLogic().DeleteStandardSolution(ids);
        }

    }
}


