using System;
using System.Collections.Generic;
using Triz.DAL;
using Triz.Model;

namespace Triz.BLL
{
    public class MaterialFieldModelLogic
    {
        public void DeleteMaterialFieldModel(int id)
        {
            new MaterialFieldModelDAL().Delete(id);
        }

        public void DeleteMaterialFieldModel(string ids)
        {
            foreach (string id in ids.Split('^'))
            {
                if (string.IsNullOrWhiteSpace(id)) continue;
                new MaterialFieldModelDAL().Delete(int.Parse(id));
            }
        }

        public void SaveMaterialFieldModel(MaterialFieldModelInfo MaterialFieldModelInfo)
        {
            if (MaterialFieldModelInfo.ID == null)
            {
                new MaterialFieldModelDAL().Add(MaterialFieldModelInfo);
                return;
            }
            new MaterialFieldModelDAL().Update(MaterialFieldModelInfo);

        }

        public MaterialFieldModelInfo GetByID(string ID)
        {
           return new MaterialFieldModelDAL().GetByID(int.Parse(ID));
        }
        public List<MaterialFieldModelInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            return new MaterialFieldModelDAL().Query(ProjectID, pageIndex, pageSize, ref totalItems, ref PagesLength);
        }
    }
}


