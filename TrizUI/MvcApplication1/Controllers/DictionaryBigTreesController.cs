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
    public class DictionaryBigTreesController : ApiController
    {
        // GET api/DictionaryTrees/5
        public DictionaryTreeInfo Get(string id)
        {
            return new DictionaryTreeLogic().GetByID(id);
        }
        public class a {
            public string id = "";
            public string name = "";
            public bool isParent = true;
        }
        public object Get([FromUri]int ProjectID, string TreeTypeID,string OpeType)
        {
            List<a> l = new List<a>();
            for (int i = 0; i < 3; i++)
            {
                l.Add(new a() { id = i.ToString(), name = "aaa" + i.ToString(), isParent = true });
            }

            return l;
        }

        //public object Get([FromUri]int FatherID, string TreeTypeID, string OpeType)
        //{
        //    if (OpeType == "SeparationPrinciple")
        //    {
        //        return new
        //        {
        //            Results = new DictionaryTreeLogic().GetBigTreeDataForSeparationPrinciple(FatherID)
        //        };
        //    }
        //    return new { };
        //}
        public object Get([FromUri]int ProjectID, string TreeTypeID)
        {
            return new
            {
                Results = new DictionaryTreeLogic().GetBigTreeData(ProjectID.ToString(), TreeTypeID)
            };
        }
        public object Get([FromUri]int FatherID)
        {
            return new
            {
                Results = new DictionaryTreeLogic().GetBigTreeData(FatherID)
            };
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
        public object Post([FromBody]DictionaryTreeInfo DictionaryTreeInfo)
        {
            List<a> l = new List<a>();
            for (int i = 0; i < 3; i++)
            {
                l.Add(new a() { id = i.ToString(), name = "aaa" + i.ToString() });
            }

            return l;

           // return new DictionaryTreeLogic().SaveDictionaryTree(DictionaryTreeInfo);
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


