using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class ModelCodes
    {
        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSectionList = "";
            string codes = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {

                string FirstLowerLetter = GetFirstLowerLetter(BusinessObjectInfo.Name);

                if (BusinessObjectInfo.Name == "ID")
                {
                    codes = @"
                                    private int? id;
                                    public int? ID
                                    {
                                        get { return id; }
                                        set { id = value; }
                                    }";
                    CodeSectionList += codes;
                }
                if (BusinessObjectInfo.Type == "DateTime")
                {
                    codes = @"
                                    private DateTime? {0};

                                    public DateTime? {1}
                                    {
                                        get { return {0}; }
                                        set { {0} = value; }
                                    }
                                    ";
                    codes = codes.Replace("{0}", FirstLowerLetter).Replace("{1}", BusinessObjectInfo.Name);
                    CodeSectionList += codes;
                }
                if (BusinessObjectInfo.Type == "String")
                {
                    codes = @"
                                    private string {0};
                                    public string {1}
                                    {
                                        get { return {0}; }
                                        set { {0} = value; }
                                    }";
                    codes = codes.Replace("{0}", FirstLowerLetter).Replace("{1}", BusinessObjectInfo.Name);
                    CodeSectionList += codes;
                }

            }
            codes = @"using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class {0}Info
    {
       {1}
    }
}

";
            codes = codes.Replace("{0}", BusinessObjectInfoList[0].ObjName).Replace("{1}", CodeSectionList);
            return codes;
        }

        private string GetFirstLowerLetter(string str)
        {
            return str = str.Substring(0, 1).ToLower() + str.Substring(1);
        }


    }
}
