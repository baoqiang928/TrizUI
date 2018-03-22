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
    public class ComponentParamDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ComponentParamInfo"></param>
        /// <returns></returns>
        public bool Add(ComponentParamInfo ComponentParamInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ComponentParamInfo ComponentParamInfoEntity = new tbl_ComponentParamInfo();
                    SetDataEntity(ComponentParamInfoEntity, ComponentParamInfo);
                    TrizDB.tbl_ComponentParamInfo.Add(ComponentParamInfoEntity);
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
                            string message = string.Format("ComponentParam,{1}",
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
        /// <param name="ComponentParamInfo"></param>
        /// <returns></returns>
        public bool Update(ComponentParamInfo ComponentParamInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentParamInfo.Where(o => o.ID == ComponentParamInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, ComponentParamInfo);
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
        /// <param name="ComponentParamInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentParamInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ComponentParamInfo.Remove(Query);
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

        public ComponentParamInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ComponentParamInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new ComponentParamInfo();
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
            return new ComponentParamInfo();
        }

        public List<ComponentParamInfo> Query(string ProjectID, string ParamType, string Disabled, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ComponentParamInfo, bool>> where = PredicateExtensionses.True<tbl_ComponentParamInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            if (!string.IsNullOrWhiteSpace(ParamType))
                where = where.And(a => a.ParamType.Contains(ParamType));

            if (!string.IsNullOrWhiteSpace(Disabled))
                where = where.And(a => a.Disabled.Contains(Disabled));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ComponentParamInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderBy(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ComponentParamInfo GetBusinessObject(tbl_ComponentParamInfo ComponentParamInfoEntity)
        {
            ComponentParamInfo ComponentParamInfo = new ComponentParamInfo();

            ComponentParamInfo.ID = ComponentParamInfoEntity.ID;

            ComponentParamInfo.ProjectID = ComponentParamInfoEntity.ProjectID;

            ComponentParamInfo.ComponentName = ComponentParamInfoEntity.ComponentName;

            ComponentParamInfo.ParamName = ComponentParamInfoEntity.ParamName;

            ComponentParamInfo.ParamType = ComponentParamInfoEntity.ParamType;

            ComponentParamInfo.Disabled = ComponentParamInfoEntity.Disabled;

            ComponentParamInfo.CreateDateTime = ComponentParamInfoEntity.CreateDateTime;


            return ComponentParamInfo;
        }

        public void SetDataEntity(tbl_ComponentParamInfo ComponentParamInfoEntity, ComponentParamInfo ComponentParamInfo)
        {

            if (ComponentParamInfo.ID != null)
                ComponentParamInfoEntity.ID = ComponentParamInfo.ID ?? 0;

            if (ComponentParamInfo.ProjectID != null)
                ComponentParamInfoEntity.ProjectID = ComponentParamInfo.ProjectID;

            if (ComponentParamInfo.ComponentName != null)
                ComponentParamInfoEntity.ComponentName = ComponentParamInfo.ComponentName;

            if (ComponentParamInfo.ParamName != null)
                ComponentParamInfoEntity.ParamName = ComponentParamInfo.ParamName;

            if (ComponentParamInfo.ParamType != null)
                ComponentParamInfoEntity.ParamType = ComponentParamInfo.ParamType;

            if (ComponentParamInfo.Disabled != null)
                ComponentParamInfoEntity.Disabled = ComponentParamInfo.Disabled;

        }

        public List<ComponentParamInfo> GetGetBusinessObjectList(List<tbl_ComponentParamInfo> ComponentParamInfoEntityList)
        {
            List<ComponentParamInfo> ComponentParamInfoList = new List<ComponentParamInfo>();
            foreach (tbl_ComponentParamInfo tbl_ComponentParamInfo in ComponentParamInfoEntityList)
            {
                ComponentParamInfoList.Add(GetBusinessObject(tbl_ComponentParamInfo));
            }
            return ComponentParamInfoList;
        }
    }
}



