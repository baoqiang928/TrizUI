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
    public class FunctionElementsController : ApiController
    {
        // GET api/FunctionElements/5
        public FunctionElementInfo Get(string id)
        {
            return new FunctionElementLogic().GetByID(id);
        }

        // GET api/FunctionElements/5
        public object Get([FromUri]int projectID)
        {
            string json = new FunctionElementLogic().ScanTree(projectID.ToString());
            return new
            {
                json = json,
                ProjectID = projectID
            };
        }

        // GET api/FunctionElements
        public object Get([FromUri]string ProjectID, string EleName, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<FunctionElementInfo> FunctionElementInfoList = new FunctionElementLogic().Query(ProjectID, EleName, currentPage, itemsPerPage, ref TotalItems, ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = FunctionElementInfoList
            };
        }

        // POST api/FunctionElements
        public void Post([FromBody]FunctionElementInfo FunctionElementInfo)
        {
            new FunctionElementLogic().SaveFunctionElement(FunctionElementInfo);
        }

        public void Put([FromBody]FunctionElementInfo FunctionElementInfo)
        {
            new FunctionElementLogic().SaveFunctionElement(FunctionElementInfo);
        }

        // DELETE api/FunctionElements/5
        public void Delete(int id)
        {
            new FunctionElementLogic().DeleteFunctionElement(id);
        }

        // DELETE api/FunctionElements/5
        public void Delete(string ids)
        {
            new FunctionElementLogic().DeleteFunctionElement(ids);
        }

    }
}


