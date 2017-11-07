using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Triz.Model;

namespace Triz.DAL
{
    public class ProjectDAL
    {
        public bool AddEntity(ProjectInfo ProjectInfo)//添加实体  
        {
            TrizDBEntities entity = new TrizDBEntities();//定义上下文实体  
            tbl_ProjectInfo projectdata = new tbl_ProjectInfo();
            projectdata.Name = ProjectInfo.Name;
            entity.tbl_ProjectInfo.Add(projectdata);
            int count = entity.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public List<ProjectInfo> Query(string name, int pageIndex, int pageSize)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ProjectInfo, bool>> where = PredicateExtensionses.True<tbl_ProjectInfo>();
            where = where.And(a => a.Name == name);
            using (TrizDBEntities entity = new TrizDBEntities())
            {
                var query = entity.tbl_ProjectInfo.Where(where.Compile()).OrderBy(p => p.ID).Skip(startRow).Take(pageSize);
                List<tbl_ProjectInfo> ProjectDataEntityList = query.ToList();
                List<ProjectInfo> ProjectList = new List<ProjectInfo>();
                //Mapper.CreateMap<ProjectDataEntityList, ProjectList>(); 
                foreach (tbl_ProjectInfo tbl_ProjectInfo in ProjectDataEntityList)
                {
                    ProjectInfo ProjectInfo = new ProjectInfo();
                    ProjectInfo.ID = tbl_ProjectInfo.ID;
                    ProjectInfo.Name = tbl_ProjectInfo.Name;
                    ProjectList.Add(ProjectInfo);
                }
                return ProjectList;
            }
        }
    }
}
