using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ComponentParamLogic
    {
        public void DeleteComponentParam(int id)
        {
            new ComponentParamDAL().Delete(id);
        }

        public void DeleteComponentParam(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ComponentParamDAL().Delete(int.Parse(id));
            }
        }

        public void SaveComponentParam(ComponentParamInfo ComponentParamInfo)
        {
            if (ComponentParamInfo.ID == null)
            {
                new ComponentParamDAL().Add(ComponentParamInfo);
                return;
            }
            new ComponentParamDAL().Update(ComponentParamInfo);

        }

        public ComponentParamInfo GetByID(string ID)
        {
           return new ComponentParamDAL().GetByID(int.Parse(ID));
        }
        public List<ComponentParamInfo> Query(string ProjectID,string ParamType,string Disabled, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ComponentParamDAL().Query(ProjectID,ParamType,Disabled, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


