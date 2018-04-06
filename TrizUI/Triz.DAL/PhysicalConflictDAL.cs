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
    public class PhysicalConflictDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="PhysicalConflictInfo"></param>
        /// <returns></returns>
        public int Add(PhysicalConflictInfo PhysicalConflictInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_PhysicalConflictInfo PhysicalConflictInfoEntity = new tbl_PhysicalConflictInfo();
                    SetDataEntity(PhysicalConflictInfoEntity, PhysicalConflictInfo);
                    TrizDB.tbl_PhysicalConflictInfo.Add(PhysicalConflictInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return PhysicalConflictInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("PhysicalConflict,{1}",
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
        /// <param name="PhysicalConflictInfo"></param>
        /// <returns></returns>
        public bool Update(PhysicalConflictInfo PhysicalConflictInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_PhysicalConflictInfo.Where(o => o.ID == PhysicalConflictInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, PhysicalConflictInfo);
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
        /// <param name="PhysicalConflictInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_PhysicalConflictInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_PhysicalConflictInfo.Remove(Query);
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

        public PhysicalConflictInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_PhysicalConflictInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new PhysicalConflictInfo();
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
            return new PhysicalConflictInfo();
        }

        public List<PhysicalConflictInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_PhysicalConflictInfo, bool>> where = PredicateExtensionses.True<tbl_PhysicalConflictInfo>();
            
                    if (!string.IsNullOrWhiteSpace(ProjectID))
                        where = where.And(a => a.ProjectID ==int.Parse(ProjectID));
                
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_PhysicalConflictInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public PhysicalConflictInfo GetBusinessObject(tbl_PhysicalConflictInfo PhysicalConflictInfoEntity)
        {
            PhysicalConflictInfo PhysicalConflictInfo = new PhysicalConflictInfo();
            
                                     PhysicalConflictInfo.ID = PhysicalConflictInfoEntity.ID;
                    
                                     PhysicalConflictInfo.ProjectID = PhysicalConflictInfoEntity.ProjectID;
                    
                                     PhysicalConflictInfo.SerialNum = PhysicalConflictInfoEntity.SerialNum;
                    
                                     PhysicalConflictInfo.ForwardCharacter = PhysicalConflictInfoEntity.ForwardCharacter;
                    
                                     PhysicalConflictInfo.BackwardCharacter = PhysicalConflictInfoEntity.BackwardCharacter;
                    
                                     PhysicalConflictInfo.CommonRelevantParams = PhysicalConflictInfoEntity.CommonRelevantParams;
                    
                                     PhysicalConflictInfo.Remark = PhysicalConflictInfoEntity.Remark;
                    
                                     PhysicalConflictInfo.CreateDateTime = PhysicalConflictInfoEntity.CreateDateTime;
                    

            return PhysicalConflictInfo;
        }

        public void SetDataEntity(tbl_PhysicalConflictInfo PhysicalConflictInfoEntity, PhysicalConflictInfo PhysicalConflictInfo)
        {
             
                                        if (PhysicalConflictInfo.ID != null)
                                            PhysicalConflictInfoEntity.ID = PhysicalConflictInfo.ID ?? 0;
                    
                                        if (PhysicalConflictInfo.ProjectID != null)
                                            PhysicalConflictInfoEntity.ProjectID = PhysicalConflictInfo.ProjectID;
                    
                                        if (PhysicalConflictInfo.SerialNum != null)
                                            PhysicalConflictInfoEntity.SerialNum = PhysicalConflictInfo.SerialNum;
                    
                                        if (PhysicalConflictInfo.ForwardCharacter != null)
                                            PhysicalConflictInfoEntity.ForwardCharacter = PhysicalConflictInfo.ForwardCharacter;
                    
                                        if (PhysicalConflictInfo.BackwardCharacter != null)
                                            PhysicalConflictInfoEntity.BackwardCharacter = PhysicalConflictInfo.BackwardCharacter;
                    
                                        if (PhysicalConflictInfo.CommonRelevantParams != null)
                                            PhysicalConflictInfoEntity.CommonRelevantParams = PhysicalConflictInfo.CommonRelevantParams;
                    
                                        if (PhysicalConflictInfo.Remark != null)
                                            PhysicalConflictInfoEntity.Remark = PhysicalConflictInfo.Remark;
                    
        }

        public List<PhysicalConflictInfo> GetGetBusinessObjectList(List<tbl_PhysicalConflictInfo> PhysicalConflictInfoEntityList)
        {
            List<PhysicalConflictInfo> PhysicalConflictInfoList = new List<PhysicalConflictInfo>();
            foreach (tbl_PhysicalConflictInfo tbl_PhysicalConflictInfo in PhysicalConflictInfoEntityList)
            {
                PhysicalConflictInfoList.Add(GetBusinessObject(tbl_PhysicalConflictInfo));
            }
            return PhysicalConflictInfoList;
        }
    }
}



