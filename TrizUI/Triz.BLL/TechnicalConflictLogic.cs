using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class TechnicalConflictLogic
    {
        public void DeleteTechnicalConflict(int id)
        {
            new TechnicalConflictDAL().Delete(id);
        }

        public void DeleteTechnicalConflict(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new TechnicalConflictDAL().Delete(int.Parse(id));
            }
        }

        public int SaveTechnicalConflict(TechnicalConflictInfo TechnicalConflictInfo)
        {
            if (TechnicalConflictInfo.ID == null)
            {
                return new TechnicalConflictDAL().Add(TechnicalConflictInfo);
            }
            new TechnicalConflictDAL().Update(TechnicalConflictInfo);
            return TechnicalConflictInfo.ID ?? 0;
        }

        public TechnicalConflictInfo GetByID(string ID)
        {
           return new TechnicalConflictDAL().GetByID(int.Parse(ID));
        }
        public List<TechnicalConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new TechnicalConflictDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


