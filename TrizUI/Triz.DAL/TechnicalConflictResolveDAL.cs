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
    public class TechnicalConflictResolveDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="TechnicalConflictResolveInfo"></param>
        /// <returns></returns>
        public int Add(TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_TechnicalConflictResolveInfo TechnicalConflictResolveInfoEntity = new tbl_TechnicalConflictResolveInfo();
                    SetDataEntity(TechnicalConflictResolveInfoEntity, TechnicalConflictResolveInfo);
                    TrizDB.tbl_TechnicalConflictResolveInfo.Add(TechnicalConflictResolveInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return TechnicalConflictResolveInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("TechnicalConflictResolve,{1}",
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
        /// <param name="TechnicalConflictResolveInfo"></param>
        /// <returns></returns>
        public bool Update(TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictResolveInfo.Where(o => o.ID == TechnicalConflictResolveInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, TechnicalConflictResolveInfo);
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
        /// <param name="TechnicalConflictResolveInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictResolveInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_TechnicalConflictResolveInfo.Remove(Query);
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

        public TechnicalConflictResolveInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechnicalConflictResolveInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new TechnicalConflictResolveInfo();
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
            return new TechnicalConflictResolveInfo();
        }

        public List<TechnicalConflictResolveInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_TechnicalConflictResolveInfo, bool>> where = PredicateExtensionses.True<tbl_TechnicalConflictResolveInfo>();
            
                    if (!string.IsNullOrWhiteSpace(ProjectID))
                        where = where.And(a => a.ProjectID==int.Parse(ProjectID));
                
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_TechnicalConflictResolveInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public TechnicalConflictResolveInfo GetBusinessObject(tbl_TechnicalConflictResolveInfo TechnicalConflictResolveInfoEntity)
        {
            TechnicalConflictResolveInfo TechnicalConflictResolveInfo = new TechnicalConflictResolveInfo();
            
                                     TechnicalConflictResolveInfo.ID = TechnicalConflictResolveInfoEntity.ID;
                    
                                     TechnicalConflictResolveInfo.ProjectID = TechnicalConflictResolveInfoEntity.ProjectID;
                    
                                     TechnicalConflictResolveInfo.SerialNum = TechnicalConflictResolveInfoEntity.SerialNum;
                    
                                     TechnicalConflictResolveInfo.TechnicalConflictID = TechnicalConflictResolveInfoEntity.TechnicalConflictID;
                    
                                     TechnicalConflictResolveInfo.ForwardCharacter = TechnicalConflictResolveInfoEntity.ForwardCharacter;
                    
                                     TechnicalConflictResolveInfo.BackwardCharacter = TechnicalConflictResolveInfoEntity.BackwardCharacter;
                    
                                     TechnicalConflictResolveInfo.InventivePrincipleID = TechnicalConflictResolveInfoEntity.InventivePrincipleID;
                    
                                     TechnicalConflictResolveInfo.InventivePrincipleName = TechnicalConflictResolveInfoEntity.InventivePrincipleName;
                    
                                     TechnicalConflictResolveInfo.CaseID = TechnicalConflictResolveInfoEntity.CaseID;
                    
                                     TechnicalConflictResolveInfo.CaseName = TechnicalConflictResolveInfoEntity.CaseName;
                    
                                     TechnicalConflictResolveInfo.Remark = TechnicalConflictResolveInfoEntity.Remark;
                    
                                     TechnicalConflictResolveInfo.CreateDateTime = TechnicalConflictResolveInfoEntity.CreateDateTime;
                    

            return TechnicalConflictResolveInfo;
        }

        public void SetDataEntity(tbl_TechnicalConflictResolveInfo TechnicalConflictResolveInfoEntity, TechnicalConflictResolveInfo TechnicalConflictResolveInfo)
        {
             
                                        if (TechnicalConflictResolveInfo.ID != null)
                                            TechnicalConflictResolveInfoEntity.ID = TechnicalConflictResolveInfo.ID ?? 0;
                    
                                        if (TechnicalConflictResolveInfo.ProjectID != null)
                                            TechnicalConflictResolveInfoEntity.ProjectID = TechnicalConflictResolveInfo.ProjectID;
                    
                                        if (TechnicalConflictResolveInfo.SerialNum != null)
                                            TechnicalConflictResolveInfoEntity.SerialNum = TechnicalConflictResolveInfo.SerialNum;
                    
                                        if (TechnicalConflictResolveInfo.TechnicalConflictID != null)
                                            TechnicalConflictResolveInfoEntity.TechnicalConflictID = TechnicalConflictResolveInfo.TechnicalConflictID;
                    
                                        if (TechnicalConflictResolveInfo.ForwardCharacter != null)
                                            TechnicalConflictResolveInfoEntity.ForwardCharacter = TechnicalConflictResolveInfo.ForwardCharacter;
                    
                                        if (TechnicalConflictResolveInfo.BackwardCharacter != null)
                                            TechnicalConflictResolveInfoEntity.BackwardCharacter = TechnicalConflictResolveInfo.BackwardCharacter;
                    
                                        if (TechnicalConflictResolveInfo.InventivePrincipleID != null)
                                            TechnicalConflictResolveInfoEntity.InventivePrincipleID = TechnicalConflictResolveInfo.InventivePrincipleID;
                    
                                        if (TechnicalConflictResolveInfo.InventivePrincipleName != null)
                                            TechnicalConflictResolveInfoEntity.InventivePrincipleName = TechnicalConflictResolveInfo.InventivePrincipleName;
                    
                                        if (TechnicalConflictResolveInfo.CaseID != null)
                                            TechnicalConflictResolveInfoEntity.CaseID = TechnicalConflictResolveInfo.CaseID;
                    
                                        if (TechnicalConflictResolveInfo.CaseName != null)
                                            TechnicalConflictResolveInfoEntity.CaseName = TechnicalConflictResolveInfo.CaseName;
                    
                                        if (TechnicalConflictResolveInfo.Remark != null)
                                            TechnicalConflictResolveInfoEntity.Remark = TechnicalConflictResolveInfo.Remark;
                    
        }

        public List<TechnicalConflictResolveInfo> GetGetBusinessObjectList(List<tbl_TechnicalConflictResolveInfo> TechnicalConflictResolveInfoEntityList)
        {
            List<TechnicalConflictResolveInfo> TechnicalConflictResolveInfoList = new List<TechnicalConflictResolveInfo>();
            foreach (tbl_TechnicalConflictResolveInfo tbl_TechnicalConflictResolveInfo in TechnicalConflictResolveInfoEntityList)
            {
                TechnicalConflictResolveInfoList.Add(GetBusinessObject(tbl_TechnicalConflictResolveInfo));
            }
            return TechnicalConflictResolveInfoList;
        }
    }
}



