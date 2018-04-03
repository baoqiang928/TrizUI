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
    public class StandardSolutionDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="StandardSolutionInfo"></param>
        /// <returns></returns>
        public bool Add(StandardSolutionInfo StandardSolutionInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_StandardSolutionInfo StandardSolutionInfoEntity = new tbl_StandardSolutionInfo();
                    SetDataEntity(StandardSolutionInfoEntity, StandardSolutionInfo);
                    TrizDB.tbl_StandardSolutionInfo.Add(StandardSolutionInfoEntity);
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
                            string message = string.Format("StandardSolution,{1}",
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
        /// <param name="StandardSolutionInfo"></param>
        /// <returns></returns>
        public bool Update(StandardSolutionInfo StandardSolutionInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionInfo.Where(o => o.ID == StandardSolutionInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, StandardSolutionInfo);
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
        /// <param name="StandardSolutionInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_StandardSolutionInfo.Remove(Query);
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

        public StandardSolutionInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new StandardSolutionInfo();
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
            return new StandardSolutionInfo();
        }

        public List<StandardSolutionInfo> Query(string ProjectID,string Name,string Note,string Remark,string TypeID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_StandardSolutionInfo, bool>> where = PredicateExtensionses.True<tbl_StandardSolutionInfo>();
            
                    if (!string.IsNullOrWhiteSpace(ProjectID))
                        where = where.And(a => a.ProjectID==int.Parse(ProjectID));
                
                    if (!string.IsNullOrWhiteSpace(Name))
                        where = where.And(a => a.Name.Contains(Name));
                
                    if (!string.IsNullOrWhiteSpace(Note))
                        where = where.And(a => a.Note.Contains(Note));
                
                    if (!string.IsNullOrWhiteSpace(Remark))
                        where = where.And(a => a.Remark.Contains(Remark));
                
                    if (!string.IsNullOrWhiteSpace(TypeID))
                        where = where.And(a => a.TypeID==int.Parse(TypeID));
                
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_StandardSolutionInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public StandardSolutionInfo GetBusinessObject(tbl_StandardSolutionInfo StandardSolutionInfoEntity)
        {
            StandardSolutionInfo StandardSolutionInfo = new StandardSolutionInfo();
            
                                     StandardSolutionInfo.ID = StandardSolutionInfoEntity.ID;
                    
                                     StandardSolutionInfo.ProjectID = StandardSolutionInfoEntity.ProjectID;
                    
                                     StandardSolutionInfo.SerialNum = StandardSolutionInfoEntity.SerialNum;
                    
                                     StandardSolutionInfo.Name = StandardSolutionInfoEntity.Name;
                    
                                     StandardSolutionInfo.Note = StandardSolutionInfoEntity.Note;
                    
                                     StandardSolutionInfo.Remark = StandardSolutionInfoEntity.Remark;
                    
                                     StandardSolutionInfo.TypeID = StandardSolutionInfoEntity.TypeID;
                    
                                     StandardSolutionInfo.CreateDateTime = StandardSolutionInfoEntity.CreateDateTime;
                    

            return StandardSolutionInfo;
        }

        public void SetDataEntity(tbl_StandardSolutionInfo StandardSolutionInfoEntity, StandardSolutionInfo StandardSolutionInfo)
        {
             
                                        if (StandardSolutionInfo.ID != null)
                                            StandardSolutionInfoEntity.ID = StandardSolutionInfo.ID ?? 0;
                    
                                        if (StandardSolutionInfo.ProjectID != null)
                                            StandardSolutionInfoEntity.ProjectID = StandardSolutionInfo.ProjectID;
                    
                                        if (StandardSolutionInfo.SerialNum != null)
                                            StandardSolutionInfoEntity.SerialNum = StandardSolutionInfo.SerialNum;
                    
                                        if (StandardSolutionInfo.Name != null)
                                            StandardSolutionInfoEntity.Name = StandardSolutionInfo.Name;
                    
                                        if (StandardSolutionInfo.Note != null)
                                            StandardSolutionInfoEntity.Note = StandardSolutionInfo.Note;
                    
                                        if (StandardSolutionInfo.Remark != null)
                                            StandardSolutionInfoEntity.Remark = StandardSolutionInfo.Remark;
                    
                                        if (StandardSolutionInfo.TypeID != null)
                                            StandardSolutionInfoEntity.TypeID = StandardSolutionInfo.TypeID;
                    
        }

        public List<StandardSolutionInfo> GetGetBusinessObjectList(List<tbl_StandardSolutionInfo> StandardSolutionInfoEntityList)
        {
            List<StandardSolutionInfo> StandardSolutionInfoList = new List<StandardSolutionInfo>();
            foreach (tbl_StandardSolutionInfo tbl_StandardSolutionInfo in StandardSolutionInfoEntityList)
            {
                StandardSolutionInfoList.Add(GetBusinessObject(tbl_StandardSolutionInfo));
            }
            return StandardSolutionInfoList;
        }
    }
}



