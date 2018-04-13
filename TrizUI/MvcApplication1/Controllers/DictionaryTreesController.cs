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
    public class DictionaryTreesController : ApiController
    {
        // GET api/DictionaryTrees/5
        public DictionaryTreeInfo Get(string id)
        {
            return new DictionaryTreeLogic().GetByID(id);
        }

        public object Get([FromUri]int ProjectID, string TreeTypeID)
        {
            string json = new DictionaryTreeLogic().GetTreeData(ProjectID.ToString(), TreeTypeID);
            return new
            {
                json = json,
                ProjectID = ProjectID
            };
        }
        public object Get([FromUri]int ProjectID, string TreeTypeID,string OpeType)
        {
            return new DictionaryTreeLogic().GetFathersTreeData(ProjectID.ToString(), TreeTypeID);
        }
        // GET api/DictionaryTrees
        //public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        //{
        //    int TotalItems = 0;
        //    int PagesLength = 0;
        //    List<DictionaryTreeInfo> DictionaryTreeInfoList = new DictionaryTreeLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
        //    return new
        //    {
        //        TotalItems = TotalItems,
        //        PagesLength = PagesLength,
        //        Results = DictionaryTreeInfoList
        //    };
        //}

        // POST api/DictionaryTrees
        public int Post([FromBody]DictionaryTreeInfo DictionaryTreeInfo)
        {
            return new DictionaryTreeLogic().SaveDictionaryTree(DictionaryTreeInfo);
        }

        public int Put([FromBody]DictionaryTreeInfo DictionaryTreeInfo)
        {
            return new DictionaryTreeLogic().SaveDictionaryTree(DictionaryTreeInfo);
        }

        // DELETE api/DictionaryTrees/5
        public void Delete(int id)
        {
            new DictionaryTreeLogic().DeleteDictionaryTree(id);
        }

        // DELETE api/DictionaryTrees/5
        public void Delete(string ids)
        {
            new DictionaryTreeLogic().DeleteDictionaryTree(ids);
        }

    }
}


