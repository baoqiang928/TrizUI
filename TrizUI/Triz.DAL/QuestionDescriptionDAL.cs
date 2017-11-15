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
    public class QuestionDescriptionDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="QuestionDescriptionInfo"></param>
        /// <returns></returns>
        public bool Add(QuestionDescriptionInfo QuestionDescriptionInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_QuestionDescriptionInfo QuestionDescriptionInfoEntity = new tbl_QuestionDescriptionInfo();
                    SetDataEntity(QuestionDescriptionInfoEntity, QuestionDescriptionInfo);
                    TrizDB.tbl_QuestionDescriptionInfo.Add(QuestionDescriptionInfoEntity);
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
                            string message = string.Format("QuestionDescription,{1}",
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
        /// <param name="QuestionDescriptionInfo"></param>
        /// <returns></returns>
        public bool Update(QuestionDescriptionInfo QuestionDescriptionInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionDescriptionInfo.Where(o => o.ProjectID == QuestionDescriptionInfo.ProjectID).FirstOrDefault();
                    if (Query == null)
                    {
                        return Add(QuestionDescriptionInfo);
                    }
                    SetDataEntity(Query, QuestionDescriptionInfo);
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
        /// <param name="QuestionDescriptionInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionDescriptionInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_QuestionDescriptionInfo.Remove(Query);
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

        public QuestionDescriptionInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionDescriptionInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new QuestionDescriptionInfo();
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
            return new QuestionDescriptionInfo();
        }

        public QuestionDescriptionInfo GetByProjectID(int ProjectID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_QuestionDescriptionInfo.Where(o => o.ProjectID == ProjectID).FirstOrDefault();
                    if (Query == null) return new QuestionDescriptionInfo();
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
            return new QuestionDescriptionInfo();
        }

        public List<QuestionDescriptionInfo> Query(string Note, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_QuestionDescriptionInfo, bool>> where = PredicateExtensionses.True<tbl_QuestionDescriptionInfo>();

            if (!string.IsNullOrWhiteSpace(Note))
                where = where.And(a => a.Note.Contains(Note));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_QuestionDescriptionInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public QuestionDescriptionInfo GetBusinessObject(tbl_QuestionDescriptionInfo QuestionDescriptionInfoEntity)
        {
            QuestionDescriptionInfo QuestionDescriptionInfo = new QuestionDescriptionInfo();

            QuestionDescriptionInfo.ID = QuestionDescriptionInfoEntity.ID;

            QuestionDescriptionInfo.ProjectID = QuestionDescriptionInfoEntity.ProjectID;

            QuestionDescriptionInfo.Note = QuestionDescriptionInfoEntity.Note;

            QuestionDescriptionInfo.CustomerDes = QuestionDescriptionInfoEntity.CustomerDes;

            QuestionDescriptionInfo.Environment = QuestionDescriptionInfoEntity.Environment;

            QuestionDescriptionInfo.InitialProblemDes = QuestionDescriptionInfoEntity.InitialProblemDes;

            QuestionDescriptionInfo.RelativeDemand = QuestionDescriptionInfoEntity.RelativeDemand;

            QuestionDescriptionInfo.PotentialProblem = QuestionDescriptionInfoEntity.PotentialProblem;

            QuestionDescriptionInfo.GapOfPerformanceRequirment = QuestionDescriptionInfoEntity.GapOfPerformanceRequirment;

            QuestionDescriptionInfo.CreateDateTime = QuestionDescriptionInfoEntity.CreateDateTime;


            return QuestionDescriptionInfo;
        }

        public void SetDataEntity(tbl_QuestionDescriptionInfo QuestionDescriptionInfoEntity, QuestionDescriptionInfo QuestionDescriptionInfo)
        {

            if (QuestionDescriptionInfo.ID != null)
                QuestionDescriptionInfoEntity.ID = QuestionDescriptionInfo.ID ?? 0;

            if (QuestionDescriptionInfo.ProjectID != null)
                QuestionDescriptionInfoEntity.ProjectID = QuestionDescriptionInfo.ProjectID;

            if (QuestionDescriptionInfo.Note != null)
                QuestionDescriptionInfoEntity.Note = QuestionDescriptionInfo.Note;

            if (QuestionDescriptionInfo.CustomerDes != null)
                QuestionDescriptionInfoEntity.CustomerDes = QuestionDescriptionInfo.CustomerDes;

            if (QuestionDescriptionInfo.Environment != null)
                QuestionDescriptionInfoEntity.Environment = QuestionDescriptionInfo.Environment;

            if (QuestionDescriptionInfo.InitialProblemDes != null)
                QuestionDescriptionInfoEntity.InitialProblemDes = QuestionDescriptionInfo.InitialProblemDes;

            if (QuestionDescriptionInfo.RelativeDemand != null)
                QuestionDescriptionInfoEntity.RelativeDemand = QuestionDescriptionInfo.RelativeDemand;

            if (QuestionDescriptionInfo.PotentialProblem != null)
                QuestionDescriptionInfoEntity.PotentialProblem = QuestionDescriptionInfo.PotentialProblem;

            if (QuestionDescriptionInfo.GapOfPerformanceRequirment != null)
                QuestionDescriptionInfoEntity.GapOfPerformanceRequirment = QuestionDescriptionInfo.GapOfPerformanceRequirment;

        }

        public List<QuestionDescriptionInfo> GetGetBusinessObjectList(List<tbl_QuestionDescriptionInfo> QuestionDescriptionInfoEntityList)
        {
            List<QuestionDescriptionInfo> QuestionDescriptionInfoList = new List<QuestionDescriptionInfo>();
            foreach (tbl_QuestionDescriptionInfo tbl_QuestionDescriptionInfo in QuestionDescriptionInfoEntityList)
            {
                QuestionDescriptionInfoList.Add(GetBusinessObject(tbl_QuestionDescriptionInfo));
            }
            return QuestionDescriptionInfoList;
        }
    }
}



