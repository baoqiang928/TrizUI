using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ComponentRelLogic
    {
        public void DeleteComponentRel(int id)
        {
            new ComponentRelDAL().Delete(id);
        }

        public void DeleteComponentRel(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ComponentRelDAL().Delete(int.Parse(id));
            }
        }

        public void SaveComponentRel(ComponentRelInfo ComponentRelInfo)
        {
            if (ComponentRelInfo.ID == null)
            {
                new ComponentRelDAL().Add(ComponentRelInfo);
                return;
            }
            new ComponentRelDAL().Update(ComponentRelInfo);

        }

        public ComponentRelInfo GetByID(string ID)
        {
           return new ComponentRelDAL().GetByID(int.Parse(ID));
        }
        public List<ComponentRelInfo> Query(string ProjectID,string SectionID,string ImpactParamName,string Disabled, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ComponentRelDAL().Query(ProjectID,SectionID,ImpactParamName,Disabled, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }

        public void DeleteBySectionID(int SectionID)
        {
            new ComponentRelDAL().DeleteBySectionID(SectionID);
        }
    }
}


