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
    public class DictionaryBigTreesViewController : ApiController
    {
        // GET api/DictionaryTrees/5
        public DictionaryTreeInfo Get(string id)
        {
            return new DictionaryTreeLogic().GetByID(id);
        }

        public object Get([FromUri]string ProjectID, string TreeTypeID, string FatherIDs, string OpeType)
        {
            if (!string.IsNullOrWhiteSpace(FatherIDs)) FatherIDs = FatherIDs.Replace("\"", "");
            List<DictionaryTreeInfo> fathers = new DictionaryTreeLogic().GetFathersTreeData(ProjectID, TreeTypeID, FatherIDs);
            List<TreeNodeInfo> nodes = new List<TreeNodeInfo>();
            foreach (DictionaryTreeInfo TreeInfo in fathers)
            {
                nodes.Add(new TreeNodeInfo() { name = TreeInfo.Name, id = TreeInfo.ID.ToString(), isParent = true });
            }
            return nodes;
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
                Results = new DictionaryTreeLogic().GetBigTreeDataForZTree(FatherID)
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


        public class QueryDataInfo
        {
            private string nodeID = "";

            public string NodeID
            {
                get
                {
                    return nodeID;
                }

                set
                {
                    nodeID = value;
                }
            }
            public string nodeName = "";

            public string NodeName
            {
                get
                {
                    return nodeName;
                }

                set
                {
                    nodeName = value;
                }
            }
            public string treeLevel = "";

            public string TreeLevel
            {
                get
                {
                    return treeLevel;
                }

                set
                {
                    treeLevel = value;
                }
            }

            public string projectID = "";
            public string ProjectID
            {
                get
                {
                    return projectID;
                }

                set
                {
                    projectID = value;
                }
            }

            public string treeTypeID = "";
            public string TreeTypeID
            {
                get
                {
                    return treeTypeID;
                }

                set
                {
                    treeTypeID = value;
                }
            }

        }

        // POST api/DictionaryTrees
        public object Post([FromBody]QueryDataInfo QueryDataInfo)
        {
            if ((QueryDataInfo.NodeID == null) || (QueryDataInfo.NodeID == "")) return new object();
            return new DictionaryTreeLogic().GetBigTreeDataForZTree(int.Parse(QueryDataInfo.NodeID));
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


