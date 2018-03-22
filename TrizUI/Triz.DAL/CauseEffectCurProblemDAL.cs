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
    public class CauseEffectCurProblemDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="CauseEffectCurProblemInfo"></param>
        /// <returns></returns>
        public bool Add(CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_CauseEffectCurProblemInfo CauseEffectCurProblemInfoEntity = new tbl_CauseEffectCurProblemInfo();
                    SetDataEntity(CauseEffectCurProblemInfoEntity, CauseEffectCurProblemInfo);
                    TrizDB.tbl_CauseEffectCurProblemInfo.Add(CauseEffectCurProblemInfoEntity);
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
                            string message = string.Format("CauseEffectCurProblem,{1}",
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
        /// <param name="CauseEffectCurProblemInfo"></param>
        /// <returns></returns>
        public bool Update(CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_CauseEffectCurProblemInfo.Where(o => o.ID == CauseEffectCurProblemInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, CauseEffectCurProblemInfo);
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

        public int DeleteByProjectID(int? ProjectID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_CauseEffectCurProblemInfo.Where(o => o.ProjectID == ProjectID).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_CauseEffectCurProblemInfo.Remove(Query);
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
        /// <param name="CauseEffectCurProblemInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_CauseEffectCurProblemInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_CauseEffectCurProblemInfo.Remove(Query);
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

        public CauseEffectCurProblemInfo GetByProjectID(int? ProjectID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_CauseEffectCurProblemInfo.Where(o => o.ProjectID == ProjectID).FirstOrDefault();
                    if (Query == null) return new CauseEffectCurProblemInfo();
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
            return new CauseEffectCurProblemInfo();
        }

        public List<CauseEffectCurProblemInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_CauseEffectCurProblemInfo, bool>> where = PredicateExtensionses.True<tbl_CauseEffectCurProblemInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_CauseEffectCurProblemInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public CauseEffectCurProblemInfo GetBusinessObject(tbl_CauseEffectCurProblemInfo CauseEffectCurProblemInfoEntity)
        {
            CauseEffectCurProblemInfo CauseEffectCurProblemInfo = new CauseEffectCurProblemInfo();

            CauseEffectCurProblemInfo.ID = CauseEffectCurProblemInfoEntity.ID;

            CauseEffectCurProblemInfo.ProjectID = CauseEffectCurProblemInfoEntity.ProjectID;

            CauseEffectCurProblemInfo.ProblemDescription = CauseEffectCurProblemInfoEntity.ProblemDescription;

            CauseEffectCurProblemInfo.CreateDateTime = CauseEffectCurProblemInfoEntity.CreateDateTime;


            return CauseEffectCurProblemInfo;
        }

        public void SetDataEntity(tbl_CauseEffectCurProblemInfo CauseEffectCurProblemInfoEntity, CauseEffectCurProblemInfo CauseEffectCurProblemInfo)
        {

            if (CauseEffectCurProblemInfo.ID != null)
                CauseEffectCurProblemInfoEntity.ID = CauseEffectCurProblemInfo.ID ?? 0;

            if (CauseEffectCurProblemInfo.ProjectID != null)
                CauseEffectCurProblemInfoEntity.ProjectID = CauseEffectCurProblemInfo.ProjectID;

            if (CauseEffectCurProblemInfo.ProblemDescription != null)
                CauseEffectCurProblemInfoEntity.ProblemDescription = CauseEffectCurProblemInfo.ProblemDescription;

        }

        public List<CauseEffectCurProblemInfo> GetGetBusinessObjectList(List<tbl_CauseEffectCurProblemInfo> CauseEffectCurProblemInfoEntityList)
        {
            List<CauseEffectCurProblemInfo> CauseEffectCurProblemInfoList = new List<CauseEffectCurProblemInfo>();
            foreach (tbl_CauseEffectCurProblemInfo tbl_CauseEffectCurProblemInfo in CauseEffectCurProblemInfoEntityList)
            {
                CauseEffectCurProblemInfoList.Add(GetBusinessObject(tbl_CauseEffectCurProblemInfo));
            }
            return CauseEffectCurProblemInfoList;
        }
    }
}



