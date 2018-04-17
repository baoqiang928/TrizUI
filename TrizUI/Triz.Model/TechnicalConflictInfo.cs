using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class TechnicalConflictInfo
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
        private string improveCharacter;
        /// <summary>
        /// 提高特性
        /// </summary>
        public string ImproveCharacter
        {
            get { return improveCharacter; }
            set { improveCharacter = value; }
        }
        private string deteriorateCharacter;
        /// <summary>
        /// 恶化特性
        /// </summary>
        public string DeteriorateCharacter
        {
            get { return deteriorateCharacter; }
            set { deteriorateCharacter = value; }
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


