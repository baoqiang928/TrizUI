﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class TrizDBEntities : DbContext
{
    public TrizDBEntities()
        : base("name=TrizDBEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<tbl_ProjectInfo> tbl_ProjectInfo { get; set; }

    public DbSet<tbl_UserProjectInfo> tbl_UserProjectInfo { get; set; }

    public DbSet<tbl_QuestionDescriptionInfo> tbl_QuestionDescriptionInfo { get; set; }

    public DbSet<tbl_UserInfo> tbl_UserInfo { get; set; }

    public DbSet<tbl_QuestionAnalyseInfo> tbl_QuestionAnalyseInfo { get; set; }

}

}

