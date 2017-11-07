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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/projects/5
        public List<ProjectInfo> Get(string name, int pageIndex, int pageSize)
        {
            return new ProjectLogic().Query(name, pageIndex, pageSize);
        }

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
