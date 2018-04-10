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
        /// 目前问题
        /// </summary>
        public string ProblemDescription
        {
            get { return problemDescription; }
            set { problemDescription = value; }
        }

        private string altinativeProblem;
        /// <summary>
        /// 系统改进的替代问题
        /// </summary>
        public string AltinativeProblem
        {
            get { return altinativeProblem; }
            set { altinativeProblem = value; }
        }

        private string techConflict;
        /// <summary>
        /// 系统改进的技术冲突
        /// </summary>
        public string TechConflict
        {
            get { return techConflict; }
            set { techConflict = value; }
        }

        private string phyConflict;
        /// <summary>
        /// 系统改进的物理冲突
        /// </summary>
        public string PhyConflict
        {
            get { return phyConflict; }
            set { phyConflict = value; }
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


