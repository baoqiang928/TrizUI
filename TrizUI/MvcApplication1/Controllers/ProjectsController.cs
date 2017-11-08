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
        // GET api/projects
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/projects/5
        //public List<ProjectInfo> Get([FromUri]string Name, string Code, string Owner, string Department, string FromDate, string ToDate, int currentPage, int itemsPerPage)
        //{
        //    return new ProjectLogic().Query(Name, currentPage, itemsPerPage);
        //}

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




        //public List<ProjectInfo> Get([FromUri]string Name, int currentPage, int itemsPerPage)
        //{
        //    return new ProjectLogic().Query(Name, currentPage, itemsPerPage);
        //}

        // POST api/projects
        public void Post([FromBody]ProjectInfo ProjectInfo)
        {
            new ProjectLogic().AddProject(ProjectInfo.Name);
        }

        // PUT api/projects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/projects/5
        public void Delete(int id)
        {
        }
    }
}
