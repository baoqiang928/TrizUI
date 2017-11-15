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
    public class UserProjectsController : ApiController
    {
        // GET api/UserProjects/5
        public UserProjectInfo Get(string id)
        {
            return new UserProjectLogic().GetByID(id);
        }

        // GET api/UserProjects
        public object Get([FromUri]int UserID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<UserProjectInfo> UserProjectInfoList = new UserProjectLogic().Query(UserID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = UserProjectInfoList
            };
        }

        // POST api/UserProjects
        public void Post([FromBody]UserProjectInfo UserProjectInfo)
        {
            new UserProjectLogic().SaveUserProject(UserProjectInfo);
        }

        public void Put([FromBody]UserProjectInfo UserProjectInfo)
        {
            new UserProjectLogic().SaveUserProject(UserProjectInfo);
        }

        // DELETE api/UserProjects/5
        public void Delete(int id)
        {
            new UserProjectLogic().DeleteUserProject(id);
        }

        // DELETE api/UserProjects/5
        public void Delete(string ids)
        {
            new UserProjectLogic().DeleteUserProject(ids);
        }

    }
}


