using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Triz.Model
{
    public class FunEleMutualReactInfo
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
                                    private int? positiveEleID;
                                    public int? PositiveEleID
                                    {
                                        get { return positiveEleID; }
                                        set { positiveEleID = value; }
                                    }
                                    private string positiveEleName;
                                    /// <summary>
                                    /// 主动元件
                                    /// </summary>
                                    public string PositiveEleName
                                    {
                                        get { return positiveEleName; }
                                        set { positiveEleName = value; }
                                    }
                                    private string functionName;
                                    /// <summary>
                                    /// 作用
                                    /// </summary>
                                    public string FunctionName
                                    {
                                        get { return functionName; }
                                        set { functionName = value; }
                                    }
                                    private int? passiveEleID;
                                    public int? PassiveEleID
                                    {
                                        get { return passiveEleID; }
                                        set { passiveEleID = value; }
                                    }
                                    private string passiveEleName;
                                    /// <summary>
                                    /// 被动元件
                                    /// </summary>
                                    public string PassiveEleName
                                    {
                                        get { return passiveEleName; }
                                        set { passiveEleName = value; }
                                    }
                                    private string functionType;
                                    /// <summary>
                                    /// 功能类型
                                    /// </summary>
                                    public string FunctionType
                                    {
                                        get { return functionType; }
                                        set { functionType = value; }
                                    }
                                    private string functionGrade;
                                    /// <summary>
                                    /// 功能等级
                                    /// </summary>
                                    public string FunctionGrade
                                    {
                                        get { return functionGrade; }
                                        set { functionGrade = value; }
                                    }
                                    private string elementType;
                                    /// <summary>
                                    /// 元件类型
                                    /// </summary>
                                    public string ElementType
                                    {
                                        get { return elementType; }
                                        set { elementType = value; }
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


