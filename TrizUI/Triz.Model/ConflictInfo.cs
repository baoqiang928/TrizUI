using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class ConflictInfo
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
        private string relComponentName;
        /// <summary>
        /// 元件特征参数
        /// </summary>
        public string RelComponentName
        {
            get { return relComponentName; }
            set { relComponentName = value; }
        }
        private string relComponentParamName;
        /// <summary>
        /// 影响该参数元件
        /// </summary>
        public string RelComponentParamName
        {
            get { return relComponentParamName; }
            set { relComponentParamName = value; }
        }
        private string currentConfig;
        /// <summary>
        /// 参数名称
        /// </summary>
        public string CurrentConfig
        {
            get { return currentConfig; }
            set { currentConfig = value; }
        }
        private string changeConfig;
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ChangeConfig
        {
            get { return changeConfig; }
            set { changeConfig = value; }
        }
        private string currentProblem;
        /// <summary>
        /// 目前问题
        /// </summary>
        public string CurrentProblem
        {
            get { return currentProblem; }
            set { currentProblem = value; }
        }
        private string newProblem;
        /// <summary>
        /// 新的问题
        /// </summary>
        public string NewProblem
        {
            get { return newProblem; }
            set { newProblem = value; }
        }
        private string visible;
        /// <summary>
        /// 是否可见
        /// </summary>
        public string Visible
        {
            get { return visible; }
            set { visible = value; }
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


