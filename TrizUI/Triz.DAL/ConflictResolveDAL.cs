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
    public class ConflictResolveDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ConflictResolveInfo"></param>
        /// <returns></returns>
        public int Add(ConflictResolveInfo ConflictResolveInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ConflictResolveInfo ConflictResolveInfoEntity = new tbl_ConflictResolveInfo();
                    SetDataEntity(ConflictResolveInfoEntity, ConflictResolveInfo);
                    TrizDB.tbl_ConflictResolveInfo.Add(ConflictResolveInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return ConflictResolveInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("ConflictResolve,{1}",
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
        /// <param name="ConflictResolveInfo"></param>
        /// <returns></returns>
        public bool Update(ConflictResolveInfo ConflictResolveInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictResolveInfo.Where(o => o.ID == ConflictResolveInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, ConflictResolveInfo);
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
        /// <param name="ConflictResolveInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictResolveInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ConflictResolveInfo.Remove(Query);
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

        public ConflictResolveInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictResolveInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new ConflictResolveInfo();
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
            return new ConflictResolveInfo();
        }

        public List<ConflictResolveInfo> Query(string ProjectID, string ConflictID,string ConflictType, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ConflictResolveInfo, bool>> where = PredicateExtensionses.True<tbl_ConflictResolveInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));
            if (!string.IsNullOrWhiteSpace(ConflictID))
                where = where.And(a => a.ConflictID == int.Parse(ConflictID));
            if (!string.IsNullOrWhiteSpace(ConflictType))
                where = where.And(a => a.ConflictType == ConflictType);

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ConflictResolveInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ConflictResolveInfo GetBusinessObject(tbl_ConflictResolveInfo ConflictResolveInfoEntity)
        {
            ConflictResolveInfo ConflictResolveInfo = new ConflictResolveInfo();

            ConflictResolveInfo.ID = ConflictResolveInfoEntity.ID;

            ConflictResolveInfo.ProjectID = ConflictResolveInfoEntity.ProjectID;

            ConflictResolveInfo.SerialNum = ConflictResolveInfoEntity.SerialNum;

            ConflictResolveInfo.ConflictType = ConflictResolveInfoEntity.ConflictType;

            ConflictResolveInfo.ConflictID = ConflictResolveInfoEntity.ConflictID;

            ConflictResolveInfo.ForwardCharacter = ConflictResolveInfoEntity.ForwardCharacter;

            ConflictResolveInfo.BackwardCharacter = ConflictResolveInfoEntity.BackwardCharacter;

            ConflictResolveInfo.DevidePrincipleID = ConflictResolveInfoEntity.DevidePrincipleID;

            ConflictResolveInfo.DevidePrincipleName = ConflictResolveInfoEntity.DevidePrincipleName;

            ConflictResolveInfo.InventivePrincipleID = ConflictResolveInfoEntity.InventivePrincipleID;

            ConflictResolveInfo.InventivePrincipleName = ConflictResolveInfoEntity.InventivePrincipleName;

            ConflictResolveInfo.CaseID = ConflictResolveInfoEntity.CaseID;

            ConflictResolveInfo.CaseName = ConflictResolveInfoEntity.CaseName;

            ConflictResolveInfo.Remark = ConflictResolveInfoEntity.Remark;

            ConflictResolveInfo.CreateDateTime = ConflictResolveInfoEntity.CreateDateTime;


            return ConflictResolveInfo;
        }

        public void SetDataEntity(tbl_ConflictResolveInfo ConflictResolveInfoEntity, ConflictResolveInfo ConflictResolveInfo)
        {

            if (ConflictResolveInfo.ID != null)
                ConflictResolveInfoEntity.ID = ConflictResolveInfo.ID ?? 0;

            if (ConflictResolveInfo.ProjectID != null)
                ConflictResolveInfoEntity.ProjectID = ConflictResolveInfo.ProjectID;

            if (ConflictResolveInfo.SerialNum != null)
                ConflictResolveInfoEntity.SerialNum = ConflictResolveInfo.SerialNum;

            if (ConflictResolveInfo.ConflictType != null)
                ConflictResolveInfoEntity.ConflictType = ConflictResolveInfo.ConflictType;

            if (ConflictResolveInfo.ConflictID != null)
                ConflictResolveInfoEntity.ConflictID = ConflictResolveInfo.ConflictID;

            if (ConflictResolveInfo.ForwardCharacter != null)
                ConflictResolveInfoEntity.ForwardCharacter = ConflictResolveInfo.ForwardCharacter;

            if (ConflictResolveInfo.BackwardCharacter != null)
                ConflictResolveInfoEntity.BackwardCharacter = ConflictResolveInfo.BackwardCharacter;

            if (ConflictResolveInfo.DevidePrincipleID != null)
                ConflictResolveInfoEntity.DevidePrincipleID = ConflictResolveInfo.DevidePrincipleID;

            if (ConflictResolveInfo.DevidePrincipleName != null)
                ConflictResolveInfoEntity.DevidePrincipleName = ConflictResolveInfo.DevidePrincipleName;

            if (ConflictResolveInfo.InventivePrincipleID != null)
                ConflictResolveInfoEntity.InventivePrincipleID = ConflictResolveInfo.InventivePrincipleID;

            if (ConflictResolveInfo.InventivePrincipleName != null)
                ConflictResolveInfoEntity.InventivePrincipleName = ConflictResolveInfo.InventivePrincipleName;

            if (ConflictResolveInfo.CaseID != null)
                ConflictResolveInfoEntity.CaseID = ConflictResolveInfo.CaseID;

            if (ConflictResolveInfo.CaseName != null)
                ConflictResolveInfoEntity.CaseName = ConflictResolveInfo.CaseName;

            if (ConflictResolveInfo.Remark != null)
                ConflictResolveInfoEntity.Remark = ConflictResolveInfo.Remark;

        }

        public List<ConflictResolveInfo> GetGetBusinessObjectList(List<tbl_ConflictResolveInfo> ConflictResolveInfoEntityList)
        {
            List<ConflictResolveInfo> ConflictResolveInfoList = new List<ConflictResolveInfo>();
            foreach (tbl_ConflictResolveInfo tbl_ConflictResolveInfo in ConflictResolveInfoEntityList)
            {
                ConflictResolveInfoList.Add(GetBusinessObject(tbl_ConflictResolveInfo));
            }
            return ConflictResolveInfoList;
        }
    }
}



