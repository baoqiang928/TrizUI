
//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace Triz.DAL
{

using System;
    using System.Collections.Generic;
    
public partial class tbl_QuestionDescriptionInfo
{

    public int ID { get; set; }

    public Nullable<int> ProjectID { get; set; }

    public string Note { get; set; }

    public string CustomerDes { get; set; }

    public string Environment { get; set; }

    public string InitialProblemDes { get; set; }

    public string RelativeDemand { get; set; }

    public string PotentialProblem { get; set; }

    public string GapOfPerformanceRequirment { get; set; }

    public System.DateTime CreateDateTime { get; set; }

}

}