using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class FunctionElementInfo
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
        private int? projectID;
        public int? ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
        private string eleName;
        /// <summary>
        /// 元件名称
        /// </summary>
        public string EleName
        {
            get { return eleName; }
            set { eleName = value; }
        }
        private string elementType;
        /// <summary>
        /// 元件类型
        /// </summary>
        public string ElementType
        {
            get { return elementType; }
            set { elementType = value; }
        }
        private string eleX;
        /// <summary>
        /// 元件X坐标
        /// </summary>
        public string EleX
        {
            get { return eleX; }
            set { eleX = value; }
        }
        private string eleY;
        /// <summary>
        /// 元件Y坐标
        /// </summary>
        public string EleY
        {
            get { return eleY; }
            set { eleY = value; }
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


