using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class DictionaryTreeLogic
    {
        public void DeleteDictionaryTree(int id)
        {
            new DictionaryTreeDAL().Delete(id);
        }
        public string Json = "";
        private string GetJson(DictionaryTreeInfo DictionaryTreeInfo, bool half)
        {
            string halfJsonItem = "{'id':{id},'title':'{title}','ID':'{DID}','ProjectID':'{ProjectID}','Name':'{Name}','nodes':[";
            if (half)
            {
                return halfJsonItem.Replace("{id}", DictionaryTreeInfo.ID.ToString()).Replace("{title}", DictionaryTreeInfo.Name).Replace("{DID}", DictionaryTreeInfo.ID.ToString()).Replace("{ProjectID}", DictionaryTreeInfo.ProjectID.ToString()).Replace("{Name}", DictionaryTreeInfo.Name);
            }
            string jsonItem = halfJsonItem + "]}";
            return jsonItem.Replace("{id}", DictionaryTreeInfo.ID.ToString()).Replace("{title}", DictionaryTreeInfo.Name).Replace("{DID}", DictionaryTreeInfo.ID.ToString()).Replace("{ProjectID}", DictionaryTreeInfo.ProjectID.ToString()).Replace("{Name}", DictionaryTreeInfo.Name);
        }
        public string GetTreeData(string ProjectID, string TreeTypeID)
        {
            List<DictionaryTreeInfo> Fathers = GetFathers(ProjectID, TreeTypeID);
            foreach (DictionaryTreeInfo Father in Fathers)
            {
                Json = Json + GetJson(Father, false) + ",";
                FindSons(Father);
            }
            Json = "[" + Json.TrimEnd(',').Replace(",]", "]") + "]";
            return Json;
        }
        public void FindSons(DictionaryTreeInfo DictionaryTreeInfo)
        {
            List<DictionaryTreeInfo> SonList = GetSons(DictionaryTreeInfo.ID.ToString());
            if (SonList.Count == 0) return;
            foreach (DictionaryTreeInfo Son in SonList)
            {
                AddSon(DictionaryTreeInfo, Son);
                FindSons(Son);
            }
        }
        private void AddSon(DictionaryTreeInfo fatherInfo, DictionaryTreeInfo sonInfo)
        {
            string str = GetJson(fatherInfo, true);
            int i = Json.IndexOf(str);
            string aa = GetJson(sonInfo, false);
            Json = Json.Replace(str, str + GetJson(sonInfo, false) + ",");
        }
        private List<DictionaryTreeInfo> GetSons(string ProjectID)
        {
            return new DictionaryTreeDAL().GetSons(ProjectID);
        }
        private List<DictionaryTreeInfo> GetFathers(string ProjectID, string TreeTypeID)
        {
            return new DictionaryTreeDAL().GetFathers(ProjectID, TreeTypeID);
        }
        public void DeleteDictionaryTree(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new DictionaryTreeDAL().Delete(int.Parse(id));
            }
        }

        public int SaveDictionaryTree(DictionaryTreeInfo DictionaryTreeInfo)
        {
            if (DictionaryTreeInfo.ID == null)
            {
                return new DictionaryTreeDAL().Add(DictionaryTreeInfo);
            }
            new DictionaryTreeDAL().Update(DictionaryTreeInfo);
            return DictionaryTreeInfo.ID ?? 0;
        }

        public DictionaryTreeInfo GetByID(string ID)
        {
           return new DictionaryTreeDAL().GetByID(int.Parse(ID));
        }
        public List<DictionaryTreeInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new DictionaryTreeDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


