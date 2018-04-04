using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class MaterialFieldModelInfo
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
                                    private string functionSubject;
                                    /// <summary>
                                    /// 功能主体
                                    /// </summary>
                                    public string FunctionSubject
                                    {
                                        get { return functionSubject; }
                                        set { functionSubject = value; }
                                    }
                                    private string functionObject;
                                    /// <summary>
                                    /// 功能客体
                                    /// </summary>
                                    public string FunctionObject
                                    {
                                        get { return functionObject; }
                                        set { functionObject = value; }
                                    }
                                    private string relationType;
                                    /// <summary>
                                    /// 作用类型
                                    /// </summary>
                                    public string RelationType
                                    {
                                        get { return relationType; }
                                        set { relationType = value; }
                                    }
                                    private string fieldName;
                                    /// <summary>
                                    /// 场
                                    /// </summary>
                                    public string FieldName
                                    {
                                        get { return fieldName; }
                                        set { fieldName = value; }
                                    }
                                    private string fieldType;
                                    /// <summary>
                                    /// 场类型
                                    /// </summary>
                                    public string FieldType
                                    {
                                        get { return fieldType; }
                                        set { fieldType = value; }
                                    }
                                    private string symbol;
                                    /// <summary>
                                    /// 符号
                                    /// </summary>
                                    public string Symbol
                                    {
                                        get { return symbol; }
                                        set { symbol = value; }
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


