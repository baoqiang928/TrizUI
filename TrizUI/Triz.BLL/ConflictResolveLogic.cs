using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ConflictResolveLogic
    {
        public void DeleteConflictResolve(int id)
        {
            new ConflictResolveDAL().Delete(id);
        }

        public void DeleteConflictResolve(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ConflictResolveDAL().Delete(int.Parse(id));
            }
        }

        public int SaveConflictResolve(ConflictResolveInfo ConflictResolveInfo)
        {
            if (ConflictResolveInfo.ID == null)
            {
                return new ConflictResolveDAL().Add(ConflictResolveInfo);
            }
            new ConflictResolveDAL().Update(ConflictResolveInfo);
            return ConflictResolveInfo.ID ?? 0;
        }

        public ConflictResolveInfo GetByID(string ID)
        {
           return new ConflictResolveDAL().GetByID(int.Parse(ID));
        }
        public List<ConflictResolveInfo> Query(string ProjectID,string ConflictID,string ConflictType, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ConflictResolveDAL().Query(ProjectID, ConflictID, ConflictType, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


