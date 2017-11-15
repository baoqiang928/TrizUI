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
    public class QuestionAnalyseDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="QuestionAnalyseInfo"></param>
        /// <returns></returns>
        public bool Add(QuestionAnalyseInfo QuestionAnalyseInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_QuestionAnalyseInfo QuestionAnalyseInfoEntity = new tbl_QuestionAnalyseInfo();
                    SetDataEntity(QuestionAnalyseInfoEntity, QuestionAnalyseInfo);
                    TrizDB.tbl_QuestionAnalyseInfo.Add(QuestionAnalyseInfoEntity);
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
                            string message = string.Format("QuestionAnalyse,{1}",
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
        /// <param name="QuestionAnalyseInfo"></param>
        /// <returns></returns>
        public bool Update(QuestionAnalyseInfo QuestionAnalyseInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionAnalyseInfo.Where(o => o.ProjectID == QuestionAnalyseInfo.ProjectID).FirstOrDefault();
                    if (Query == null)
                    {
                        return Add(QuestionAnalyseInfo);
                    }
                    SetDataEntity(Query, QuestionAnalyseInfo);
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
        /// <param name="QuestionAnalyseInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionAnalyseInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_QuestionAnalyseInfo.Remove(Query);
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



        public QuestionAnalyseInfo GetByProjectID(int ProjectID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionAnalyseInfo.Where(o => o.ProjectID == ProjectID).FirstOrDefault();
                    if (Query == null) return new QuestionAnalyseInfo();
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
            return new QuestionAnalyseInfo();
        }

        public QuestionAnalyseInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionAnalyseInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new QuestionAnalyseInfo();
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
            return new QuestionAnalyseInfo();
        }

        public List<QuestionAnalyseInfo> Query(string IdealResolution1, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_QuestionAnalyseInfo, bool>> where = PredicateExtensionses.True<tbl_QuestionAnalyseInfo>();

            if (!string.IsNullOrWhiteSpace(IdealResolution1))
                where = where.And(a => a.IdealResolution1.Contains(IdealResolution1));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_QuestionAnalyseInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public QuestionAnalyseInfo GetBusinessObject(tbl_QuestionAnalyseInfo QuestionAnalyseInfoEntity)
        {
            QuestionAnalyseInfo QuestionAnalyseInfo = new QuestionAnalyseInfo();

            QuestionAnalyseInfo.ID = QuestionAnalyseInfoEntity.ID;

            QuestionAnalyseInfo.ProjectID = QuestionAnalyseInfoEntity.ProjectID;

            QuestionAnalyseInfo.IdealResolution1 = QuestionAnalyseInfoEntity.IdealResolution1;

            QuestionAnalyseInfo.IdealResolution2 = QuestionAnalyseInfoEntity.IdealResolution2;

            QuestionAnalyseInfo.IdealResolution3 = QuestionAnalyseInfoEntity.IdealResolution3;

            QuestionAnalyseInfo.IdealResolution4 = QuestionAnalyseInfoEntity.IdealResolution4;

            QuestionAnalyseInfo.IdealResolution5 = QuestionAnalyseInfoEntity.IdealResolution5;

            QuestionAnalyseInfo.BasicQuestion1 = QuestionAnalyseInfoEntity.BasicQuestion1;

            QuestionAnalyseInfo.BasicQuestion2 = QuestionAnalyseInfoEntity.BasicQuestion2;

            QuestionAnalyseInfo.BasicQuestion3 = QuestionAnalyseInfoEntity.BasicQuestion3;

            QuestionAnalyseInfo.BasicQuestion4 = QuestionAnalyseInfoEntity.BasicQuestion4;

            QuestionAnalyseInfo.AgainstObject1 = QuestionAnalyseInfoEntity.AgainstObject1;

            QuestionAnalyseInfo.AgainstObject2 = QuestionAnalyseInfoEntity.AgainstObject2;

            QuestionAnalyseInfo.AgainstObject3 = QuestionAnalyseInfoEntity.AgainstObject3;

            QuestionAnalyseInfo.AgainstObject4 = QuestionAnalyseInfoEntity.AgainstObject4;

            QuestionAnalyseInfo.AgainstObject5 = QuestionAnalyseInfoEntity.AgainstObject5;

            QuestionAnalyseInfo.Constriction1 = QuestionAnalyseInfoEntity.Constriction1;

            QuestionAnalyseInfo.Constriction2 = QuestionAnalyseInfoEntity.Constriction2;

            QuestionAnalyseInfo.Constriction3 = QuestionAnalyseInfoEntity.Constriction3;

            QuestionAnalyseInfo.Constriction4 = QuestionAnalyseInfoEntity.Constriction4;

            QuestionAnalyseInfo.Constriction5 = QuestionAnalyseInfoEntity.Constriction5;

            QuestionAnalyseInfo.ResolutionImportance1 = QuestionAnalyseInfoEntity.ResolutionImportance1;

            QuestionAnalyseInfo.ResolutionImportance2 = QuestionAnalyseInfoEntity.ResolutionImportance2;

            QuestionAnalyseInfo.ResolutionImportance3 = QuestionAnalyseInfoEntity.ResolutionImportance3;

            QuestionAnalyseInfo.ResolutionImportance4 = QuestionAnalyseInfoEntity.ResolutionImportance4;

            QuestionAnalyseInfo.ResolutionImportance5 = QuestionAnalyseInfoEntity.ResolutionImportance5;

            QuestionAnalyseInfo.CreateDateTime = QuestionAnalyseInfoEntity.CreateDateTime;


            return QuestionAnalyseInfo;
        }

        public void SetDataEntity(tbl_QuestionAnalyseInfo QuestionAnalyseInfoEntity, QuestionAnalyseInfo QuestionAnalyseInfo)
        {

            if (QuestionAnalyseInfo.ID != null)
                QuestionAnalyseInfoEntity.ID = QuestionAnalyseInfo.ID ?? 0;

            if (QuestionAnalyseInfo.ProjectID != null)
                QuestionAnalyseInfoEntity.ProjectID = QuestionAnalyseInfo.ProjectID;

            if (QuestionAnalyseInfo.IdealResolution1 != null)
                QuestionAnalyseInfoEntity.IdealResolution1 = QuestionAnalyseInfo.IdealResolution1;

            if (QuestionAnalyseInfo.IdealResolution2 != null)
                QuestionAnalyseInfoEntity.IdealResolution2 = QuestionAnalyseInfo.IdealResolution2;

            if (QuestionAnalyseInfo.IdealResolution3 != null)
                QuestionAnalyseInfoEntity.IdealResolution3 = QuestionAnalyseInfo.IdealResolution3;

            if (QuestionAnalyseInfo.IdealResolution4 != null)
                QuestionAnalyseInfoEntity.IdealResolution4 = QuestionAnalyseInfo.IdealResolution4;

            if (QuestionAnalyseInfo.IdealResolution5 != null)
                QuestionAnalyseInfoEntity.IdealResolution5 = QuestionAnalyseInfo.IdealResolution5;

            if (QuestionAnalyseInfo.BasicQuestion1 != null)
                QuestionAnalyseInfoEntity.BasicQuestion1 = QuestionAnalyseInfo.BasicQuestion1;

            if (QuestionAnalyseInfo.BasicQuestion2 != null)
                QuestionAnalyseInfoEntity.BasicQuestion2 = QuestionAnalyseInfo.BasicQuestion2;

            if (QuestionAnalyseInfo.BasicQuestion3 != null)
                QuestionAnalyseInfoEntity.BasicQuestion3 = QuestionAnalyseInfo.BasicQuestion3;

            if (QuestionAnalyseInfo.BasicQuestion4 != null)
                QuestionAnalyseInfoEntity.BasicQuestion4 = QuestionAnalyseInfo.BasicQuestion4;

            if (QuestionAnalyseInfo.AgainstObject1 != null)
                QuestionAnalyseInfoEntity.AgainstObject1 = QuestionAnalyseInfo.AgainstObject1;

            if (QuestionAnalyseInfo.AgainstObject2 != null)
                QuestionAnalyseInfoEntity.AgainstObject2 = QuestionAnalyseInfo.AgainstObject2;

            if (QuestionAnalyseInfo.AgainstObject3 != null)
                QuestionAnalyseInfoEntity.AgainstObject3 = QuestionAnalyseInfo.AgainstObject3;

            if (QuestionAnalyseInfo.AgainstObject4 != null)
                QuestionAnalyseInfoEntity.AgainstObject4 = QuestionAnalyseInfo.AgainstObject4;

            if (QuestionAnalyseInfo.AgainstObject5 != null)
                QuestionAnalyseInfoEntity.AgainstObject5 = QuestionAnalyseInfo.AgainstObject5;

            if (QuestionAnalyseInfo.Constriction1 != null)
                QuestionAnalyseInfoEntity.Constriction1 = QuestionAnalyseInfo.Constriction1;

            if (QuestionAnalyseInfo.Constriction2 != null)
                QuestionAnalyseInfoEntity.Constriction2 = QuestionAnalyseInfo.Constriction2;

            if (QuestionAnalyseInfo.Constriction3 != null)
                QuestionAnalyseInfoEntity.Constriction3 = QuestionAnalyseInfo.Constriction3;

            if (QuestionAnalyseInfo.Constriction4 != null)
                QuestionAnalyseInfoEntity.Constriction4 = QuestionAnalyseInfo.Constriction4;

            if (QuestionAnalyseInfo.Constriction5 != null)
                QuestionAnalyseInfoEntity.Constriction5 = QuestionAnalyseInfo.Constriction5;

            if (QuestionAnalyseInfo.ResolutionImportance1 != null)
                QuestionAnalyseInfoEntity.ResolutionImportance1 = QuestionAnalyseInfo.ResolutionImportance1;

            if (QuestionAnalyseInfo.ResolutionImportance2 != null)
                QuestionAnalyseInfoEntity.ResolutionImportance2 = QuestionAnalyseInfo.ResolutionImportance2;

            if (QuestionAnalyseInfo.ResolutionImportance3 != null)
                QuestionAnalyseInfoEntity.ResolutionImportance3 = QuestionAnalyseInfo.ResolutionImportance3;

            if (QuestionAnalyseInfo.ResolutionImportance4 != null)
                QuestionAnalyseInfoEntity.ResolutionImportance4 = QuestionAnalyseInfo.ResolutionImportance4;

            if (QuestionAnalyseInfo.ResolutionImportance5 != null)
                QuestionAnalyseInfoEntity.ResolutionImportance5 = QuestionAnalyseInfo.ResolutionImportance5;

        }

        public List<QuestionAnalyseInfo> GetGetBusinessObjectList(List<tbl_QuestionAnalyseInfo> QuestionAnalyseInfoEntityList)
        {
            List<QuestionAnalyseInfo> QuestionAnalyseInfoList = new List<QuestionAnalyseInfo>();
            foreach (tbl_QuestionAnalyseInfo tbl_QuestionAnalyseInfo in QuestionAnalyseInfoEntityList)
            {
                QuestionAnalyseInfoList.Add(GetBusinessObject(tbl_QuestionAnalyseInfo));
            }
            return QuestionAnalyseInfoList;
        }
    }
}



