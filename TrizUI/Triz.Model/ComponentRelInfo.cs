using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class ComponentRelInfo
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
        private int sectionID;
        public int SectionID
        {
            get { return sectionID; }
            set { sectionID = value; }
        }
        private string componentParamName;
        /// <summary>
        /// 元件特征参数
        /// </summary>
        public string ComponentParamName
        {
            get { return componentParamName; }
            set { componentParamName = value; }
        }
        private string impactComponentName;
        /// <summary>
        /// 影响该参数元件
        /// </summary>
        public string ImpactComponentName
        {
            get { return impactComponentName; }
            set { impactComponentName = value; }
        }
        private string impactParamName;
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ImpactParamName
        {
            get { return impactParamName; }
            set { impactParamName = value; }
        }
        private string paramType;
        /// <summary>
        /// 参数类型
        /// </summary>
        public string ParamType
        {
            get { return paramType; }
            set { paramType = value; }
        }
        private string disabled;
        /// <summary>
        /// Disabled
        /// </summary>
        public string Disabled
        {
            get { return disabled; }
            set { disabled = value == null ? null : value.ToLower(); }
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


