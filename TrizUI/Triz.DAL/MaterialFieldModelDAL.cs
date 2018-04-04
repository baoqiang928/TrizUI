using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Triz.Model;

namespace Triz.DAL
{
    public class MaterialFieldModelDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="MaterialFieldModelInfo"></param>
        /// <returns></returns>
        public int Add(MaterialFieldModelInfo MaterialFieldModelInfo)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    tbl_MaterialFieldModelInfo MaterialFieldModelInfoEntity = new tbl_MaterialFieldModelInfo();
                    SetDataEntity(MaterialFieldModelInfoEntity, MaterialFieldModelInfo);
                    TrizDB.tbl_MaterialFieldModelInfo.Add(MaterialFieldModelInfoEntity);
                    if (TrizDB.SaveChanges() > 0)
                        return MaterialFieldModelInfoEntity.ID;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("MaterialFieldModel,{1}",
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

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="MaterialFieldModelInfo"></param>
        /// <returns></returns>
        public bool Update(MaterialFieldModelInfo MaterialFieldModelInfo)
        {
            bool result = false;
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_MaterialFieldModelInfo.Where(o => o.ID == MaterialFieldModelInfo.ID).FirstOrDefault();
                    if (Query == null) return false;
                    SetDataEntity(Query, MaterialFieldModelInfo);
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
                            string message = string.Format("{0},{1}",
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
        /// <param name="MaterialFieldModelInfo"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_MaterialFieldModelInfo.Where(o => o.ID == id).FirstOrDefault();
                    if (Query == null) return 0;
                    TrizDB.tbl_MaterialFieldModelInfo.Remove(Query);
                    return TrizDB.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0},{1}",
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

        public MaterialFieldModelInfo GetByID(int ID)
        {
            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                try
                {
                    var Query = TrizDB.tbl_MaterialFieldModelInfo.Where(o => o.ID == ID).FirstOrDefault();
                    if (Query == null) return new MaterialFieldModelInfo();
                    return GetBusinessObject(Query);
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0},{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                            throw raise;
                        }
                    }
                }
            }
            return new MaterialFieldModelInfo();
        }

        public List<MaterialFieldModelInfo> Query(string ProjectID, int pageIndex, int pageSize, ref int totalItems, ref int PagesLength)
        {
            int startRow = (pageIndex - 1) * pageSize;
            Expression<Func<tbl_MaterialFieldModelInfo, bool>> where = PredicateExtensionses.True<tbl_MaterialFieldModelInfo>();

            if (!string.IsNullOrWhiteSpace(ProjectID))
                where = where.And(a => a.ProjectID==int.Parse(ProjectID));

            using (TrizDBEntities TrizDB = new TrizDBEntities())
            {
                var query = TrizDB.tbl_MaterialFieldModelInfo.Where(where.Compile());
                totalItems = query.Count();
                PagesLength = (int)Math.Ceiling((double)totalItems / pageSize);
                query = query.OrderByDescending(p => p.ID).Skip(startRow).Take(pageSize);
                return GetGetBusinessObjectList(query.ToList());
            }
        }

        public MaterialFieldModelInfo GetBusinessObject(tbl_MaterialFieldModelInfo MaterialFieldModelInfoEntity)
        {
            MaterialFieldModelInfo MaterialFieldModelInfo = new MaterialFieldModelInfo();

            MaterialFieldModelInfo.ID = MaterialFieldModelInfoEntity.ID;

            MaterialFieldModelInfo.ProjectID = MaterialFieldModelInfoEntity.ProjectID;

            MaterialFieldModelInfo.SerialNum = MaterialFieldModelInfoEntity.SerialNum;

            MaterialFieldModelInfo.FunctionSubject = MaterialFieldModelInfoEntity.FunctionSubject;

            MaterialFieldModelInfo.FunctionObject = MaterialFieldModelInfoEntity.FunctionObject;

            MaterialFieldModelInfo.RelationType = MaterialFieldModelInfoEntity.RelationType;

            MaterialFieldModelInfo.FieldName = MaterialFieldModelInfoEntity.FieldName;

            MaterialFieldModelInfo.FieldType = MaterialFieldModelInfoEntity.FieldType;

            MaterialFieldModelInfo.Symbol = MaterialFieldModelInfoEntity.Symbol;

            MaterialFieldModelInfo.Remark = MaterialFieldModelInfoEntity.Remark;

            MaterialFieldModelInfo.CreateDateTime = MaterialFieldModelInfoEntity.CreateDateTime;


            return MaterialFieldModelInfo;
        }

        public void SetDataEntity(tbl_MaterialFieldModelInfo MaterialFieldModelInfoEntity, MaterialFieldModelInfo MaterialFieldModelInfo)
        {

            if (MaterialFieldModelInfo.ID != null)
                MaterialFieldModelInfoEntity.ID = MaterialFieldModelInfo.ID ?? 0;

            if (MaterialFieldModelInfo.ProjectID != null)
                MaterialFieldModelInfoEntity.ProjectID = MaterialFieldModelInfo.ProjectID;

            if (MaterialFieldModelInfo.SerialNum != null)
                MaterialFieldModelInfoEntity.SerialNum = MaterialFieldModelInfo.SerialNum;

            if (MaterialFieldModelInfo.FunctionSubject != null)
                MaterialFieldModelInfoEntity.FunctionSubject = MaterialFieldModelInfo.FunctionSubject;

            if (MaterialFieldModelInfo.FunctionObject != null)
                MaterialFieldModelInfoEntity.FunctionObject = MaterialFieldModelInfo.FunctionObject;

            if (MaterialFieldModelInfo.RelationType != null)
                MaterialFieldModelInfoEntity.RelationType = MaterialFieldModelInfo.RelationType;

            if (MaterialFieldModelInfo.FieldName != null)
                MaterialFieldModelInfoEntity.FieldName = MaterialFieldModelInfo.FieldName;

            if (MaterialFieldModelInfo.FieldType != null)
                MaterialFieldModelInfoEntity.FieldType = MaterialFieldModelInfo.FieldType;

            if (MaterialFieldModelInfo.Symbol != null)
                MaterialFieldModelInfoEntity.Symbol = MaterialFieldModelInfo.Symbol;

            if (MaterialFieldModelInfo.Remark != null)
                MaterialFieldModelInfoEntity.Remark = MaterialFieldModelInfo.Remark;

        }

        public List<MaterialFieldModelInfo> GetGetBusinessObjectList(List<tbl_MaterialFieldModelInfo> MaterialFieldModelInfoEntityList)
        {
            List<MaterialFieldModelInfo> MaterialFieldModelInfoList = new List<MaterialFieldModelInfo>();
            foreach (tbl_MaterialFieldModelInfo tbl_MaterialFieldModelInfo in MaterialFieldModelInfoEntityList)
            {
                MaterialFieldModelInfoList.Add(GetBusinessObject(tbl_MaterialFieldModelInfo));
            }
            return MaterialFieldModelInfoList;
        }
    }
}



