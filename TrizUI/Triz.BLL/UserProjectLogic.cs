using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class UserProjectLogic
    {
        public void DeleteUserProject(int id)
        {
            new UserProjectDAL().Delete(id);
        }

        public void DeleteUserProject(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new UserProjectDAL().Delete(int.Parse(id));
            }
        }

        public void SaveUserProject(UserProjectInfo UserProjectInfo)
        {
            if (UserProjectInfo.ID == null)
            {
                new UserProjectDAL().Add(UserProjectInfo);
                return;
            }
            new UserProjectDAL().Update(UserProjectInfo);

        }

        public UserProjectInfo GetByID(string ID)
        {
            return new UserProjectDAL().GetByID(int.Parse(ID));
        }
        public List<UserProjectInfo> Query(int UserID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new UserProjectDAL().Query(UserID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}

