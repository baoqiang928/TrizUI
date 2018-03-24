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
    public class ConflictDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ConflictInfo"></param>
        /// <returns></returns>
        public bool Add(ConflictInfo ConflictInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ConflictInfo ConflictInfoEntity = new tbl_ConflictInfo();
                    SetDataEntity(ConflictInfoEntity, ConflictInfo);
                    TrizDB.tbl_ConflictInfo.Add(ConflictInfoEntity);
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
                            string message = string.Format("Conflict,{1}",
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
        /// <param name="ConflictInfo"></param>
        /// <returns></returns>
        public bool Update(ConflictInfo ConflictInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictInfo.Where(o => o.ID == ConflictInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, ConflictInfo);
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
        /// <param name="ConflictInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ConflictInfo.Remove(Query);
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

        public ConflictInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new ConflictInfo();
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
            return new ConflictInfo();
        }

        public List<ConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ConflictInfo, bool>> where = PredicateExtensionses.True<tbl_ConflictInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ConflictInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ConflictInfo GetBusinessObject(tbl_ConflictInfo ConflictInfoEntity)
        {
            ConflictInfo ConflictInfo = new ConflictInfo();

            ConflictInfo.ID = ConflictInfoEntity.ID;

            ConflictInfo.ProjectID = ConflictInfoEntity.ProjectID;

            ConflictInfo.RelComponentName = ConflictInfoEntity.RelComponentName;

            ConflictInfo.RelComponentParamName = ConflictInfoEntity.RelComponentParamName;

            ConflictInfo.CurrentConfig = ConflictInfoEntity.CurrentConfig;

            ConflictInfo.ChangeConfig = ConflictInfoEntity.ChangeConfig;

            ConflictInfo.CurrentProblem = ConflictInfoEntity.CurrentProblem;

            ConflictInfo.NewProblem = ConflictInfoEntity.NewProblem;

            ConflictInfo.CreateDateTime = ConflictInfoEntity.CreateDateTime;


            return ConflictInfo;
        }

        public void SetDataEntity(tbl_ConflictInfo ConflictInfoEntity, ConflictInfo ConflictInfo)
        {

            if (ConflictInfo.ID != null)
                ConflictInfoEntity.ID = ConflictInfo.ID ?? 0;

            if (ConflictInfo.ProjectID != null)
                ConflictInfoEntity.ProjectID = ConflictInfo.ProjectID;

            if (ConflictInfo.RelComponentName != null)
                ConflictInfoEntity.RelComponentName = ConflictInfo.RelComponentName;

            if (ConflictInfo.RelComponentParamName != null)
                ConflictInfoEntity.RelComponentParamName = ConflictInfo.RelComponentParamName;

            if (ConflictInfo.CurrentConfig != null)
                ConflictInfoEntity.CurrentConfig = ConflictInfo.CurrentConfig;

            if (ConflictInfo.ChangeConfig != null)
                ConflictInfoEntity.ChangeConfig = ConflictInfo.ChangeConfig;

            if (ConflictInfo.CurrentProblem != null)
                ConflictInfoEntity.CurrentProblem = ConflictInfo.CurrentProblem;

            if (ConflictInfo.NewProblem != null)
                ConflictInfoEntity.NewProblem = ConflictInfo.NewProblem;

        }

        public List<ConflictInfo> GetGetBusinessObjectList(List<tbl_ConflictInfo> ConflictInfoEntityList)
        {
            List<ConflictInfo> ConflictInfoList = new List<ConflictInfo>();
            foreach (tbl_ConflictInfo tbl_ConflictInfo in ConflictInfoEntityList)
            {
                ConflictInfoList.Add(GetBusinessObject(tbl_ConflictInfo));
            }
            return ConflictInfoList;
        }
    }
}



