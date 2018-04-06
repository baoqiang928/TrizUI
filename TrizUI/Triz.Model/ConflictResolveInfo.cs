using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class ConflictResolveInfo
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
                                    private string conflictType;
                                    /// <summary>
                                    /// 冲突类型(技术or物理)
                                    /// </summary>
                                    public string ConflictType
                                    {
                                        get { return conflictType; }
                                        set { conflictType = value; }
                                    }
                                    private int conflictID;
                                    public int ConflictID
                                    {
                                        get { return conflictID; }
                                        set { conflictID = value; }
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
                                    private string devidePrincipleID;
                                    /// <summary>
                                    /// 分离原理ID
                                    /// </summary>
                                    public string DevidePrincipleID
                                    {
                                        get { return devidePrincipleID; }
                                        set { devidePrincipleID = value; }
                                    }
                                    private string devidePrincipleName;
                                    /// <summary>
                                    /// 分离原理名称
                                    /// </summary>
                                    public string DevidePrincipleName
                                    {
                                        get { return devidePrincipleName; }
                                        set { devidePrincipleName = value; }
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


