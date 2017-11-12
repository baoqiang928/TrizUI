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
    public class ProjectsController : ApiController
    {
        // GET api/Projects/5
        public ProjectInfo Get(string id)
        {
            return new ProjectLogic().GetByID(id);
        }

        // GET api/Projects
        public object Get([FromUri]string Code, string Name, string Owner, string Department, string CreateDateTime, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ProjectInfo> ProjectInfoList = new ProjectLogic().Query(Code, Name, Owner, Department, CreateDateTime, currentPage, itemsPerPage, ref TotalItems, ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ProjectInfoList
            };
        }

        // POST api/Projects
        public void Post([FromBody]ProjectInfo ProjectInfo)
        {
            new ProjectLogic().SaveProject(ProjectInfo);
        }

        public void Put([FromBody]ProjectInfo ProjectInfo)
        {
            new ProjectLogic().SaveProject(ProjectInfo);
        }

        // DELETE api/Projects/5
        public void Delete(int id)
        {
            new ProjectLogic().DeleteProject(id);
        }

        // DELETE api/Projects/5
        public void Delete(string ids)
        {
            new ProjectLogic().DeleteProject(ids);
        }

    }
}

