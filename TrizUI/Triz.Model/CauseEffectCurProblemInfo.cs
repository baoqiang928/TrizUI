using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class CauseEffectCurProblemInfo
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
        private string problemDescription;
        /// <summary>
        /// 元件特征参数
        /// </summary>
        public string ProblemDescription
        {
            get { return problemDescription; }
            set { problemDescription = value; }
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


