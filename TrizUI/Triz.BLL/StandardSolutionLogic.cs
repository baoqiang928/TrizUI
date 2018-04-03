using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class StandardSolutionLogic
    {
        public void DeleteStandardSolution(int id)
        {
            new StandardSolutionDAL().Delete(id);
        }

        public void DeleteStandardSolution(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new StandardSolutionDAL().Delete(int.Parse(id));
            }
        }

        public void SaveStandardSolution(StandardSolutionInfo StandardSolutionInfo)
        {
            if (StandardSolutionInfo.ID == null)
            {
                new StandardSolutionDAL().Add(StandardSolutionInfo);
                return;
            }
            new StandardSolutionDAL().Update(StandardSolutionInfo);

        }

        public StandardSolutionInfo GetByID(string ID)
        {
           return new StandardSolutionDAL().GetByID(int.Parse(ID));
        }
        public List<StandardSolutionInfo> Query(string ProjectID,string Name,string Note,string Remark,string TypeID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new StandardSolutionDAL().Query(ProjectID,Name,Note,Remark,TypeID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


