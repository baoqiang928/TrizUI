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
    public class TechEvolutionsController : ApiController
    {
        // GET api/TechEvolutions/5
        public TechEvolutionInfo Get(string id)
        {
            return new TechEvolutionLogic().GetByID(id);
        }

        // GET api/TechEvolutions
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<TechEvolutionInfo> TechEvolutionInfoList = new TechEvolutionLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = TechEvolutionInfoList
            };
        }

        // POST api/TechEvolutions
        public int Post([FromBody]TechEvolutionInfo TechEvolutionInfo)
        {
            return new TechEvolutionLogic().SaveTechEvolution(TechEvolutionInfo);
        }

        public int Put([FromBody]TechEvolutionInfo TechEvolutionInfo)
        {
            return new TechEvolutionLogic().SaveTechEvolution(TechEvolutionInfo);
        }

        // DELETE api/TechEvolutions/5
        public void Delete(int id)
        {
            new TechEvolutionLogic().DeleteTechEvolution(id);
        }

        // DELETE api/TechEvolutions/5
        public void Delete(string ids)
        {
            new TechEvolutionLogic().DeleteTechEvolution(ids);
        }

    }
}


