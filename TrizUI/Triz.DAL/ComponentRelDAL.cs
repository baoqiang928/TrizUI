using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Triz.Model;

namespace Triz.DAL
{
    public class ComponentRelDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ComponentRelInfo"></param>
        /// <returns></returns>
        public bool Add(ComponentRelInfo ComponentRelInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ComponentRelInfo ComponentRelInfoEntity = new tbl_ComponentRelInfo();
                    SetDataEntity(ComponentRelInfoEntity, ComponentRelInfo);
                    TrizDB.tbl_ComponentRelInfo.Add(ComponentRelInfoEntity);
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
                            string message = string.Format("ComponentRel,{1}",
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
        /// <param name="ComponentRelInfo"></param>
        /// <returns></returns>
        public bool Update(ComponentRelInfo ComponentRelInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentRelInfo.Where(o => o.ID == ComponentRelInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, ComponentRelInfo);
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
        /// <param name="ComponentRelInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentRelInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ComponentRelInfo.Remove(Query);
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

        public int DeleteBySectionID(int SectionID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentRelInfo.Where(o => o.SectionID == SectionID).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ComponentRelInfo.Remove(Query);
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

        

        public ComponentRelInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentRelInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new ComponentRelInfo();
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
            return new ComponentRelInfo();
        }

        public List<ComponentRelInfo> Query(string ProjectID, string SectionID, string ImpactParamName, string Disabled, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ComponentRelInfo, bool>> where = PredicateExtensionses.True<tbl_ComponentRelInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            if (!string.IsNullOrWhiteSpace(SectionID))
                where = where.And(a => a.SectionID == int.Parse(SectionID));

            if (!string.IsNullOrWhiteSpace(ImpactParamName))
                where = where.And(a => a.ImpactParamName.Contains(ImpactParamName));

            if (!string.IsNullOrWhiteSpace(Disabled))
                where = where.And(a => a.Disabled.Contains(Disabled));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ComponentRelInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderBy(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ComponentRelInfo GetBusinessObject(tbl_ComponentRelInfo ComponentRelInfoEntity)
        {
            ComponentRelInfo ComponentRelInfo = new ComponentRelInfo();

            ComponentRelInfo.ID = ComponentRelInfoEntity.ID;

            ComponentRelInfo.ProjectID = ComponentRelInfoEntity.ProjectID;

            ComponentRelInfo.SectionID = ComponentRelInfoEntity.SectionID;

            ComponentRelInfo.ComponentParamName = ComponentRelInfoEntity.ComponentParamName;

            ComponentRelInfo.ImpactComponentName = ComponentRelInfoEntity.ImpactComponentName;

            ComponentRelInfo.ImpactParamName = ComponentRelInfoEntity.ImpactParamName;

            ComponentRelInfo.ParamType = ComponentRelInfoEntity.ParamType;

            ComponentRelInfo.Disabled = ComponentRelInfoEntity.Disabled;

            ComponentRelInfo.CreateDateTime = ComponentRelInfoEntity.CreateDateTime;


            return ComponentRelInfo;
        }

        public void SetDataEntity(tbl_ComponentRelInfo ComponentRelInfoEntity, ComponentRelInfo ComponentRelInfo)
        {

            if (ComponentRelInfo.ID != null)
                ComponentRelInfoEntity.ID = ComponentRelInfo.ID ?? 0;

            if (ComponentRelInfo.ProjectID != null)
                ComponentRelInfoEntity.ProjectID = ComponentRelInfo.ProjectID;

            if (ComponentRelInfo.SectionID != null)
                ComponentRelInfoEntity.SectionID = ComponentRelInfo.SectionID;

            if (ComponentRelInfo.ComponentParamName != null)
                ComponentRelInfoEntity.ComponentParamName = ComponentRelInfo.ComponentParamName;

            if (ComponentRelInfo.ImpactComponentName != null)
                ComponentRelInfoEntity.ImpactComponentName = ComponentRelInfo.ImpactComponentName;

            if (ComponentRelInfo.ImpactParamName != null)
                ComponentRelInfoEntity.ImpactParamName = ComponentRelInfo.ImpactParamName;

            if (ComponentRelInfo.ParamType != null)
                ComponentRelInfoEntity.ParamType = ComponentRelInfo.ParamType;

            if (ComponentRelInfo.Disabled != null)
                ComponentRelInfoEntity.Disabled = ComponentRelInfo.Disabled;

        }

        public List<ComponentRelInfo> GetGetBusinessObjectList(List<tbl_ComponentRelInfo> ComponentRelInfoEntityList)
        {
            List<ComponentRelInfo> ComponentRelInfoList = new List<ComponentRelInfo>();
            foreach (tbl_ComponentRelInfo tbl_ComponentRelInfo in ComponentRelInfoEntityList)
            {
                ComponentRelInfoList.Add(GetBusinessObject(tbl_ComponentRelInfo));
            }
            return ComponentRelInfoList;
        }
    }
}



