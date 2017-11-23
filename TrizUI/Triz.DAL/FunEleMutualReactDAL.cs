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
    public class FunEleMutualReactDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="FunEleMutualReactInfo"></param>
        /// <returns></returns>
        public bool Add(FunEleMutualReactInfo FunEleMutualReactInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_FunEleMutualReactInfo FunEleMutualReactInfoEntity = new tbl_FunEleMutualReactInfo();
                    SetDataEntity(FunEleMutualReactInfoEntity, FunEleMutualReactInfo);
                    TrizDB.tbl_FunEleMutualReactInfo.Add(FunEleMutualReactInfoEntity);
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
                            string message = string.Format("FunEleMutualReact,{1}",
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
        /// <param name="FunEleMutualReactInfo"></param>
        /// <returns></returns>
        public bool Update(FunEleMutualReactInfo FunEleMutualReactInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunEleMutualReactInfo.Where(o => o.ID == FunEleMutualReactInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, FunEleMutualReactInfo);
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
        /// <param name="FunEleMutualReactInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunEleMutualReactInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_FunEleMutualReactInfo.Remove(Query);
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
        public void DeleteAllNoWithinLeafs(List<FunctionElementInfo> Leafs)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    int?[] ids = new int?[Leafs.Count];
                    int i = 0;
                    foreach (FunctionElementInfo leaf in Leafs)
                    {
                        ids[i] = leaf.ID ?? 0;
                        i++;
                    }

                    var Query = from f in TrizDB.tbl_FunEleMutualReactInfo
                                where !ids.Contains(f.PositiveEleID) && !ids.Contains(f.PassiveEleID)
                                select f;

                    if (Query == null) return;
                    foreach (tbl_FunEleMutualReactInfo f in Query)
                    {
                        TrizDB.tbl_FunEleMutualReactInfo.Remove(f);
                    }
                    TrizDB.SaveChanges();
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
        }
        /// <summary>
        /// 根據元素ID刪除作用關係
        /// </summary>
        /// <param name="elementID"></param>
        /// <returns></returns>
        public int DeleteByElementID(int elementID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunEleMutualReactInfo.Where(o => (o.PositiveEleID == elementID) || (o.PassiveEleID == elementID)).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_FunEleMutualReactInfo.Remove(Query);
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


        public FunEleMutualReactInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_FunEleMutualReactInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new FunEleMutualReactInfo();
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
            return new FunEleMutualReactInfo();
        }

        public List<FunEleMutualReactInfo> Query(int ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_FunEleMutualReactInfo, bool>> where = PredicateExtensionses.True<tbl_FunEleMutualReactInfo>();
            where = where.And(a => a.ProjectID == ProjectID);


            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_FunEleMutualReactInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public FunEleMutualReactInfo GetBusinessObject(tbl_FunEleMutualReactInfo FunEleMutualReactInfoEntity)
        {
            FunEleMutualReactInfo FunEleMutualReactInfo = new FunEleMutualReactInfo();

            FunEleMutualReactInfo.ID = FunEleMutualReactInfoEntity.ID;
            FunEleMutualReactInfo.ProjectID = FunEleMutualReactInfoEntity.ProjectID;
            FunEleMutualReactInfo.PositiveEleID = FunEleMutualReactInfoEntity.PositiveEleID;

            FunEleMutualReactInfo.PositiveEleName = FunEleMutualReactInfoEntity.PositiveEleName;

            FunEleMutualReactInfo.FunctionName = FunEleMutualReactInfoEntity.FunctionName;

            FunEleMutualReactInfo.PassiveEleID = FunEleMutualReactInfoEntity.PassiveEleID;

            FunEleMutualReactInfo.PassiveEleName = FunEleMutualReactInfoEntity.PassiveEleName;

            FunEleMutualReactInfo.FunctionType = FunEleMutualReactInfoEntity.FunctionType;

            FunEleMutualReactInfo.FunctionGrade = FunEleMutualReactInfoEntity.FunctionGrade;

            FunEleMutualReactInfo.ElementType = FunEleMutualReactInfoEntity.ElementType;

            FunEleMutualReactInfo.CreateDateTime = FunEleMutualReactInfoEntity.CreateDateTime;


            return FunEleMutualReactInfo;
        }

        public void SetDataEntity(tbl_FunEleMutualReactInfo FunEleMutualReactInfoEntity, FunEleMutualReactInfo FunEleMutualReactInfo)
        {

            if (FunEleMutualReactInfo.ID != null)
                FunEleMutualReactInfoEntity.ID = FunEleMutualReactInfo.ID ?? 0;

            if (FunEleMutualReactInfo.ProjectID != null)
                FunEleMutualReactInfoEntity.ProjectID = FunEleMutualReactInfo.ProjectID;

            if (FunEleMutualReactInfo.PositiveEleID != null)
                FunEleMutualReactInfoEntity.PositiveEleID = FunEleMutualReactInfo.PositiveEleID;

            if (FunEleMutualReactInfo.PositiveEleName != null)
                FunEleMutualReactInfoEntity.PositiveEleName = FunEleMutualReactInfo.PositiveEleName;

            if (FunEleMutualReactInfo.FunctionName != null)
                FunEleMutualReactInfoEntity.FunctionName = FunEleMutualReactInfo.FunctionName;

            if (FunEleMutualReactInfo.PassiveEleID != null)
                FunEleMutualReactInfoEntity.PassiveEleID = FunEleMutualReactInfo.PassiveEleID;

            if (FunEleMutualReactInfo.PassiveEleName != null)
                FunEleMutualReactInfoEntity.PassiveEleName = FunEleMutualReactInfo.PassiveEleName;

            if (FunEleMutualReactInfo.FunctionType != null)
                FunEleMutualReactInfoEntity.FunctionType = FunEleMutualReactInfo.FunctionType;

            if (FunEleMutualReactInfo.FunctionGrade != null)
                FunEleMutualReactInfoEntity.FunctionGrade = FunEleMutualReactInfo.FunctionGrade;

            if (FunEleMutualReactInfo.ElementType != null)
                FunEleMutualReactInfoEntity.ElementType = FunEleMutualReactInfo.ElementType;

        }

        public List<FunEleMutualReactInfo> GetGetBusinessObjectList(List<tbl_FunEleMutualReactInfo> FunEleMutualReactInfoEntityList)
        {
            List<FunEleMutualReactInfo> FunEleMutualReactInfoList = new List<FunEleMutualReactInfo>();
            foreach (tbl_FunEleMutualReactInfo tbl_FunEleMutualReactInfo in FunEleMutualReactInfoEntityList)
            {
                FunEleMutualReactInfoList.Add(GetBusinessObject(tbl_FunEleMutualReactInfo));
            }
            return FunEleMutualReactInfoList;
        }
    }
}



