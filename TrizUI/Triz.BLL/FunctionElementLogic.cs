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

        public void DeleteFunctionElement(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new FunctionElementDAL().Delete(int.Parse(id));
            }
        }

        public void SaveFunctionElement(FunctionElementInfo FunctionElementInfo)
        {
            if (FunctionElementInfo.ID == null)
            {
                //¸ù¾ÝnameÕÒID
                int total = 0;
                int pageslenth = 0;
                List<FunctionElementInfo> FunctionElementList = Query(FunctionElementInfo.ProjectID.ToString(), FunctionElementInfo.EleName, 1, 9999, ref total, ref pageslenth);
                if (FunctionElementList.Count > 1)
                    return;
                if (FunctionElementList.Count == 0)
                {
                    new FunctionElementDAL().Add(FunctionElementInfo);
                    return;
                }
                if (FunctionElementList.Count == 1)
                    FunctionElementInfo.ID = FunctionElementList[0].ID;
            }
            new FunctionElementDAL().Update(FunctionElementInfo);
            return;
        }



        public FunctionElementInfo GetByID(string ID)
        {
            return new FunctionElementDAL().GetByID(int.Parse(ID));
        }
        public List<FunctionElementInfo> Query(string ProjectID, string EleName, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new FunctionElementDAL().Query(ProjectID, EleName, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

    }
}


