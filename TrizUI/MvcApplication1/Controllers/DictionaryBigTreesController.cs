using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class DictionaryBigTreesController : ApiController
    {
        // GET api/DictionaryTrees/5
        public DictionaryTreeInfo Get([FromUri]string id)
        {
            return new DictionaryTreeLogic().GetByID(id);
        }
        public class a
        {
            public string id = "";
            public string name = "";
            public bool isParent = true;
        }
        public object Get([FromUri]string SonID, string OpeType)
        {
            if (OpeType == "GetFatherID")
            {
                return new DictionaryTreeLogic().GetByID(new DictionaryTreeLogic().GetFatherID(SonID));
            }
            if (OpeType == "GetDevidePrincipleInfo")
            {
                return new DictionaryTreeLogic().GetDevidePrincipleInfoByInventivePrincipleID(SonID);
            }

            return new object();
        }
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


