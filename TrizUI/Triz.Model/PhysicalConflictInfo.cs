using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class PhysicalConflictInfo
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
        private int? serialNum;
        public int? SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; }
        }
        private string forwardCharacter;
        /// <summary>
        /// 正向特性
        /// </summary>
        public string ForwardCharacter
        {
            get { return forwardCharacter; }
            set { forwardCharacter = value; }
        }
        private string backwardCharacter;
        /// <summary>
        /// 反向特性
        /// </summary>
        public string BackwardCharacter
        {
            get { return backwardCharacter; }
            set { backwardCharacter = value; }
        }
        private string commonRelevantParams;
        /// <summary>
        /// 共同相关参数
        /// </summary>
        public string CommonRelevantParams
        {
            get { return commonRelevantParams; }
            set { commonRelevantParams = value; }
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


