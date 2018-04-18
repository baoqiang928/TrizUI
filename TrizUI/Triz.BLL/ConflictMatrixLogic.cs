using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ConflictMatrixLogic
    {
        public void DeleteConflictMatrix(int id)
        {
            new ConflictMatrixDAL().Delete(id);
        }

        public void DeleteConflictMatrix(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ConflictMatrixDAL().Delete(int.Parse(id));
            }
        }

        public int SaveConflictMatrix(ConflictMatrixInfo ConflictMatrixInfo)
        {
            if (ConflictMatrixInfo.ID == null)
            {
                return new ConflictMatrixDAL().Add(ConflictMatrixInfo);
            }
            new ConflictMatrixDAL().Update(ConflictMatrixInfo);
            return ConflictMatrixInfo.ID ?? 0;
        }

        public ConflictMatrixInfo GetByID(string ID)
        {
           return new ConflictMatrixDAL().GetByID(int.Parse(ID));
        }
        public List<ConflictMatrixInfo> Query(string ImproveCharacter, string DeteriorateCharacter)
        {
            return new ConflictMatrixDAL().Query(ImproveCharacter,  DeteriorateCharacter);
        }
        public List<ConflictMatrixInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ConflictMatrixDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

    }
}


