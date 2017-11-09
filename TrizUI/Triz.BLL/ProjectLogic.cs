using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class ProjectLogic
    {


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
        public List<ProjectInfo> Query(string name, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new ProjectDAL().Query(name, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}
