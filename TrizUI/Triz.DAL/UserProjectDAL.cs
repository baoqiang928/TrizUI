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
    public class UserProjectDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="UserProjectInfo"></param>
        /// <returns></returns>
        public bool Add(UserProjectInfo UserProjectInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_UserProjectInfo UserProjectInfoEntity = new tbl_UserProjectInfo();
                    SetDataEntity(UserProjectInfoEntity, UserProjectInfo);
                    TrizDB.tbl_UserProjectInfo.Add(UserProjectInfoEntity);
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
                            string message = string.Format("UserProject,{1}",
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
        /// <param name="UserProjectInfo"></param>
        /// <returns></returns>
        public bool Update(UserProjectInfo UserProjectInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserProjectInfo.Where(o => o.ID == UserProjectInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, UserProjectInfo);
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
        /// <param name="UserProjectInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserProjectInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_UserProjectInfo.Remove(Query);
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

        public UserProjectInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserProjectInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new UserProjectInfo();
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
            return new UserProjectInfo();
        }

        public List<UserProjectInfo> Query(int UserID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_UserProjectInfo, bool>> where = PredicateExtensionses.True<tbl_UserProjectInfo>();

            where = where.And(a => a.UserID == UserID);

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_UserProjectInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public UserProjectInfo GetBusinessObject(tbl_UserProjectInfo UserProjectInfoEntity)
        {
            UserProjectInfo UserProjectInfo = new UserProjectInfo();

            UserProjectInfo.ID = UserProjectInfoEntity.ID;

            UserProjectInfo.UserID = UserProjectInfoEntity.UserID;

            UserProjectInfo.ProjectID = UserProjectInfoEntity.ProjectID;

            UserProjectInfo.CreateDateTime = UserProjectInfoEntity.CreateDateTime;


            return UserProjectInfo;
        }

        public void SetDataEntity(tbl_UserProjectInfo UserProjectInfoEntity, UserProjectInfo UserProjectInfo)
        {

            if (UserProjectInfo.ID != null)
                UserProjectInfoEntity.ID = UserProjectInfo.ID ?? 0;

            if (UserProjectInfo.UserID != null)
                UserProjectInfoEntity.UserID = UserProjectInfo.UserID;

            if (UserProjectInfo.ProjectID != null)
                UserProjectInfoEntity.ProjectID = UserProjectInfo.ProjectID;

        }

        public List<UserProjectInfo> GetGetBusinessObjectList(List<tbl_UserProjectInfo> UserProjectInfoEntityList)
        {
            List<UserProjectInfo> UserProjectInfoList = new List<UserProjectInfo>();
            foreach (tbl_UserProjectInfo tbl_UserProjectInfo in UserProjectInfoEntityList)
            {
                UserProjectInfoList.Add(GetBusinessObject(tbl_UserProjectInfo));
            }
            return UserProjectInfoList;
        }
    }
}


