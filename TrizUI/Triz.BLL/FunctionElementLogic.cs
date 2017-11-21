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
           return new FunctionElementDAL().QueryLeafs(int.Parse(projectID));
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
                Json = Json + GetJson(Father) + ",";
                FindSons(Father);
            }
            Json = "[" + Json.TrimEnd(',').Replace(",]", "]") + "]";
            return Json;
        }
        //public string json = "{'id':{id},'title':'{title}','nodes':[]}";
        public string Json = "";
        private string GetJson(FunctionElementInfo ElementInfo)
        {
            return "{'id':" + ElementInfo.ID + ",'title':'" + ElementInfo.EleName + "','nodes':[]}";
        }

        private void AddSon(FunctionElementInfo fatherElementInfo, FunctionElementInfo sonElementInfo)
        {
            string str = "{'id':" + fatherElementInfo.ID + ",'title':'" + fatherElementInfo.EleName + "','nodes':["; //故意少了2个】}替换使用。
            int i = Json.IndexOf(str);
            string aa = GetJson(sonElementInfo);
            Json = Json.Replace(str, str + GetJson(sonElementInfo) + ",");
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
    }
}



