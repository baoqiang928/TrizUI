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
    public class FunEleMutualReactsController : ApiController
    {
        // GET api/FunEleMutualReacts/5
        //public FunEleMutualReactInfo Get(string id)
        //{
        //    return new FunEleMutualReactLogic().GetByID(id);
        //}

        public List<FunEleMutualReactInfo> Get([FromUri]string ProjectID)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            return new FunEleMutualReactLogic().Query(ProjectID, 1, 9999, ref TotalItems, ref PagesLength);
        }


        // GET api/FunEleMutualReacts
        public object Get([FromUri]string PositiveEleName, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<FunEleMutualReactInfo> FunEleMutualReactInfoList = new FunEleMutualReactLogic().Query(PositiveEleName, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = FunEleMutualReactInfoList
            };
        }

        // POST api/FunEleMutualReacts
        public void Post([FromBody]FunEleMutualReactInfo FunEleMutualReactInfo)
        {
            new FunEleMutualReactLogic().SaveFunEleMutualReact(FunEleMutualReactInfo);
        }

        public void Put([FromBody]List<FunEleMutualReactInfo> FunEleMutualReactList)
        {
            foreach(FunEleMutualReactInfo FunEleMutualReactInfo in FunEleMutualReactList)
               new FunEleMutualReactLogic().SaveFunEleMutualReact(FunEleMutualReactInfo);
        }

        //public void Put([FromBody]FunEleMutualReactInfo FunEleMutualReactInfo)
        //{
        //    new FunEleMutualReactLogic().SaveFunEleMutualReact(FunEleMutualReactInfo);
        //}

        // DELETE api/FunEleMutualReacts/5
        public void Delete(int id)
        {
            new FunEleMutualReactLogic().DeleteFunEleMutualReact(id);            
        }

        // DELETE api/FunEleMutualReacts/5
        public void Delete(string ids)
        {
            new FunEleMutualReactLogic().DeleteFunEleMutualReact(ids);
        }

    }
}


