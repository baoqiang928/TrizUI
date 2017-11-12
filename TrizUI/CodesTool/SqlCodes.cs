using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class SqlCodes
    {
        #region codes
        string codes = @"USE [TrizDB]
GO

/****** Object:  Table [dbo].[tbl_{BusinessObjectInfo.ObjName}Info]    Script Date: 11/12/2017 17:06:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_{BusinessObjectInfo.ObjName}Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
{Fields}
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_{BusinessObjectInfo.ObjName}Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_{BusinessObjectInfo.ObjName}Info] ADD  CONSTRAINT [DF_tbl_{BusinessObjectInfo.ObjName}Info_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO

";

        #endregion

        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string tmpcodes = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                if (BusinessObjectInfo.Name == "ID") continue;
                string CodeSection = "";
                string fieldtype = "nvarchar";
                string isnull = "NULL";
                if (!string.IsNullOrWhiteSpace(BusinessObjectInfo.Mondantory))
                {
                    isnull = "NOT NULL";
                }
                if (BusinessObjectInfo.Type == "String")
                {
                    fieldtype = "nvarchar";
                }
                if (BusinessObjectInfo.Type == "DateTime")
                {
                    fieldtype = "datetime";
                }
                if (BusinessObjectInfo.Type == "Int")
                {
                    fieldtype = "int";
                }

                CodeSection = "[{BusinessObjectInfo.Name}] [{fieldtype}]({BusinessObjectInfo.Length}) {isnull},";

                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name).Replace("{fieldtype}", fieldtype).Replace("{isnull}", isnull);
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Length}",BusinessObjectInfo.Length);
                CodeSection = CodeSection.Replace("()", "");
                tmpcodes += CodeSection;
            }


            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName).Replace("{Fields}", tmpcodes);
            return codes;
        }

    }
}
