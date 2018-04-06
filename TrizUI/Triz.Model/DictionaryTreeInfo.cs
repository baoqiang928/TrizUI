using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class DictionaryTreeInfo
    {
        int? id;
        /// <summary>
        /// ID
        /// </summary>
        public int? ID
        {
            get { return id; }
            set { id = value; }
        }
        private int projectID;
        public int ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private int treeTypeID;
        public int TreeTypeID
        {
            get { return treeTypeID; }
            set { treeTypeID = value; }
        }
        private int serialNum;
        public int SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; }
        }
        private string name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string note;
        /// <summary>
        /// 内容
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private int? fatherID;
        public int? FatherID
        {
            get { return fatherID; }
            set { fatherID = value; }
        }
        private DateTime? createDateTime;
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime? CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }

    }
}


