using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class FunctionElementLogic
    {
        public void DeleteFunctionElement(int id)
        {
            new FunctionElementDAL().Delete(id);
        }
        public List<FunctionElementInfo> QueryLeafs(string projectID)
        {
            //清除所有非叶子节点的坐标
            ClearCoordinationNotLeaf(int.Parse(projectID));
            List<FunctionElementInfo> leaflist = new FunctionElementDAL().QueryLeafs(int.Parse(projectID));
            //删除所有非叶子节点关系
            new FunEleMutualReactLogic().DeleteAllNoWithinLeafs(leaflist);
            return leaflist;
        }

        public void DeleteFunctionElement(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new FunctionElementDAL().Delete(int.Parse(id));
            }
        }

        public void SetElementGod(string id)
        {
            new FunctionElementDAL().SetElementGod(int.Parse(id));
        }

        public int SaveFunctionElement(FunctionElementInfo FunctionElementInfo)
        {
            if (FunctionElementInfo.ID == null)
            {
                //根据name找ID
                int total = 0;
                int pageslenth = 0;
                List<FunctionElementInfo> FunctionElementList = Query(FunctionElementInfo.ProjectID.ToString(), FunctionElementInfo.EleName, 1, 9999, ref total, ref pageslenth);
                if (FunctionElementList.Count > 1)
                    return 0;
                if (FunctionElementList.Count == 0)
                {
                    return new FunctionElementDAL().Add(FunctionElementInfo);
                }
                if (FunctionElementList.Count == 1)
                    FunctionElementInfo.ID = FunctionElementList[0].ID;
            }
            new FunctionElementDAL().Update(FunctionElementInfo);
            return FunctionElementInfo.ID ?? 0;
        }



        public FunctionElementInfo GetByID(string ID)
        {
            return new FunctionElementDAL().GetByID(int.Parse(ID));
        }
        public List<FunctionElementInfo> Query(string ProjectID, string EleName, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new FunctionElementDAL().Query(ProjectID, EleName, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

        public string ScanTree(string ProjectID)
        {
            List<FunctionElementInfo> Fathers = GetFathers(ProjectID);
            foreach (FunctionElementInfo Father in Fathers)
            {
                Json = Json + GetJson(Father, false) + ",";
                FindSons(Father);
            }
            Json = "[" + Json.TrimEnd(',').Replace(",]", "]") + "]";
            return Json;
        }
        //public string json = "{'id':{id},'title':'{title}','nodes':[]}";
        public string Json = "";
        private string GetJson(FunctionElementInfo ElementInfo, bool half)
        {
            //return "{'id':" + ElementInfo.ID + ",'title':'" + ElementInfo.EleName + "','nodes':[]}";
            string halfJsonItem = "{'id':{id},'title':'{title}','ID':'{DID}','ProjectID':'{ProjectID}','EleName':'{EleName}','ElementType':'{ElementType}','EleX':'{EleX}','EleY':'{EleY}','Remark':'{Remark}','nodes':[";
            if (half)
            {
                return halfJsonItem.Replace("{id}", ElementInfo.ID.ToString()).Replace("{title}", ElementInfo.EleName).Replace("{DID}", ElementInfo.ID.ToString()).Replace("{ProjectID}", ElementInfo.ProjectID.ToString()).Replace("{EleName}", ElementInfo.EleName).Replace("{ElementType}", ElementInfo.ElementType).Replace("{EleX}", ElementInfo.EleX).Replace("{EleY}", ElementInfo.EleY).Replace("{Remark}", ElementInfo.Remark);

            }
            string jsonItem = halfJsonItem + "]}";
            //return "{'id':" + ElementInfo.ID + ",'title':'" + ElementInfo.EleName + "','ID':'" + ElementInfo.ID + "','ProjectID':'" + ElementInfo.ProjectID + "','EleName':'" + ElementInfo.EleName + "','ElementType':'" + ElementInfo.ElementType + "','EleX':'" + ElementInfo.EleX + "','EleY':'" + ElementInfo.EleY + "','Remark':'" + ElementInfo.Remark + "','nodes':[]}";
            return jsonItem.Replace("{id}", ElementInfo.ID.ToString()).Replace("{title}", ElementInfo.EleName).Replace("{DID}", ElementInfo.ID.ToString()).Replace("{ProjectID}", ElementInfo.ProjectID.ToString()).Replace("{EleName}", ElementInfo.EleName).Replace("{ElementType}", ElementInfo.ElementType).Replace("{EleX}", ElementInfo.EleX).Replace("{EleY}", ElementInfo.EleY).Replace("{Remark}", ElementInfo.Remark);
        }

        /// <summary>
        /// 清除所有非叶子节点的坐标
        /// </summary>
        /// <param name="projectID"></param>
        public void ClearCoordinationNotLeaf(int projectID)
        {
            new FunctionElementDAL().ClearCoordinationNotLeaf(projectID);
        }
        private void AddSon(FunctionElementInfo fatherElementInfo, FunctionElementInfo sonElementInfo)
        {
            //string str = "{'id':" + fatherElementInfo.ID + ",'title':'" + fatherElementInfo.EleName + "','nodes':["; //故意少了2个】}替换使用。
            string str = GetJson(fatherElementInfo, true);
            int i = Json.IndexOf(str);
            string aa = GetJson(sonElementInfo, false);
            Json = Json.Replace(str, str + GetJson(sonElementInfo, false) + ",");
        }

        public void FindSons(FunctionElementInfo ElementInfo)
        {
            List<FunctionElementInfo> SonList = GetSons(ElementInfo.ID.ToString());
            if (SonList.Count == 0) return;
            foreach (FunctionElementInfo Son in SonList)
            {
                AddSon(ElementInfo, Son);
                FindSons(Son);
            }
        }

        private List<FunctionElementInfo> GetFathers(string ProjectID)
        {
            return new FunctionElementDAL().GetFathers(ProjectID);
        }
        private List<FunctionElementInfo> GetSons(string ProjectID)
        {
            return new FunctionElementDAL().GetSons(ProjectID);
        }

        public void CreateBasicRootNodes(int? ProjectID)
        {
            FunctionElementInfo FunctionElementInfo = new FunctionElementInfo();
            FunctionElementInfo.ProjectID = ProjectID;
            FunctionElementInfo.EleName = "整体系统";
            FunctionElementInfo.ElementType = "整体系统";
            SaveFunctionElement(FunctionElementInfo);

            FunctionElementInfo = new FunctionElementInfo();
            FunctionElementInfo.ProjectID = ProjectID;
            FunctionElementInfo.EleName = "制品";
            FunctionElementInfo.ElementType = "制品";
            SaveFunctionElement(FunctionElementInfo);

            FunctionElementInfo = new FunctionElementInfo();
            FunctionElementInfo.ProjectID = ProjectID;
            FunctionElementInfo.EleName = "超系统";
            FunctionElementInfo.ElementType = "超系统";
            SaveFunctionElement(FunctionElementInfo);
        }
    }
}



