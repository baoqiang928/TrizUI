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

        public void DeleteAnalysisProcedure(string ProcedureID)
        {
            new AnalysisProcedureDAL().DeleteByProcedureID(ProcedureID);
        }

        public void AppendCasesDescription(List<AnalysisProcedureInfo> AnalysisProcedureInfoList)
        {
            List<string> ProcedureIDList = GetProcedureIDList(AnalysisProcedureInfoList);
            List<AnalysisProcedureInfo> AnyProcInfoList = new AnalysisProcedureDAL().GetAnyProcInfoList(ProcedureIDList);
            Dictionary<string, string> prodic = new Dictionary<string, string>();
            foreach (AnalysisProcedureInfo proinfo in AnyProcInfoList)
            {
                if (prodic.ContainsKey(proinfo.ProcedureID))
                {
                    prodic[proinfo.ProcedureID] += ";" + "<a href='"+proinfo.InputValueTypeID+"'>"+ proinfo.InputValue + "</a>";
                    continue;
                }
                prodic.Add(proinfo.ProcedureID, "<a href='" + proinfo.InputValueTypeID + "'>" + proinfo.InputValue + "</a>");

            }
            foreach (AnalysisProcedureInfo AnalysisProcedureInfo in AnalysisProcedureInfoList)
            {
                if (prodic.ContainsKey(AnalysisProcedureInfo.ProcedureID))
                {
                    AnalysisProcedureInfo.DisplayName = prodic[AnalysisProcedureInfo.ProcedureID];
                }
            }
        }
        private List<string> GetProcedureIDList(List<AnalysisProcedureInfo> AnalysisProcedureInfoList)
        {
            List<string> proIDs = new List<string>();
            foreach (AnalysisProcedureInfo AnalysisProcedureInfo in AnalysisProcedureInfoList)
            {
                proIDs.Add(AnalysisProcedureInfo.ProcedureID);
            }
            return proIDs;
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


