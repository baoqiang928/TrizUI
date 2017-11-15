
using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ProjectLogic
    {
        public void DeleteProject(int id)
        {
            new ProjectDAL().Delete(id);
        }

        public void DeleteProject(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new ProjectDAL().Delete(int.Parse(id));
            }
        }

        public void SaveProject(ProjectInfo ProjectInfo)
        {
            if (ProjectInfo.ID == null)
            {
                new ProjectDAL().Add(ProjectInfo);
                return;
            }
            new ProjectDAL().Update(ProjectInfo);

        }

        public ProjectInfo GetByID(string ID)
        {
            return new ProjectDAL().GetByID(int.Parse(ID));
        }
        public List<ProjectInfo> Query(string Code, string Name, string Owner, string Department, string FromDateTime, string ToDateTime, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ProjectDAL().Query(Code, Name, Owner, Department, FromDateTime, ToDateTime, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}

