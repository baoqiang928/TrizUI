using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class BusinessObjectInfo
    {
        private string objName;

        public string ObjName
        {
            get { return objName; }
            set { objName = value; }
        }

        private string name;
        /// <summary>
        /// 业务类属性名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;
        /// <summary>
        /// 属性中文描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string length;

        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        private string query;

        public string Query
        {
            get { return query; }
            set { query = value; }
        }
        private string list;

        public string List
        {
            get { return list; }
            set { list = value; }
        }
        private string operate;

        public string Operate
        {
            get { return operate; }
            set { operate = value; }
        }
        private string mondantory;

        public string Mondantory
        {
            get { return mondantory; }
            set { mondantory = value; }
        }

    }
}
