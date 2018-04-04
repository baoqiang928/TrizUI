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
    public class MaterialFieldModelsController : ApiController
    {
        // GET api/MaterialFieldModels/5
        public MaterialFieldModelInfo Get(string id)
        {
            return new MaterialFieldModelLogic().GetByID(id);
        }

        // GET api/MaterialFieldModels
        public object Get([FromUri]string ProjectID, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<MaterialFieldModelInfo> MaterialFieldModelInfoList = new MaterialFieldModelLogic().Query(ProjectID, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = MaterialFieldModelInfoList
            };
        }

        // POST api/MaterialFieldModels
        public void Post([FromBody]MaterialFieldModelInfo MaterialFieldModelInfo)
        {
            new MaterialFieldModelLogic().SaveMaterialFieldModel(MaterialFieldModelInfo);
        }

        public void Put([FromBody]MaterialFieldModelInfo MaterialFieldModelInfo)
        {
            new MaterialFieldModelLogic().SaveMaterialFieldModel(MaterialFieldModelInfo);
        }

        // DELETE api/MaterialFieldModels/5
        public void Delete(int id)
        {
            new MaterialFieldModelLogic().DeleteMaterialFieldModel(id);
        }

        // DELETE api/MaterialFieldModels/5
        public void Delete(string ids)
        {
            new MaterialFieldModelLogic().DeleteMaterialFieldModel(ids);
        }

    }
}


