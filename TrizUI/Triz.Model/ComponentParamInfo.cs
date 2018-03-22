using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class ComponentParamInfo
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
                                    private string componentName;
                                    /// <summary>
                                    /// 元件特征参数
                                    /// </summary>
                                    public string ComponentName
                                    {
                                        get { return componentName; }
                                        set { componentName = value; }
                                    }
                                    private string paramName;
                                    /// <summary>
                                    /// 参数名称
                                    /// </summary>
                                    public string ParamName
                                    {
                                        get { return paramName; }
                                        set { paramName = value; }
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
                                        set { disabled = value; }
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


