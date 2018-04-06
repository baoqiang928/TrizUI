using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class TechnicalConflictResolveInfo
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
                                    private int technicalConflictID;
                                    public int TechnicalConflictID
                                    {
                                        get { return technicalConflictID; }
                                        set { technicalConflictID = value; }
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
                                    private string inventivePrincipleID;
                                    /// <summary>
                                    /// 发明原理ID
                                    /// </summary>
                                    public string InventivePrincipleID
                                    {
                                        get { return inventivePrincipleID; }
                                        set { inventivePrincipleID = value; }
                                    }
                                    private string inventivePrincipleName;
                                    /// <summary>
                                    /// 发明原理名称
                                    /// </summary>
                                    public string InventivePrincipleName
                                    {
                                        get { return inventivePrincipleName; }
                                        set { inventivePrincipleName = value; }
                                    }
                                    private string caseID;
                                    /// <summary>
                                    /// 案例代码ID
                                    /// </summary>
                                    public string CaseID
                                    {
                                        get { return caseID; }
                                        set { caseID = value; }
                                    }
                                    private string caseName;
                                    /// <summary>
                                    /// 案例代码名称
                                    /// </summary>
                                    public string CaseName
                                    {
                                        get { return caseName; }
                                        set { caseName = value; }
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


