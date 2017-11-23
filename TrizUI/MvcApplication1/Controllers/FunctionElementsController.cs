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
        public object Get([FromUri]int ProjectID)
        {
            string json = new FunctionElementLogic().ScanTree(ProjectID.ToString());
            return new
            {
                json = json,
                ProjectID = ProjectID
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

        /// <summary>
        /// 所有叶子节点,作用关系 使用
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public IEnumerable<FunctionElementInfo> Get([FromUri]string ProjectID, string EleName)
        {
            return new FunctionElementLogic().QueryLeafs(ProjectID);
        }

        // POST api/FunctionElements
        public int Post([FromBody]FunctionElementInfo FunctionElementInfo)
        {
            return new FunctionElementLogic().SaveFunctionElement(FunctionElementInfo);
        }

        public int Put([FromBody]FunctionElementInfo FunctionElementInfo)
        {
            return new FunctionElementLogic().SaveFunctionElement(FunctionElementInfo);
        }

        public void Put([FromUri]string FatherSonIDs)
        {
            string aa = FatherSonIDs;
            foreach (string rel in FatherSonIDs.Split('^'))
            {
                if (!rel.Contains('|')) continue;

                if (rel.Split('|')[0] == "0")
                {
                    new FunctionElementLogic().SetElementGod(rel.Split('|')[1]);
                    continue;
                }

                new FunctionElementLogic().SaveFunctionElement(new FunctionElementInfo() { ID = int.Parse(rel.Split('|')[1]), FatherID = int.Parse(rel.Split('|')[0]) });
            }
        }

        // DELETE api/FunctionElements/5
        public void Delete(int id)
        {
            new FunctionElementLogic().DeleteFunctionElement(id);
            //刪除作用關係
            new FunEleMutualReactLogic().DeleteByElementID(id);
        }

        // DELETE api/FunctionElements/5
        public void Delete(string ids)
        {
            new FunctionElementLogic().DeleteFunctionElement(ids);
        }

    }
}


