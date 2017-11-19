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
    public class FunctionElementDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="FunctionElementInfo"></param>
        /// <returns></returns>
        public bool Add(FunctionElementInfo FunctionElementInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_FunctionElementInfo FunctionElementInfoEntity = new tbl_FunctionElementInfo();
                    SetDataEntity(FunctionElementInfoEntity, FunctionElementInfo);
                    TrizDB.tbl_FunctionElementInfo.Add(FunctionElementInfoEntity);
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
                            string message = string.Format("FunctionElement,{1}",
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
        /// <param name="FunctionElementInfo"></param>
        /// <returns></returns>
        public bool Update(FunctionElementInfo FunctionElementInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunctionElementInfo.Where(o => o.ID == FunctionElementInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, FunctionElementInfo);
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
        /// <param name="FunctionElementInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunctionElementInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_FunctionElementInfo.Remove(Query);
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

        public FunctionElementInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunctionElementInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new FunctionElementInfo();
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
            return new FunctionElementInfo();
        }

        public List<FunctionElementInfo> Query(string ProjectID, string EleName, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_FunctionElementInfo, bool>> where = PredicateExtensionses.True<tbl_FunctionElementInfo>();
            where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            if (!string.IsNullOrWhiteSpace(EleName))
                where = where.And(a => a.EleName.Contains(EleName));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_FunctionElementInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public FunctionElementInfo GetBusinessObject(tbl_FunctionElementInfo FunctionElementInfoEntity)
        {
            FunctionElementInfo FunctionElementInfo = new FunctionElementInfo();

            FunctionElementInfo.ID = FunctionElementInfoEntity.ID;

            FunctionElementInfo.ProjectID = FunctionElementInfoEntity.ProjectID;

            FunctionElementInfo.EleName = FunctionElementInfoEntity.EleName;

            FunctionElementInfo.ElementType = FunctionElementInfoEntity.ElementType;

            FunctionElementInfo.EleX = FunctionElementInfoEntity.EleX;

            FunctionElementInfo.EleY = FunctionElementInfoEntity.EleY;

            FunctionElementInfo.Remark = FunctionElementInfoEntity.Remark;

            FunctionElementInfo.FatherID = FunctionElementInfoEntity.FatherID;

            FunctionElementInfo.CreateDateTime = FunctionElementInfoEntity.CreateDateTime;


            return FunctionElementInfo;
        }

        public void SetDataEntity(tbl_FunctionElementInfo FunctionElementInfoEntity, FunctionElementInfo FunctionElementInfo)
        {

            if (FunctionElementInfo.ID != null)
                FunctionElementInfoEntity.ID = FunctionElementInfo.ID ?? 0;

            if (FunctionElementInfo.ProjectID != null)
                FunctionElementInfoEntity.ProjectID = FunctionElementInfo.ProjectID;

            if (FunctionElementInfo.EleName != null)
                FunctionElementInfoEntity.EleName = FunctionElementInfo.EleName;

            if (FunctionElementInfo.ElementType != null)
                FunctionElementInfoEntity.ElementType = FunctionElementInfo.ElementType;

            if (FunctionElementInfo.EleX != null)
                FunctionElementInfoEntity.EleX = FunctionElementInfo.EleX;

            if (FunctionElementInfo.EleY != null)
                FunctionElementInfoEntity.EleY = FunctionElementInfo.EleY;

            if (FunctionElementInfo.Remark != null)
                FunctionElementInfoEntity.Remark = FunctionElementInfo.Remark;

            if (FunctionElementInfo.FatherID != null)
                FunctionElementInfoEntity.FatherID = FunctionElementInfo.FatherID;

        }

        public List<FunctionElementInfo> GetGetBusinessObjectList(List<tbl_FunctionElementInfo> FunctionElementInfoEntityList)
        {
            List<FunctionElementInfo> FunctionElementInfoList = new List<FunctionElementInfo>();
            foreach (tbl_FunctionElementInfo tbl_FunctionElementInfo in FunctionElementInfoEntityList)
            {
                FunctionElementInfoList.Add(GetBusinessObject(tbl_FunctionElementInfo));
            }
            return FunctionElementInfoList;
        }
    }
}



