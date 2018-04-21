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
    public class TechEvolutionDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="TechEvolutionInfo"></param>
        /// <returns></returns>
        public int Add(TechEvolutionInfo TechEvolutionInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_TechEvolutionInfo TechEvolutionInfoEntity = new tbl_TechEvolutionInfo();
                    SetDataEntity(TechEvolutionInfoEntity, TechEvolutionInfo);
                    TrizDB.tbl_TechEvolutionInfo.Add(TechEvolutionInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return TechEvolutionInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("TechEvolution,{1}",
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
        /// <param name="TechEvolutionInfo"></param>
        /// <returns></returns>
        public bool Update(TechEvolutionInfo TechEvolutionInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechEvolutionInfo.Where(o => o.ID == TechEvolutionInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, TechEvolutionInfo);
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
        /// <param name="TechEvolutionInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechEvolutionInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_TechEvolutionInfo.Remove(Query);
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

        public TechEvolutionInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_TechEvolutionInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new TechEvolutionInfo();
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
            return new TechEvolutionInfo();
        }

        public List<TechEvolutionInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_TechEvolutionInfo, bool>> where = PredicateExtensionses.True<tbl_TechEvolutionInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_TechEvolutionInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public TechEvolutionInfo GetBusinessObject(tbl_TechEvolutionInfo TechEvolutionInfoEntity)
        {
            TechEvolutionInfo TechEvolutionInfo = new TechEvolutionInfo();

            TechEvolutionInfo.ID = TechEvolutionInfoEntity.ID;

            TechEvolutionInfo.ProjectID = TechEvolutionInfoEntity.ProjectID;

            TechEvolutionInfo.SerialNum = TechEvolutionInfoEntity.SerialNum;

            TechEvolutionInfo.Name = TechEvolutionInfoEntity.Name;

            TechEvolutionInfo.Character = TechEvolutionInfoEntity.Character;

            TechEvolutionInfo.PrincipleIDs = TechEvolutionInfoEntity.PrincipleIDs;

            TechEvolutionInfo.Remark = TechEvolutionInfoEntity.Remark;

            TechEvolutionInfo.CreateDateTime = TechEvolutionInfoEntity.CreateDateTime;


            return TechEvolutionInfo;
        }

        public void SetDataEntity(tbl_TechEvolutionInfo TechEvolutionInfoEntity, TechEvolutionInfo TechEvolutionInfo)
        {

            if (TechEvolutionInfo.ID != null)
                TechEvolutionInfoEntity.ID = TechEvolutionInfo.ID ?? 0;

            if (TechEvolutionInfo.ProjectID != null)
                TechEvolutionInfoEntity.ProjectID = TechEvolutionInfo.ProjectID;

            if (TechEvolutionInfo.SerialNum != null)
                TechEvolutionInfoEntity.SerialNum = TechEvolutionInfo.SerialNum;

            if (TechEvolutionInfo.Name != null)
                TechEvolutionInfoEntity.Name = TechEvolutionInfo.Name;

            if (TechEvolutionInfo.Character != null)
                TechEvolutionInfoEntity.Character = TechEvolutionInfo.Character;

            if (TechEvolutionInfo.Remark != null)
                TechEvolutionInfoEntity.Remark = TechEvolutionInfo.Remark;

            if (TechEvolutionInfo.PrincipleIDs != null)
                TechEvolutionInfoEntity.PrincipleIDs = TechEvolutionInfo.PrincipleIDs;

        }

        public List<TechEvolutionInfo> GetGetBusinessObjectList(List<tbl_TechEvolutionInfo> TechEvolutionInfoEntityList)
        {
            List<TechEvolutionInfo> TechEvolutionInfoList = new List<TechEvolutionInfo>();
            foreach (tbl_TechEvolutionInfo tbl_TechEvolutionInfo in TechEvolutionInfoEntityList)
            {
                TechEvolutionInfoList.Add(GetBusinessObject(tbl_TechEvolutionInfo));
            }
            return TechEvolutionInfoList;
        }
    }
}



