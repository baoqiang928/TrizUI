using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class CauseEffectCurProblemLogic
    {
        public void DeleteCauseEffectCurProblem(int id)
        {
            new CauseEffectCurProblemDAL().Delete(id);
        }

        public void DeleteCauseEffectCurProblem(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new CauseEffectCurProblemDAL().Delete(int.Parse(id));
            }
        }

        public void SaveCauseEffectCurProblem(CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {
            new CauseEffectCurProblemDAL().DeleteByProjectID(CauseEffectCurProblemInfo.ProjectID);
            new CauseEffectCurProblemDAL().Add(CauseEffectCurProblemInfo);
        }



        public CauseEffectCurProblemInfo GetByProjectID(string ProjectID)
        {
            return new CauseEffectCurProblemDAL().GetByProjectID(int.Parse(ProjectID));
        }
        public List<CauseEffectCurProblemInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new CauseEffectCurProblemDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


