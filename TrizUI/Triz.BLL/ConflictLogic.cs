using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ConflictLogic
    {
        public void DeleteConflict(int id)
        {
            new ConflictDAL().Delete(id);
        }

        public void DeleteConflict(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ConflictDAL().Delete(int.Parse(id));
            }
        }

        public void SaveConflict(ConflictInfo ConflictInfo)
        {
            if (ConflictInfo.ID == null)
            {
                new ConflictDAL().Add(ConflictInfo);
                return;
            }
            new ConflictDAL().Update(ConflictInfo);

        }

        public ConflictInfo GetByID(string ID)
        {
           return new ConflictDAL().GetByID(int.Parse(ID));
        }
        public List<ConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ConflictDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


