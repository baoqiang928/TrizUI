using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class PhysicalConflictLogic
    {
        public void DeletePhysicalConflict(int id)
        {
            new PhysicalConflictDAL().Delete(id);
        }

        public void DeletePhysicalConflict(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new PhysicalConflictDAL().Delete(int.Parse(id));
            }
        }

        public int SavePhysicalConflict(PhysicalConflictInfo PhysicalConflictInfo)
        {
            if (PhysicalConflictInfo.ID == null)
            {
                return new PhysicalConflictDAL().Add(PhysicalConflictInfo);
            }
            new PhysicalConflictDAL().Update(PhysicalConflictInfo);
            return PhysicalConflictInfo.ID ?? 0;
        }

        public PhysicalConflictInfo GetByID(string ID)
        {
           return new PhysicalConflictDAL().GetByID(int.Parse(ID));
        }
        public List<PhysicalConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new PhysicalConflictDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


