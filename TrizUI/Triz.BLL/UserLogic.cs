using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class UserLogic
    {
        public void DeleteUser(int id)
        {
            new UserDAL().Delete(id);
        }

        public void DeleteUser(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new UserDAL().Delete(int.Parse(id));
            }
        }

        public void SaveUser(UserInfo UserInfo)
        {
            if (UserInfo.ID == null)
            {
                new UserDAL().Add(UserInfo);
                return;
            }
            new UserDAL().Update(UserInfo);

        }

        public UserInfo GetByID(string ID)
        {
           return new UserDAL().GetByID(int.Parse(ID));
        }
        public List<UserInfo> Query(string Name,string Mobile,string Email,string Account, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new UserDAL().Query(Name,Mobile,Email,Account, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


