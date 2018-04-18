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
    public class ConflictMatrixDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ConflictMatrixInfo"></param>
        /// <returns></returns>
        public int Add(ConflictMatrixInfo ConflictMatrixInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_ConflictMatrixInfo ConflictMatrixInfoEntity = new tbl_ConflictMatrixInfo();
                    SetDataEntity(ConflictMatrixInfoEntity, ConflictMatrixInfo);
                    TrizDB.tbl_ConflictMatrixInfo.Add(ConflictMatrixInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return ConflictMatrixInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("ConflictMatrix,{1}",
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
        /// <param name="ConflictMatrixInfo"></param>
        /// <returns></returns>
        public bool Update(ConflictMatrixInfo ConflictMatrixInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictMatrixInfo.Where(o => o.ID == ConflictMatrixInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, ConflictMatrixInfo);
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
        /// <param name="ConflictMatrixInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictMatrixInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_ConflictMatrixInfo.Remove(Query);
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

        public ConflictMatrixInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_ConflictMatrixInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new ConflictMatrixInfo();
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
            return new ConflictMatrixInfo();
        }
        public List<ConflictMatrixInfo> Query(string ImproveCharacter, string DeteriorateCharacter)
        {
            Expression<Func<tbl_ConflictMatrixInfo, bool>> where = PredicateExtensionses.True<tbl_ConflictMatrixInfo>();

            where = where.And(a => a.ImproveCharacter == ImproveCharacter);
            where = where.And(a => a.DeteriorateCharacter == DeteriorateCharacter);

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ConflictMatrixInfo.Where(where.Compile());
                query = query.OrderByDescending(p => p.ID);
                return GetGetBusinessObjectList(query.ToList());
            }
        }
        public List<ConflictMatrixInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_ConflictMatrixInfo, bool>> where = PredicateExtensionses.True<tbl_ConflictMatrixInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_ConflictMatrixInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public ConflictMatrixInfo GetBusinessObject(tbl_ConflictMatrixInfo ConflictMatrixInfoEntity)
        {
            ConflictMatrixInfo ConflictMatrixInfo = new ConflictMatrixInfo();

            ConflictMatrixInfo.ID = ConflictMatrixInfoEntity.ID;

            ConflictMatrixInfo.ProjectID = ConflictMatrixInfoEntity.ProjectID;

            ConflictMatrixInfo.ImproveCharacter = ConflictMatrixInfoEntity.ImproveCharacter;

            ConflictMatrixInfo.DeteriorateCharacter = ConflictMatrixInfoEntity.DeteriorateCharacter;

            ConflictMatrixInfo.ConflictIDs = ConflictMatrixInfoEntity.ConflictIDs;

            ConflictMatrixInfo.Remark = ConflictMatrixInfoEntity.Remark;

            ConflictMatrixInfo.CreateDateTime = ConflictMatrixInfoEntity.CreateDateTime;


            return ConflictMatrixInfo;
        }

        public void SetDataEntity(tbl_ConflictMatrixInfo ConflictMatrixInfoEntity, ConflictMatrixInfo ConflictMatrixInfo)
        {

            if (ConflictMatrixInfo.ID != null)
                ConflictMatrixInfoEntity.ID = ConflictMatrixInfo.ID ?? 0;

            if (ConflictMatrixInfo.ProjectID != null)
                ConflictMatrixInfoEntity.ProjectID = ConflictMatrixInfo.ProjectID;

            if (ConflictMatrixInfo.ImproveCharacter != null)
                ConflictMatrixInfoEntity.ImproveCharacter = ConflictMatrixInfo.ImproveCharacter;

            if (ConflictMatrixInfo.DeteriorateCharacter != null)
                ConflictMatrixInfoEntity.DeteriorateCharacter = ConflictMatrixInfo.DeteriorateCharacter;

            if (ConflictMatrixInfo.ConflictIDs != null)
                ConflictMatrixInfoEntity.ConflictIDs = ConflictMatrixInfo.ConflictIDs;

            if (ConflictMatrixInfo.Remark != null)
                ConflictMatrixInfoEntity.Remark = ConflictMatrixInfo.Remark;

        }

        public List<ConflictMatrixInfo> GetGetBusinessObjectList(List<tbl_ConflictMatrixInfo> ConflictMatrixInfoEntityList)
        {
            List<ConflictMatrixInfo> ConflictMatrixInfoList = new List<ConflictMatrixInfo>();
            foreach (tbl_ConflictMatrixInfo tbl_ConflictMatrixInfo in ConflictMatrixInfoEntityList)
            {
                ConflictMatrixInfoList.Add(GetBusinessObject(tbl_ConflictMatrixInfo));
            }
            return ConflictMatrixInfoList;
        }
    }
}



