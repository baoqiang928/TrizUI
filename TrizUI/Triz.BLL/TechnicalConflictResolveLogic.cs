using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class TechnicalConflictResolveLogic
    {
        public void DeleteTechnicalConflictResolve(int id)
        {
            new TechnicalConflictResolveDAL().Delete(id);
        }

        public void DeleteTechnicalConflictResolve(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new TechnicalConflictResolveDAL().Delete(int.Parse(id));
            }
        }

        public int SaveTechnicalConflictResolve(TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
            if (TechnicalConflictResolveInfo.ID == null)
            {
                return new TechnicalConflictResolveDAL().Add(TechnicalConflictResolveInfo);
            }
            new TechnicalConflictResolveDAL().Update(TechnicalConflictResolveInfo);
            return TechnicalConflictResolveInfo.ID ?? 0;
        }

        public TechnicalConflictResolveInfo GetByID(string ID)
        {
           return new TechnicalConflictResolveDAL().GetByID(int.Parse(ID));
        }
        public List<TechnicalConflictResolveInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new TechnicalConflictResolveDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


