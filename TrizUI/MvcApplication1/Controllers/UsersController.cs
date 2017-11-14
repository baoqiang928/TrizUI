using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/Users/5
        public UserInfo Get(string id)
        {
            return new UserLogic().GetByID(id);
        }

        // GET api/Users
        public object Get([FromUri]string Name,string Mobile,string Email,string Account, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<UserInfo> UserInfoList = new UserLogic().Query(Name,Mobile,Email,Account, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = UserInfoList
            };
        }

        // POST api/Users
        public void Post([FromBody]UserInfo UserInfo)
        {
            new UserLogic().SaveUser(UserInfo);
        }

        public void Put([FromBody]UserInfo UserInfo)
        {
            new UserLogic().SaveUser(UserInfo);
        }

        // DELETE api/Users/5
        public void Delete(int id)
        {
            new UserLogic().DeleteUser(id);
        }

        // DELETE api/Users/5
        public void Delete(string ids)
        {
            new UserLogic().DeleteUser(ids);
        }

    }
}


