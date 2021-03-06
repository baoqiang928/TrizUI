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
    public class AnalysisProcedureDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="AnalysisProcedureInfo"></param>
        /// <returns></returns>
        public bool Add(AnalysisProcedureInfo AnalysisProcedureInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_AnalysisProcedureInfo AnalysisProcedureInfoEntity = new tbl_AnalysisProcedureInfo();
                    SetDataEntity(AnalysisProcedureInfoEntity, AnalysisProcedureInfo);
                    TrizDB.tbl_AnalysisProcedureInfo.Add(AnalysisProcedureInfoEntity);
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
                            string message = string.Format("AnalysisProcedure,{1}",
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
        /// <param name="AnalysisProcedureInfo"></param>
        /// <returns></returns>
        public bool Update(AnalysisProcedureInfo AnalysisProcedureInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_AnalysisProcedureInfo.Where(o => o.ID == AnalysisProcedureInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, AnalysisProcedureInfo);
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
        /// <param name="AnalysisProcedureInfo"></param>
        /// <returns></returns>
        public int DeleteByProID(string ProcedureID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_AnalysisProcedureInfo.Where(o => o.ProcedureID == ProcedureID).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_AnalysisProcedureInfo.Remove(Query);
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

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="AnalysisProcedureInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_AnalysisProcedureInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_AnalysisProcedureInfo.Remove(Query);
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


        public int DeleteByProcedureID(string ProcedureID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_AnalysisProcedureInfo.Where(o => o.ProcedureID == ProcedureID);
                    if (Query == null) return 0;
                    foreach (var o in Query)
                    {
                        TrizDB.tbl_AnalysisProcedureInfo.Remove(o);
                    }
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

        public AnalysisProcedureInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_AnalysisProcedureInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new AnalysisProcedureInfo();
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
            return new AnalysisProcedureInfo();
        }

        public List<AnalysisProcedureInfo> GetAnyProcInfoList(List<string> ProcedureIDList)
        {
            Expression<Func<tbl_AnalysisProcedureInfo, bool>> where = PredicateExtensionses.True<tbl_AnalysisProcedureInfo>();
            where = where.And(a => ProcedureIDList.Contains(a.ProcedureID));
            where = where.And(a => a.DisplayName.Contains("标准解"));
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_AnalysisProcedureInfo.Where(where.Compile());
                return GetGetBusinessObjectList(query.ToList());
            }
        }
        public List<AnalysisProcedureInfo> Query(string ProjectID, string ProcedureID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_AnalysisProcedureInfo, bool>> where = PredicateExtensionses.True<tbl_AnalysisProcedureInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            if (!string.IsNullOrWhiteSpace(ProcedureID))
                where = where.And(a => a.ProcedureID == ProcedureID);

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_AnalysisProcedureInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderBy(p => p.SerialNum).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public List<AnalysisProcedureInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_AnalysisProcedureInfo, bool>> where = PredicateExtensionses.True<tbl_AnalysisProcedureInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            where = where.And(a => a.DisplayName == "问题的简洁描述");

            Expression<Func<tbl_AnalysisProcedureInfo, bool>> where1 = PredicateExtensionses.True<tbl_AnalysisProcedureInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where1 = where1.And(a => a.ProjectID == int.Parse(ProjectID));

            where1 = where1.And(a => a.DisplayName == "需要做的工作");


            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query1 = TrizDB.tbl_AnalysisProcedureInfo.Where(where.Compile());

                var query2 = TrizDB.tbl_AnalysisProcedureInfo.Where(where1.Compile());

                var query = query1.Join(query2, a => a.ProcedureID, g => g.ProcedureID, (a, g) => new AnalysisProcedureInfo { ProcedureID = a.ProcedureID, ProjectID = a.ProjectID, InputValue = a.InputValue, RadioValue = g.RadioValue });

                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.Skip(startRow).Take(pageSize);
                return query.ToList();
            }
        }

        public AnalysisProcedureInfo GetBusinessObject(tbl_AnalysisProcedureInfo AnalysisProcedureInfoEntity)
        {
            AnalysisProcedureInfo AnalysisProcedureInfo = new AnalysisProcedureInfo();

            AnalysisProcedureInfo.ID = AnalysisProcedureInfoEntity.ID;

            AnalysisProcedureInfo.ProjectID = AnalysisProcedureInfoEntity.ProjectID;

            AnalysisProcedureInfo.SerialNum = AnalysisProcedureInfoEntity.SerialNum;

            AnalysisProcedureInfo.ProcedureID = AnalysisProcedureInfoEntity.ProcedureID;

            AnalysisProcedureInfo.TemplateName = AnalysisProcedureInfoEntity.TemplateName;

            AnalysisProcedureInfo.DisplayName = AnalysisProcedureInfoEntity.DisplayName;

            AnalysisProcedureInfo.Code = AnalysisProcedureInfoEntity.Code;

            AnalysisProcedureInfo.RadioValue = AnalysisProcedureInfoEntity.RadioValue;

            AnalysisProcedureInfo.InputValue = AnalysisProcedureInfoEntity.InputValue;

            AnalysisProcedureInfo.InputValueTypeID = AnalysisProcedureInfoEntity.InputValueTypeID;

            AnalysisProcedureInfo.CreateDateTime = AnalysisProcedureInfoEntity.CreateDateTime;

            return AnalysisProcedureInfo;
        }

        public void SetDataEntity(tbl_AnalysisProcedureInfo AnalysisProcedureInfoEntity, AnalysisProcedureInfo AnalysisProcedureInfo)
        {

            if (AnalysisProcedureInfo.ID != null)
                AnalysisProcedureInfoEntity.ID = AnalysisProcedureInfo.ID ?? 0;

            if (AnalysisProcedureInfo.ProjectID != null)
                AnalysisProcedureInfoEntity.ProjectID = AnalysisProcedureInfo.ProjectID;

            if (AnalysisProcedureInfo.SerialNum != null)
                AnalysisProcedureInfoEntity.SerialNum = AnalysisProcedureInfo.SerialNum;

            if (AnalysisProcedureInfo.ProcedureID != null)
                AnalysisProcedureInfoEntity.ProcedureID = AnalysisProcedureInfo.ProcedureID;

            if (AnalysisProcedureInfo.TemplateName != null)
                AnalysisProcedureInfoEntity.TemplateName = AnalysisProcedureInfo.TemplateName;

            if (AnalysisProcedureInfo.DisplayName != null)
                AnalysisProcedureInfoEntity.DisplayName = AnalysisProcedureInfo.DisplayName;

            if (AnalysisProcedureInfo.Code != null)
                AnalysisProcedureInfoEntity.Code = AnalysisProcedureInfo.Code;

            if (AnalysisProcedureInfo.RadioValue != null)
                AnalysisProcedureInfoEntity.RadioValue = AnalysisProcedureInfo.RadioValue;

            if (AnalysisProcedureInfo.InputValue != null)
                AnalysisProcedureInfoEntity.InputValue = AnalysisProcedureInfo.InputValue;

            if (AnalysisProcedureInfo.InputValueTypeID != null)
                AnalysisProcedureInfoEntity.InputValueTypeID = AnalysisProcedureInfo.InputValueTypeID;

        }

        public List<AnalysisProcedureInfo> GetGetBusinessObjectList(List<tbl_AnalysisProcedureInfo> AnalysisProcedureInfoEntityList)
        {
            List<AnalysisProcedureInfo> AnalysisProcedureInfoList = new List<AnalysisProcedureInfo>();
            foreach (tbl_AnalysisProcedureInfo tbl_AnalysisProcedureInfo in AnalysisProcedureInfoEntityList)
            {
                AnalysisProcedureInfoList.Add(GetBusinessObject(tbl_AnalysisProcedureInfo));
            }
            return AnalysisProcedureInfoList;
        }
    }
}



