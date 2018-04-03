using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class StandardSolutionExampleLogic
    {
        public void DeleteStandardSolutionExample(int id)
        {
            new StandardSolutionExampleDAL().Delete(id);
        }
        public string Json = "";
        private string GetJson(StandardSolutionExampleInfo StandardSolutionExampleInfo, bool half)
        {
            //return "{'id':" + StandardSolutionExampleInfo.ID + ",'title':'" + StandardSolutionExampleInfo.EleName + "','nodes':[]}";
            string halfJsonItem = "{'id':{id},'title':'{title}','ID':'{DID}','ProjectID':'{ProjectID}','Name':'{Name}','nodes':[";
            if (half)
            {
                return halfJsonItem.Replace("{id}", StandardSolutionExampleInfo.ID.ToString()).Replace("{title}", StandardSolutionExampleInfo.Name).Replace("{DID}", StandardSolutionExampleInfo.ID.ToString()).Replace("{ProjectID}", StandardSolutionExampleInfo.ProjectID.ToString()).Replace("{Name}", StandardSolutionExampleInfo.Name);
            }
            string jsonItem = halfJsonItem + "]}";
            //return "{'id':" + StandardSolutionExampleInfo.ID + ",'title':'" + StandardSolutionExampleInfo.EleName + "','ID':'" + StandardSolutionExampleInfo.ID + "','ProjectID':'" + StandardSolutionExampleInfo.ProjectID + "','EleName':'" + StandardSolutionExampleInfo.EleName + "','ElementType':'" + StandardSolutionExampleInfo.ElementType + "','EleX':'" + StandardSolutionExampleInfo.EleX + "','EleY':'" + StandardSolutionExampleInfo.EleY + "','Remark':'" + StandardSolutionExampleInfo.Remark + "','nodes':[]}";
            return jsonItem.Replace("{id}", StandardSolutionExampleInfo.ID.ToString()).Replace("{title}", StandardSolutionExampleInfo.Name).Replace("{DID}", StandardSolutionExampleInfo.ID.ToString()).Replace("{ProjectID}", StandardSolutionExampleInfo.ProjectID.ToString()).Replace("{Name}", StandardSolutionExampleInfo.Name);
        }
        public string GetTreeData(string ProjectID,string TypeID)
        {
            List<StandardSolutionExampleInfo> Fathers = GetFathers(ProjectID,TypeID);
            foreach (StandardSolutionExampleInfo Father in Fathers)
            {
                Json = Json + GetJson(Father, false) + ",";
                FindSons(Father);
            }
            Json = "[" + Json.TrimEnd(',').Replace(",]", "]") + "]";
            return Json;
        }
        public void FindSons(StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            List<StandardSolutionExampleInfo> SonList = GetSons(StandardSolutionExampleInfo.ID.ToString());
            if (SonList.Count == 0) return;
            foreach (StandardSolutionExampleInfo Son in SonList)
            {
                AddSon(StandardSolutionExampleInfo, Son);
                FindSons(Son);
            }
        }
        private void AddSon(StandardSolutionExampleInfo fatherInfo, StandardSolutionExampleInfo sonInfo)
        {
            //string str = "{'id':" + fatherElementInfo.ID + ",'title':'" + fatherElementInfo.EleName + "','nodes':["; //故意少了2个】}替换使用。
            string str = GetJson(fatherInfo, true);
            int i = Json.IndexOf(str);
            string aa = GetJson(sonInfo, false);
            Json = Json.Replace(str, str + GetJson(sonInfo, false) + ",");
        }
        private List<StandardSolutionExampleInfo> GetFathers(string ProjectID,string TypeID)
        {
            return new StandardSolutionExampleDAL().GetFathers(ProjectID, TypeID);
        }
        private List<StandardSolutionExampleInfo> GetSons(string ProjectID)
        {
            return new StandardSolutionExampleDAL().GetSons(ProjectID);
        }
        public void DeleteStandardSolutionExample(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new StandardSolutionExampleDAL().Delete(int.Parse(id));
            }
        }

        public int SaveStandardSolutionExample(StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            if (StandardSolutionExampleInfo.ID == null)
            {
                return new StandardSolutionExampleDAL().Add(StandardSolutionExampleInfo);
            }
            new StandardSolutionExampleDAL().Update(StandardSolutionExampleInfo);
            return StandardSolutionExampleInfo.ID ?? 0;
        }

        public StandardSolutionExampleInfo GetByID(string ID)
        {
            return new StandardSolutionExampleDAL().GetByID(int.Parse(ID));
        }
        public List<StandardSolutionExampleInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new StandardSolutionExampleDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


