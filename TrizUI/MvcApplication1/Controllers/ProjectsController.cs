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
        // GET api/projects/5
        public ProjectInfo Get(string id)
        {
            return new ProjectLogic().GetByID(id);
        }

        // GET api/projects
        public object Get([FromUri]string Name, string Code, string Owner, string Department, string FromDate, string ToDate, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<ProjectInfo> ProjectInfoList = new ProjectLogic().Query(Name, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = ProjectInfoList
            };
        }

        // POST api/projects
        public void Post([FromBody]ProjectInfo ProjectInfo)
        {
            new ProjectLogic().SaveProject(ProjectInfo);
        }

        public void Put([FromBody]ProjectInfo ProjectInfo)
        {
            new ProjectLogic().SaveProject(ProjectInfo);
        }

        // DELETE api/projects/5
        public void Delete(int id)
        {
            new ProjectLogic().DeleteProject(id);
        }

        // DELETE api/projects/5
        public void Delete(string ids)
        {
            new ProjectLogic().DeleteProject(ids);
        }

    }
}
