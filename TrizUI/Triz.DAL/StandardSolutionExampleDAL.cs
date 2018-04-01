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
    public class StandardSolutionExampleDAL
    {

        public List<StandardSolutionExampleInfo> GetFathers(string ProjectID)
        {
            Expression<Func<tbl_StandardSolutionExampleInfo, bool>> where = PredicateExtensionses.True<tbl_StandardSolutionExampleInfo>();
            where = where.And(a => a.ProjectID == int.Parse(ProjectID));
            where = where.And(a => a.FatherID == null);
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_StandardSolutionExampleInfo.Where(where.Compile());

                return GetGetBusinessObjectList(query.ToList());
            }

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="StandardSolutionExampleInfo"></param>
        /// <returns></returns>
        public bool Add(StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_StandardSolutionExampleInfo StandardSolutionExampleInfoEntity = new tbl_StandardSolutionExampleInfo();
                    SetDataEntity(StandardSolutionExampleInfoEntity, StandardSolutionExampleInfo);
                    TrizDB.tbl_StandardSolutionExampleInfo.Add(StandardSolutionExampleInfoEntity);
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
                            string message = string.Format("StandardSolutionExample,{1}",
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
        /// <param name="StandardSolutionExampleInfo"></param>
        /// <returns></returns>
        public bool Update(StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionExampleInfo.Where(o => o.ID == StandardSolutionExampleInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, StandardSolutionExampleInfo);
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
        public List<StandardSolutionExampleInfo> GetSons(string fatherID)
        {
            Expression<Func<tbl_StandardSolutionExampleInfo, bool>> where = PredicateExtensionses.True<tbl_StandardSolutionExampleInfo>();
            where = where.And(a => a.FatherID == int.Parse(fatherID));
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_StandardSolutionExampleInfo.Where(where.Compile());

                return GetGetBusinessObjectList(query.ToList());
            }

        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="StandardSolutionExampleInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionExampleInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_StandardSolutionExampleInfo.Remove(Query);
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

        public StandardSolutionExampleInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_StandardSolutionExampleInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new StandardSolutionExampleInfo();
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
            return new StandardSolutionExampleInfo();
        }

        public List<StandardSolutionExampleInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_StandardSolutionExampleInfo, bool>> where = PredicateExtensionses.True<tbl_StandardSolutionExampleInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID == int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_StandardSolutionExampleInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public StandardSolutionExampleInfo GetBusinessObject(tbl_StandardSolutionExampleInfo StandardSolutionExampleInfoEntity)
        {
            StandardSolutionExampleInfo StandardSolutionExampleInfo = new StandardSolutionExampleInfo();

            StandardSolutionExampleInfo.ID = StandardSolutionExampleInfoEntity.ID;

            StandardSolutionExampleInfo.ProjectID = StandardSolutionExampleInfoEntity.ProjectID;

            StandardSolutionExampleInfo.SerialNum = StandardSolutionExampleInfoEntity.SerialNum;

            StandardSolutionExampleInfo.Name = StandardSolutionExampleInfoEntity.Name;

            StandardSolutionExampleInfo.Note = StandardSolutionExampleInfoEntity.Note;

            StandardSolutionExampleInfo.Remark = StandardSolutionExampleInfoEntity.Remark;

            StandardSolutionExampleInfo.FatherID = StandardSolutionExampleInfoEntity.FatherID;

            StandardSolutionExampleInfo.CreateDateTime = StandardSolutionExampleInfoEntity.CreateDateTime;


            return StandardSolutionExampleInfo;
        }

        public void SetDataEntity(tbl_StandardSolutionExampleInfo StandardSolutionExampleInfoEntity, StandardSolutionExampleInfo StandardSolutionExampleInfo)
        {

            if (StandardSolutionExampleInfo.ID != null)
                StandardSolutionExampleInfoEntity.ID = StandardSolutionExampleInfo.ID ?? 0;

            if (StandardSolutionExampleInfo.ProjectID != null)
                StandardSolutionExampleInfoEntity.ProjectID = StandardSolutionExampleInfo.ProjectID;

            if (StandardSolutionExampleInfo.SerialNum != null)
                StandardSolutionExampleInfoEntity.SerialNum = StandardSolutionExampleInfo.SerialNum;

            if (StandardSolutionExampleInfo.Name != null)
                StandardSolutionExampleInfoEntity.Name = StandardSolutionExampleInfo.Name;

            if (StandardSolutionExampleInfo.Note != null)
                StandardSolutionExampleInfoEntity.Note = StandardSolutionExampleInfo.Note;

            if (StandardSolutionExampleInfo.Remark != null)
                StandardSolutionExampleInfoEntity.Remark = StandardSolutionExampleInfo.Remark;

            if (StandardSolutionExampleInfo.FatherID != null)
                StandardSolutionExampleInfoEntity.FatherID = StandardSolutionExampleInfo.FatherID;

        }

        public List<StandardSolutionExampleInfo> GetGetBusinessObjectList(List<tbl_StandardSolutionExampleInfo> StandardSolutionExampleInfoEntityList)
        {
            List<StandardSolutionExampleInfo> StandardSolutionExampleInfoList = new List<StandardSolutionExampleInfo>();
            foreach (tbl_StandardSolutionExampleInfo tbl_StandardSolutionExampleInfo in StandardSolutionExampleInfoEntityList)
            {
                StandardSolutionExampleInfoList.Add(GetBusinessObject(tbl_StandardSolutionExampleInfo));
            }
            return StandardSolutionExampleInfoList;
        }
    }
}



