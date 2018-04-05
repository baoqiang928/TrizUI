using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class AnalysisProcedureInfo
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
        private int serialNum;
        public int SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; }
        }
        private string procedureID;
        public string ProcedureID
        {
            get { return procedureID; }
            set { procedureID = value; }
        }
        private string templateName;
        /// <summary>
        /// 控件模板名称
        /// </summary>
        public string TemplateName
        {
            get { return templateName; }
            set { templateName = value; }
        }
        private string displayName;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        private string code;
        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        private string radioValue;
        /// <summary>
        /// 判断条件选项值
        /// </summary>
        public string RadioValue
        {
            get { return radioValue; }
            set { radioValue = value; }
        }
        private string inputValue;
        /// <summary>
        /// 标准解输入框输入值
        /// </summary>
        public string InputValue
        {
            get { return inputValue; }
            set { inputValue = value; }
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


