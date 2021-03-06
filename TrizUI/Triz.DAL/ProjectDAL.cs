﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Triz.Model;

namespace Triz.DAL
{
    public class ProjectDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ProjectInfo"></param>
        /// <returns></returns>
        public bool Add(ProjectInfo ProjectInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ProjectInfo ProjectInfoEntity = new tbl_ProjectInfo();
                    SetDataEntity(ProjectInfoEntity, ProjectInfo);
                    TrizDB.tbl_ProjectInfo.Add(ProjectInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                    {
                        ProjectInfo.ID = ProjectInfoEntity.ID;
                        return true;
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("Project,{1}",
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
        public bool Update(ProjectInfo ProjectInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ProjectInfo.Where(o => o.ID == ProjectInfo.ID).First();
                    if (Query == null) return false;
                    SetDataEntity(Query, ProjectInfo);
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
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ProjectInfo.Where(o => o.ID == id).First();
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

        public ProjectInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ProjectInfo.Where(o => o.ID == ID).First();
                    if (Query == null) return new ProjectInfo();
                    return GetBusinessObject(Query);
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
            return new ProjectInfo();
        }

        public List<ProjectInfo> Query(string Code, string Name, string Owner, string Department,string FromDateTime, string ToDateTime, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ProjectInfo, bool>> where = PredicateExtensionses.True<tbl_ProjectInfo>();

            if (!string.IsNullOrWhiteSpace(Code))
                where = where.And(a => a.Code.Contains(Code));

            if (!string.IsNullOrWhiteSpace(Name))
                where = where.And(a => a.Name.Contains(Name));

            if (!string.IsNullOrWhiteSpace(Owner))
                where = where.And(a => a.Owner.Contains(Owner));

            if (!string.IsNullOrWhiteSpace(Department))
                where = where.And(a => a.Department.Contains(Department));

            if (!string.IsNullOrWhiteSpace(FromDateTime))
                where = where.And(a => a.CreateDateTime.CompareTo(DateTime.Parse(FromDateTime)) >= 0);

            if (!string.IsNullOrWhiteSpace(ToDateTime))
                where = where.And(a => a.CreateDateTime.CompareTo(DateTime.Parse(ToDateTime)) <= 0);


            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ProjectInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ProjectInfo GetBusinessObject(tbl_ProjectInfo ProjectInfoEntity)
        {
            ProjectInfo ProjectInfo = new ProjectInfo();

            ProjectInfo.ID = ProjectInfoEntity.ID;

            ProjectInfo.Code = ProjectInfoEntity.Code;

            ProjectInfo.Name = ProjectInfoEntity.Name;

            ProjectInfo.Owner = ProjectInfoEntity.Owner;

            ProjectInfo.Department = ProjectInfoEntity.Department;

            ProjectInfo.CreateDateTime = ProjectInfoEntity.CreateDateTime;


            return ProjectInfo;
        }

        public void SetDataEntity(tbl_ProjectInfo ProjectInfoEntity, ProjectInfo ProjectInfo)
        {

            if (ProjectInfo.ID != null)
                ProjectInfoEntity.ID = ProjectInfo.ID ?? 0;

            if (ProjectInfo.Code != null)
                ProjectInfoEntity.Code = ProjectInfo.Code;

            if (ProjectInfo.Name != null)
                ProjectInfoEntity.Name = ProjectInfo.Name;

            if (ProjectInfo.Owner != null)
                ProjectInfoEntity.Owner = ProjectInfo.Owner;

            if (ProjectInfo.Department != null)
                ProjectInfoEntity.Department = ProjectInfo.Department;

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


