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
    public class TechnicalConflictDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="TechnicalConflictInfo"></param>
        /// <returns></returns>
        public int Add(TechnicalConflictInfo TechnicalConflictInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_TechnicalConflictInfo TechnicalConflictInfoEntity = new tbl_TechnicalConflictInfo();
                    SetDataEntity(TechnicalConflictInfoEntity, TechnicalConflictInfo);
                    TrizDB.tbl_TechnicalConflictInfo.Add(TechnicalConflictInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return TechnicalConflictInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("TechnicalConflict,{1}",
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
        /// 更新
        /// </summary>
        /// <param name="TechnicalConflictInfo"></param>
        /// <returns></returns>
        public bool Update(TechnicalConflictInfo TechnicalConflictInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictInfo.Where(o => o.ID == TechnicalConflictInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, TechnicalConflictInfo);
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
        /// <param name="TechnicalConflictInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_TechnicalConflictInfo.Remove(Query);
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

        public TechnicalConflictInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new TechnicalConflictInfo();
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
            return new TechnicalConflictInfo();
        }

        public List<TechnicalConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_TechnicalConflictInfo, bool>> where = PredicateExtensionses.True<tbl_TechnicalConflictInfo>();
            
                    if (!string.IsNullOrWhiteSpace(ProjectID))
                        where = where.And(a => a.ProjectID ==int.Parse(ProjectID));
                
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_TechnicalConflictInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public TechnicalConflictInfo GetBusinessObject(tbl_TechnicalConflictInfo TechnicalConflictInfoEntity)
        {
            TechnicalConflictInfo TechnicalConflictInfo = new TechnicalConflictInfo();
            
                                     TechnicalConflictInfo.ID = TechnicalConflictInfoEntity.ID;
                    
                                     TechnicalConflictInfo.ProjectID = TechnicalConflictInfoEntity.ProjectID;
                    
                                     TechnicalConflictInfo.SerialNum = TechnicalConflictInfoEntity.SerialNum;
                    
                                     TechnicalConflictInfo.ImproveCharacter = TechnicalConflictInfoEntity.ImproveCharacter;
                    
                                     TechnicalConflictInfo.DeteriorateCharacter = TechnicalConflictInfoEntity.DeteriorateCharacter;
                    
                                     TechnicalConflictInfo.Remark = TechnicalConflictInfoEntity.Remark;
                    
                                     TechnicalConflictInfo.CreateDateTime = TechnicalConflictInfoEntity.CreateDateTime;
                    

            return TechnicalConflictInfo;
        }

        public void SetDataEntity(tbl_TechnicalConflictInfo TechnicalConflictInfoEntity, TechnicalConflictInfo TechnicalConflictInfo)
        {
             
                                        if (TechnicalConflictInfo.ID != null)
                                            TechnicalConflictInfoEntity.ID = TechnicalConflictInfo.ID ?? 0;
                    
                                        if (TechnicalConflictInfo.ProjectID != null)
                                            TechnicalConflictInfoEntity.ProjectID = TechnicalConflictInfo.ProjectID;
                    
                                        if (TechnicalConflictInfo.SerialNum != null)
                                            TechnicalConflictInfoEntity.SerialNum = TechnicalConflictInfo.SerialNum;
                    
                                        if (TechnicalConflictInfo.ImproveCharacter != null)
                                            TechnicalConflictInfoEntity.ImproveCharacter = TechnicalConflictInfo.ImproveCharacter;
                    
                                        if (TechnicalConflictInfo.DeteriorateCharacter != null)
                                            TechnicalConflictInfoEntity.DeteriorateCharacter = TechnicalConflictInfo.DeteriorateCharacter;
                    
                                        if (TechnicalConflictInfo.Remark != null)
                                            TechnicalConflictInfoEntity.Remark = TechnicalConflictInfo.Remark;
                    
        }

        public List<TechnicalConflictInfo> GetGetBusinessObjectList(List<tbl_TechnicalConflictInfo> TechnicalConflictInfoEntityList)
        {
            List<TechnicalConflictInfo> TechnicalConflictInfoList = new List<TechnicalConflictInfo>();
            foreach (tbl_TechnicalConflictInfo tbl_TechnicalConflictInfo in TechnicalConflictInfoEntityList)
            {
                TechnicalConflictInfoList.Add(GetBusinessObject(tbl_TechnicalConflictInfo));
            }
            return TechnicalConflictInfoList;
        }
    }
}



