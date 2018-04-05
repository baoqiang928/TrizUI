using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class AnalysisProcedureLogic
    {
        public void DeleteAnalysisProcedure(int id)
        {
            new AnalysisProcedureDAL().Delete(id);
        }

        public void DeleteAnalysisProcedure(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new AnalysisProcedureDAL().Delete(int.Parse(id));
            }
        }

        public void SaveAnalysisProcedure(AnalysisProcedureInfo AnalysisProcedureInfo)
        {
            if (AnalysisProcedureInfo.ID == null)
            {
                new AnalysisProcedureDAL().Add(AnalysisProcedureInfo);
                return;
            }
            new AnalysisProcedureDAL().Update(AnalysisProcedureInfo);

        }

        public AnalysisProcedureInfo GetByID(string ID)
        {
           return new AnalysisProcedureDAL().GetByID(int.Parse(ID));
        }
        public List<AnalysisProcedureInfo> Query(string ProjectID, string ProcedureID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new AnalysisProcedureDAL().Query(ProjectID, ProcedureID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

        public List<AnalysisProcedureInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new AnalysisProcedureDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

    }
}


