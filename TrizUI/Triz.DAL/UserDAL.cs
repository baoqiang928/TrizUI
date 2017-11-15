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
    public class UserDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool Add(UserInfo UserInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_UserInfo UserInfoEntity = new tbl_UserInfo();
                    SetDataEntity(UserInfoEntity, UserInfo);
                    TrizDB.tbl_UserInfo.Add(UserInfoEntity);
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
                            string message = string.Format("User,{1}",
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
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public bool Update(UserInfo UserInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserInfo.Where(o => o.ID == UserInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, UserInfo);
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
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_UserInfo.Remove(Query);
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

        public UserInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_UserInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new UserInfo();
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
            return new UserInfo();
        }

        public List<UserInfo> Query(string Name, string Mobile, string Email, string Account, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_UserInfo, bool>> where = PredicateExtensionses.True<tbl_UserInfo>();

            if (!string.IsNullOrWhiteSpace(Name))
                where = where.And(a => a.Name.Contains(Name));

            if (!string.IsNullOrWhiteSpace(Mobile))
                where = where.And(a => a.Mobile.Contains(Mobile));

            if (!string.IsNullOrWhiteSpace(Email))
                where = where.And(a => a.Email.Contains(Email));

            if (!string.IsNullOrWhiteSpace(Account))
                where = where.And(a => a.Account.Contains(Account));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_UserInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public UserInfo GetBusinessObject(tbl_UserInfo UserInfoEntity)
        {
            UserInfo UserInfo = new UserInfo();

            UserInfo.ID = UserInfoEntity.ID;

            UserInfo.Name = UserInfoEntity.Name;

            UserInfo.CompanyID = UserInfoEntity.CompanyID;

            UserInfo.Mobile = UserInfoEntity.Mobile;

            UserInfo.Email = UserInfoEntity.Email;

            UserInfo.Account = UserInfoEntity.Account;

            UserInfo.Password = UserInfoEntity.Password;

            UserInfo.Remark = UserInfoEntity.Remark;

            UserInfo.CreateDateTime = UserInfoEntity.CreateDateTime;


            return UserInfo;
        }

        public void SetDataEntity(tbl_UserInfo UserInfoEntity, UserInfo UserInfo)
        {

            if (UserInfo.ID != null)
                UserInfoEntity.ID = UserInfo.ID ?? 0;

            if (UserInfo.Name != null)
                UserInfoEntity.Name = UserInfo.Name;

            if (UserInfo.CompanyID != null)
                UserInfoEntity.CompanyID = UserInfo.CompanyID;

            if (UserInfo.Mobile != null)
                UserInfoEntity.Mobile = UserInfo.Mobile;

            if (UserInfo.Email != null)
                UserInfoEntity.Email = UserInfo.Email;

            if (UserInfo.Account != null)
                UserInfoEntity.Account = UserInfo.Account;

            if (UserInfo.Password != null)
                UserInfoEntity.Password = UserInfo.Password;

            if (UserInfo.Remark != null)
                UserInfoEntity.Remark = UserInfo.Remark;

        }

        public List<UserInfo> GetGetBusinessObjectList(List<tbl_UserInfo> UserInfoEntityList)
        {
            List<UserInfo> UserInfoList = new List<UserInfo>();
            foreach (tbl_UserInfo tbl_UserInfo in UserInfoEntityList)
            {
                UserInfoList.Add(GetBusinessObject(tbl_UserInfo));
            }
            return UserInfoList;
        }
    }
}



