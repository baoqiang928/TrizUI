using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class FunEleMutualReactLogic
    {
        public void DeleteFunEleMutualReact(int id)
        {
            new FunEleMutualReactDAL().Delete(id);
        }

        public void DeleteFunEleMutualReact(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new FunEleMutualReactDAL().Delete(int.Parse(id));
            }
        }

        public void SaveFunEleMutualReact(FunEleMutualReactInfo FunEleMutualReactInfo)
        {
            if (FunEleMutualReactInfo.ID == null)
            {
                new FunEleMutualReactDAL().Add(FunEleMutualReactInfo);
                return;
            }
            new FunEleMutualReactDAL().Update(FunEleMutualReactInfo);

        }

        public FunEleMutualReactInfo GetByID(string ID)
        {
           return new FunEleMutualReactDAL().GetByID(int.Parse(ID));
        }
        public List<FunEleMutualReactInfo> Query(string PositiveEleName, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new FunEleMutualReactDAL().Query(PositiveEleName, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


