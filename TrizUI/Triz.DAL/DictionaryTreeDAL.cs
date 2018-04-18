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
    public class DictionaryTreeDAL
    {
        /// <summary>
        /// 根据发明原理ID，找到分离原理ID
        /// </summary>
        /// <param name="InventivePrincipleID"></param>
        /// <returns></returns>
        public DictionaryTreeInfo GetDevidePrincipleInfoByInventivePrincipleID(string InventivePrincipleID)
        {
            Expression<Func<tbl_DictionaryTreeInfo, bool>> where = PredicateExtensionses.True<tbl_DictionaryTreeInfo>();
            where = where.And(a => (";"+a.Note+";").Contains(";"+ InventivePrincipleID + ";"));
            where = where.And(a => a.ProjectID == 0);
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var Query = TrizDB.tbl_DictionaryTreeInfo.Where(where.Compile()).FirstOrDefault();
                if (Query == null) return null;
                return GetBusinessObject(Query);
            }
            return new DictionaryTreeDAL().GetDevidePrincipleInfoByInventivePrincipleID(InventivePrincipleID);
        }

        public List<DictionaryTreeInfo> GetSons(int? FatherID)
        {
            Expression<Func<tbl_DictionaryTreeInfo, bool>> where = PredicateExtensionses.True<tbl_DictionaryTreeInfo>();
            where = where.And(a => a.FatherID == FatherID);
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_DictionaryTreeInfo.Where(where.Compile()).OrderByDescending(p => p.SerialNum);

                return GetGetBusinessObjectList(query.ToList());
            }

        }
        public DictionaryTreeInfo GetBySeq(string Seq)
        {
            Expression<Func<tbl_DictionaryTreeInfo, bool>> where = PredicateExtensionses.True<tbl_DictionaryTreeInfo>();
            where = where.And(a => a.Name.StartsWith(Seq + " "));
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var Query = TrizDB.tbl_DictionaryTreeInfo.Where(a => a.Name.StartsWith(Seq + " ")).FirstOrDefault();
                if (Query == null) return null;
                return GetBusinessObject(Query);
            }
        }



        public List<DictionaryTreeInfo> GetFathers(string ProjectID, string TreeTypeID)
        {
            Expression<Func<tbl_DictionaryTreeInfo, bool>> where = PredicateExtensionses.True<tbl_DictionaryTreeInfo>();
            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));
            where = where.And(a => a.TreeTypeID == int.Parse(TreeTypeID));
            where = where.And(a => a.FatherID == null);

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_DictionaryTreeInfo.Where(where.Compile());

                return GetGetBusinessObjectList(query.ToList());
            }

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="DictionaryTreeInfo"></param>
        /// <returns></returns>
        public int Add(DictionaryTreeInfo DictionaryTreeInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_DictionaryTreeInfo DictionaryTreeInfoEntity = new tbl_DictionaryTreeInfo();
                    SetDataEntity(DictionaryTreeInfoEntity, DictionaryTreeInfo);
                    TrizDB.tbl_DictionaryTreeInfo.Add(DictionaryTreeInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return DictionaryTreeInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("DictionaryTree,{1}",
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
        /// <param name="DictionaryTreeInfo"></param>
        /// <returns></returns>
        public bool Update(DictionaryTreeInfo DictionaryTreeInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_DictionaryTreeInfo.Where(o => o.ID == DictionaryTreeInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, DictionaryTreeInfo);
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
        /// <param name="DictionaryTreeInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_DictionaryTreeInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_DictionaryTreeInfo.Remove(Query);
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

        public DictionaryTreeInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_DictionaryTreeInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new DictionaryTreeInfo();
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
            return new DictionaryTreeInfo();
        }

        public List<DictionaryTreeInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_DictionaryTreeInfo, bool>> where = PredicateExtensionses.True<tbl_DictionaryTreeInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_DictionaryTreeInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public DictionaryTreeInfo GetBusinessObject(tbl_DictionaryTreeInfo DictionaryTreeInfoEntity)
        {
            DictionaryTreeInfo DictionaryTreeInfo = new DictionaryTreeInfo();

            DictionaryTreeInfo.ID = DictionaryTreeInfoEntity.ID;

            DictionaryTreeInfo.ProjectID = DictionaryTreeInfoEntity.ProjectID;

            DictionaryTreeInfo.TreeTypeID = DictionaryTreeInfoEntity.TreeTypeID;

            DictionaryTreeInfo.SerialNum = DictionaryTreeInfoEntity.SerialNum;

            DictionaryTreeInfo.Name = DictionaryTreeInfoEntity.Name;

            DictionaryTreeInfo.Type = DictionaryTreeInfoEntity.Type;

            DictionaryTreeInfo.Note = DictionaryTreeInfoEntity.Note;

            DictionaryTreeInfo.Remark = DictionaryTreeInfoEntity.Remark;

            DictionaryTreeInfo.FatherID = DictionaryTreeInfoEntity.FatherID;

            DictionaryTreeInfo.CreateDateTime = DictionaryTreeInfoEntity.CreateDateTime;


            return DictionaryTreeInfo;
        }

        public void SetDataEntity(tbl_DictionaryTreeInfo DictionaryTreeInfoEntity, DictionaryTreeInfo DictionaryTreeInfo)
        {

            if (DictionaryTreeInfo.ID != null)
                DictionaryTreeInfoEntity.ID = DictionaryTreeInfo.ID ?? 0;

            if (DictionaryTreeInfo.ProjectID != null)
                DictionaryTreeInfoEntity.ProjectID = DictionaryTreeInfo.ProjectID;

            if (DictionaryTreeInfo.TreeTypeID != null)
                DictionaryTreeInfoEntity.TreeTypeID = DictionaryTreeInfo.TreeTypeID;

            if (DictionaryTreeInfo.SerialNum != null)
                DictionaryTreeInfoEntity.SerialNum = DictionaryTreeInfo.SerialNum;

            if (DictionaryTreeInfo.Name != null)
                DictionaryTreeInfoEntity.Name = DictionaryTreeInfo.Name;

            if (DictionaryTreeInfo.Type != null)
                DictionaryTreeInfoEntity.Type = DictionaryTreeInfo.Type;

            if (DictionaryTreeInfo.Note != null)
                DictionaryTreeInfoEntity.Note = DictionaryTreeInfo.Note;

            if (DictionaryTreeInfo.Remark != null)
                DictionaryTreeInfoEntity.Remark = DictionaryTreeInfo.Remark;

            if (DictionaryTreeInfo.FatherID != null)
                DictionaryTreeInfoEntity.FatherID = DictionaryTreeInfo.FatherID;

        }

        public List<DictionaryTreeInfo> GetGetBusinessObjectList(List<tbl_DictionaryTreeInfo> DictionaryTreeInfoEntityList)
        {
            List<DictionaryTreeInfo> DictionaryTreeInfoList = new List<DictionaryTreeInfo>();
            foreach (tbl_DictionaryTreeInfo tbl_DictionaryTreeInfo in DictionaryTreeInfoEntityList)
            {
                DictionaryTreeInfoList.Add(GetBusinessObject(tbl_DictionaryTreeInfo));
            }
            return DictionaryTreeInfoList;
        }
    }
}



