using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class QuestionDescriptionInfo
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
        private string note;
        /// <summary>
        /// 问题描述
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        private string customerDes;
        /// <summary>
        /// 目标客户（群）
        /// </summary>
        public string CustomerDes
        {
            get { return customerDes; }
            set { customerDes = value; }
        }
        private string environment;
        /// <summary>
        /// 系统所处环境
        /// </summary>
        public string Environment
        {
            get { return environment; }
            set { environment = value; }
        }
        private string initialProblemDes;
        /// <summary>
        /// 初始问题
        /// </summary>
        public string InitialProblemDes
        {
            get { return initialProblemDes; }
            set { initialProblemDes = value; }
        }
        private string relativeDemand;
        /// <summary>
        /// 系统相关要求
        /// </summary>
        public string RelativeDemand
        {
            get { return relativeDemand; }
            set { relativeDemand = value; }
        }
        private string potentialProblem;
        /// <summary>
        /// 隐性问题
        /// </summary>
        public string PotentialProblem
        {
            get { return potentialProblem; }
            set { potentialProblem = value; }
        }
        private string gapOfPerformanceRequirment;
        /// <summary>
        /// 性能与需求的差距
        /// </summary>
        public string GapOfPerformanceRequirment
        {
            get { return gapOfPerformanceRequirment; }
            set { gapOfPerformanceRequirment = value; }
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


