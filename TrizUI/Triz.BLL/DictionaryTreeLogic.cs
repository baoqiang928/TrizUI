using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class DictionaryTreeLogic
    {

        #region BigTree
        public string GetBigTreeData(string ProjectID, string TreeTypeID)
        {
            List<DictionaryTreeInfo> Fathers = GetFathers(ProjectID, TreeTypeID);
            string FatherObjListCodes = "";
            string ChildrenCodes = "";
            string js = "";
            foreach (DictionaryTreeInfo Father in Fathers)
            {
                if (TreeTypeID == "2")
                {
                    if (Father.Note != null && Father.Note.Contains(";"))
                    {
                        FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";
                        ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
                    }
                    else
                    {
                        FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
                    }
                    continue;
                }


                if (GetSons(Father.ID).Count > 0)
                {
                    FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";

                    ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
                }
                else
                {
                    FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
                }
            }
            js = "var TreeData = {" + FatherObjListCodes.TrimEnd(',') + "};";
            js += ChildrenCodes;
            return js;
        }
        //public string GetBigTreeData(int FatherID)
        //{
        //    List<DictionaryTreeInfo> Fathers = GetSons(FatherID);
        //    string FatherObjListCodes = "";
        //    string ChildrenCodes = "";
        //    string js = "";
        //    foreach (DictionaryTreeInfo Father in Fathers)
        //    {
        //        if (GetSons(Father.ID).Count > 0)
        //        {
        //            FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";

        //            ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
        //        }
        //        else
        //        {
        //            FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
        //        }
        //    }
        //    js = "var TreeData = {" + FatherObjListCodes.TrimEnd(',') + "};";
        //    js += ChildrenCodes;
        //    return js;
        //}

        public List<TreeNodeInfo> GetBigTreeDataForZTree(int FatherID)
        {
            List<TreeNodeInfo> nodes = new List<TreeNodeInfo>();
            DictionaryTreeInfo DictionaryTreeInfo = new DictionaryTreeDAL().GetByID(FatherID);
            List<DictionaryTreeInfo> Fathers = new List<DictionaryTreeInfo>();
            if (DictionaryTreeInfo.TreeTypeID == 2)//第一层节点，子节点从note里取，否则正常取。
            {
                if (string.IsNullOrWhiteSpace(DictionaryTreeInfo.Note)) return new List<TreeNodeInfo>();
                string[] ids = DictionaryTreeInfo.Note.Split(';');
                Fathers = new List<DictionaryTreeInfo>();
                for (int i = 0; i < ids.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(ids[i])) continue;
                    int id = 0;
                    int.TryParse(ids[i], out id);
                    Fathers.Add(new DictionaryTreeDAL().GetByID(id));
                }
            }
            else
            {
                Fathers = GetSons(FatherID);
            }
            string FatherObjListCodes = "";
            string ChildrenCodes = "";
            string js = "";
            foreach (DictionaryTreeInfo Father in Fathers)
            {
                if (GetSons(Father.ID).Count > 0)
                {
                    nodes.Add(new TreeNodeInfo() { id = Father.ID.ToString(), name = Father.Name, isParent = true });
                    //FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";

                    //ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
                }
                else
                {
                    //FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
                    nodes.Add(new TreeNodeInfo() { id = Father.ID.ToString(), name = Father.Name, isParent = false });
                }
            }
            //js = "var TreeData = {" + FatherObjListCodes.TrimEnd(',') + "};";
            //js += ChildrenCodes;
            return nodes;
        }

        public string GetBigTreeData(int FatherID)
        {
            DictionaryTreeInfo DictionaryTreeInfo = new DictionaryTreeDAL().GetByID(FatherID);
            List<DictionaryTreeInfo> Fathers = new List<DictionaryTreeInfo>();
            if (DictionaryTreeInfo.TreeTypeID == 2)//第一层节点，子节点从note里取，否则正常取。
            {
                if (string.IsNullOrWhiteSpace(DictionaryTreeInfo.Note)) return "";
                string[] ids = DictionaryTreeInfo.Note.Split(';');
                Fathers = new List<DictionaryTreeInfo>();
                for (int i = 0; i < ids.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(ids[i])) continue;
                    int id = 0;
                    int.TryParse(ids[i], out id);
                    Fathers.Add(new DictionaryTreeDAL().GetByID(id));
                }
            }
            else
            {
                Fathers = GetSons(FatherID);
            }
            string FatherObjListCodes = "";
            string ChildrenCodes = "";
            string js = "";
            foreach (DictionaryTreeInfo Father in Fathers)
            {
                if (GetSons(Father.ID).Count > 0)
                {
                    FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";

                    ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
                }
                else
                {
                    FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
                }
            }
            js = "var TreeData = {" + FatherObjListCodes.TrimEnd(',') + "};";
            js += ChildrenCodes;
            return js;
        }


        //public string GetBigTreeDataForSeparationPrinciple1(int FatherID)
        //{
        //    DictionaryTreeInfo DictionaryTreeInfo = new DictionaryTreeDAL().GetByID(FatherID);
        //    if (DictionaryTreeInfo.TreeTypeID != 2)//第一层节点，子节点从note里取，否则正常取。
        //    {
        //        return GetBigTreeData(FatherID);
        //    }
        //    if (string.IsNullOrWhiteSpace(DictionaryTreeInfo.Note)) return "";
        //    string[] ids = DictionaryTreeInfo.Note.Split(';');
        //    List<DictionaryTreeInfo> Fathers = new List<DictionaryTreeInfo>();
        //    for (int i = 0; i < ids.Length; i++)
        //    {
        //        if (string.IsNullOrWhiteSpace(ids[i]))
        //        {
        //            int id = 0;
        //            int.TryParse(ids[i], out id);
        //            Fathers.Add(new DictionaryTreeDAL().GetByID(id));
        //        }
        //    }
        //    string FatherObjListCodes = "";
        //    string ChildrenCodes = "";
        //    string js = "";
        //    foreach (DictionaryTreeInfo Father in Fathers)
        //    {
        //        if (GetSons(Father.ID).Count > 0)
        //        {
        //            FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'folder' },";

        //            ChildrenCodes += "TreeData['" + Father.ID + "']['additionalParameters'] = {'id': '" + Father.ID + "',  'children': {} }; ";
        //        }
        //        else
        //        {
        //            FatherObjListCodes += "'" + Father.ID + "': { id: '" + Father.ID + "', name: '" + Father.Name + "', type: 'item' },";
        //        }
        //    }
        //    js = "var TreeData = {" + FatherObjListCodes.TrimEnd(',') + "};";
        //    js += ChildrenCodes;
        //    return js;
        //}


        #endregion














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


        public List<DictionaryTreeInfo> GetFathersTreeData(string ProjectID, string TreeTypeID)
        {
            List<DictionaryTreeInfo> Fathers = GetFathers(ProjectID, TreeTypeID);
            return Fathers;
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
            List<DictionaryTreeInfo> SonList = GetSons(DictionaryTreeInfo.ID);
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
        private List<DictionaryTreeInfo> GetSons(int? FatherID)
        {
            return new DictionaryTreeDAL().GetSons(FatherID);
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


