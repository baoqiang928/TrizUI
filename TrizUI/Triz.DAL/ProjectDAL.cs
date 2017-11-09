using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Triz.Model;
using System.Transactions;

namespace Triz.DAL
{
    public class ProjectDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <returns></returns>
        public bool AddEntity(ProjectInfo ProjectInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    TrizDB.tbl_ProjectInfo.Add(GetDataEntity(ProjectInfo));
                    if (TrizDB.SaveChanges() > 0)
                        return true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0},{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <returns></returns>
        public bool UpdateEntity(ProjectInfo ProjectInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ProjectInfo ProjectInfoEntity = new tbl_ProjectInfo();
                    ProjectInfoEntity.Name = ProjectInfo.Name;
                    TrizDB.SaveChanges();
                    if (TrizDB.SaveChanges() > 0)
                        result = true;
                    return result;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0},{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <returns></returns>
        public int Delete(ProjectInfo ProjectInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ProjectInfo.Where(o => o.ID == ProjectInfo.ID).First();
                    if (Query == null) return 0;
                    TrizDB.tbl_ProjectInfo.Remove(Query);
                    return TrizDB.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0},{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return 0;
        }

        public List<ProjectInfo> Query(string name, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ProjectInfo, bool>> where = PredicateExtensionses.True<tbl_ProjectInfo>();
            if (!string.IsNullOrWhiteSpace(name))
                where = where.And(a => a.Name == name);
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ProjectInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderBy(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ProjectInfo GetBusinessObject(tbl_ProjectInfo ProjectInfoEntity)
        {
            ProjectInfo ProjectInfo = new ProjectInfo();
            ProjectInfo.ID = ProjectInfoEntity.ID;
            ProjectInfo.Name = ProjectInfoEntity.Name;

            return ProjectInfo;
        }

        public tbl_ProjectInfo GetDataEntity(ProjectInfo ProjectInfo)
        {
            tbl_ProjectInfo ProjectInfoEntity = new tbl_ProjectInfo();
            ProjectInfoEntity.ID = ProjectInfo.ID ?? 0;
            ProjectInfoEntity.Name = ProjectInfo.Name;

            return ProjectInfoEntity;
        }

        public List<ProjectInfo> GetGetBusinessObjectList(List<tbl_ProjectInfo> ProjectInfoEntityList)
        {
            List<ProjectInfo> ProjectInfoList = new List<ProjectInfo>();
            foreach (tbl_ProjectInfo tbl_ProjectInfo in ProjectInfoEntityList)
            {
                ProjectInfoList.Add(GetBusinessObject(tbl_ProjectInfo));
            }
            return ProjectInfoList;
        }
    }
}
