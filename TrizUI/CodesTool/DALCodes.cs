using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesTool
{
    public class DALCodes
    {
        #region codes
        string codes = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Triz.Model;

namespace Triz.DAL
{
    public class {BusinessObjectInfo.ObjName}DAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""{BusinessObjectInfo.ObjName}Info""></param>
        /// <returns></returns>
        public bool Add({BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_{BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}InfoEntity = new tbl_{BusinessObjectInfo.ObjName}Info();
                    SetDataEntity({BusinessObjectInfo.ObjName}InfoEntity, {BusinessObjectInfo.ObjName}Info);
                    TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Add({BusinessObjectInfo.ObjName}InfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format(""{BusinessObjectInfo.ObjName},{1}"",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name=""{BusinessObjectInfo.ObjName}Info""></param>
        /// <returns></returns>
        public bool Update({BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Where(o => o.ID == {BusinessObjectInfo.ObjName}Info.ID).First();
                    if (Query == null) return false;
                    SetDataEntity(Query, {BusinessObjectInfo.ObjName}Info);
                    TrizDB.SaveChanges();
                    if (TrizDB.SaveChanges() > 0)
                        result = true;
                    return result;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format(""{0},{1}"",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name=""{BusinessObjectInfo.ObjName}Info""></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Where(o => o.ID == id).First();
                    if (Query == null) return 0;
                    TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Remove(Query);
                    return TrizDB.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format(""{0},{1}"",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return 0;
        }

        public {BusinessObjectInfo.ObjName}Info GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Where(o => o.ID == ID).First();
                    if (Query == null) return new {BusinessObjectInfo.ObjName}Info();
                    return GetBusinessObject(Query);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format(""{0},{1}"",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return new {BusinessObjectInfo.ObjName}Info();
        }

        public List<{BusinessObjectInfo.ObjName}Info> Query({QueryParamsDefine} int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_{BusinessObjectInfo.ObjName}Info, bool>> where = PredicateExtensionses.True<tbl_{BusinessObjectInfo.ObjName}Info>();
            {WhereStr}
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_{BusinessObjectInfo.ObjName}Info.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public {BusinessObjectInfo.ObjName}Info GetBusinessObject(tbl_{BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}InfoEntity)
        {
            {BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info = new {BusinessObjectInfo.ObjName}Info();
            {GetBusinessObject}

            return {BusinessObjectInfo.ObjName}Info;
        }

        public void SetDataEntity(tbl_{BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}InfoEntity, {BusinessObjectInfo.ObjName}Info {BusinessObjectInfo.ObjName}Info)
        {
             {SetDataEntity}
        }

        public List<{BusinessObjectInfo.ObjName}Info> GetGetBusinessObjectList(List<tbl_{BusinessObjectInfo.ObjName}Info> {BusinessObjectInfo.ObjName}InfoEntityList)
        {
            List<{BusinessObjectInfo.ObjName}Info> {BusinessObjectInfo.ObjName}InfoList = new List<{BusinessObjectInfo.ObjName}Info>();
            foreach (tbl_{BusinessObjectInfo.ObjName}Info tbl_{BusinessObjectInfo.ObjName}Info in {BusinessObjectInfo.ObjName}InfoEntityList)
            {
                {BusinessObjectInfo.ObjName}InfoList.Add(GetBusinessObject(tbl_{BusinessObjectInfo.ObjName}Info));
            }
            return {BusinessObjectInfo.ObjName}InfoList;
        }
    }
}


";
        #endregion

        public string Generate(List<BusinessObjectInfo> BusinessObjectInfoList)
        {
            string CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                if (BusinessObjectInfo.Name == "ID")
                {
                    CodeSection += @"
                                        if ({BusinessObjectInfo.ObjName}Info.ID != null)
                                            {BusinessObjectInfo.ObjName}InfoEntity.ID = {BusinessObjectInfo.ObjName}Info.ID ?? 0;
                    ";
                    continue;
                }
                CodeSection += @"
                                        if ({BusinessObjectInfo.ObjName}Info.{BusinessObjectInfo.Name} != null)
                                            {BusinessObjectInfo.ObjName}InfoEntity.{BusinessObjectInfo.Name} = {BusinessObjectInfo.ObjName}Info.{BusinessObjectInfo.Name};
                    ";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
            }
            codes = codes.Replace("{GetBusinessObject}", CodeSection);

            CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                CodeSection += @"
                                     {BusinessObjectInfo.ObjName}Info.{BusinessObjectInfo.Name} = {BusinessObjectInfo.ObjName}InfoEntity.{BusinessObjectInfo.Name};
                    ";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);
            }
            codes = codes.Replace("{SetDataEntity}", CodeSection);



            //query 参数
            CodeSection = "";
            string CodeSection1 = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName
                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Query)) continue;
                CodeSection += "string " + BusinessObjectInfo.Name + ",";
                CodeSection1 += BusinessObjectInfo.Name + ",";
            }
            //CodeSection = CodeSection.TrimEnd(',');
            //CodeSection1 = CodeSection1.TrimEnd(',');

            codes = codes.Replace("{QueryParamsDefine}", CodeSection);
            codes = codes.Replace("{QueryParams}", CodeSection1);

            //where 条件
                        CodeSection = "";
            foreach (BusinessObjectInfo BusinessObjectInfo in BusinessObjectInfoList)
            {
                //BusinessObjectInfo.Name
                //BusinessObjectInfo.ObjName

                if (string.IsNullOrWhiteSpace(BusinessObjectInfo.Query)) continue;
                CodeSection += @"
                    if (!string.IsNullOrWhiteSpace({BusinessObjectInfo.Name}))
                        where = where.And(a => a.{BusinessObjectInfo.Name}.Contains({BusinessObjectInfo.Name}));
                ";
                CodeSection = CodeSection.Replace("{BusinessObjectInfo.Name}", BusinessObjectInfo.Name);

            }

            codes = codes.Replace("{WhereStr}", CodeSection);

            codes = codes.Replace("{BusinessObjectInfo.ObjName}", BusinessObjectInfoList[0].ObjName);
            return codes;
        }

    }
}
