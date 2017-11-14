using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class BusObjManager
    {
        public List<BusinessObjectInfo> Get(string[] srcs)
        {
            List<BusinessObjectInfo>  objectList = new List<BusinessObjectInfo>();

            string objname = srcs[0].Split('	')[0];
            string objdesc = srcs[0].Split('	')[1];



            for (int i = 1; i < srcs.Length; i++)
            {
                string src = srcs[i];
                string[] s = src.Split('	');
                if (s.Length < 7) continue;
                
                BusinessObjectInfo BusinessObjectInfo = new BusinessObjectInfo();
                BusinessObjectInfo.ObjName = objname;
                BusinessObjectInfo.ObjDes = objdesc;
                BusinessObjectInfo.Name = s[0];
                BusinessObjectInfo.Description = s[1];
                BusinessObjectInfo.Type = s[2];
                BusinessObjectInfo.Length = s[3];
                BusinessObjectInfo.Query = s[4];
                BusinessObjectInfo.List = s[5];
                BusinessObjectInfo.Operate = s[6];
                BusinessObjectInfo.Mondantory = s[7];
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Name)) continue;
                objectList.Add(BusinessObjectInfo);
            }
            return objectList;
        }
    }
}
