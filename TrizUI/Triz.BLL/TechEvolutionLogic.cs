using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class TechEvolutionLogic
    {
        public void DeleteTechEvolution(int id)
        {
            new TechEvolutionDAL().Delete(id);
        }

        public void DeleteTechEvolution(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new TechEvolutionDAL().Delete(int.Parse(id));
            }
        }

        public int SaveTechEvolution(TechEvolutionInfo TechEvolutionInfo)
        {
            if (TechEvolutionInfo.ID == null)
            {
                return new TechEvolutionDAL().Add(TechEvolutionInfo);
            }
            new TechEvolutionDAL().Update(TechEvolutionInfo);
            return TechEvolutionInfo.ID ?? 0;
        }

        public TechEvolutionInfo GetByID(string ID)
        {
           return new TechEvolutionDAL().GetByID(int.Parse(ID));
        }
        public List<TechEvolutionInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new TechEvolutionDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


