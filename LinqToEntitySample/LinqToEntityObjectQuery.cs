using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericSelect;
using LinqToEntitySample.DAL;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace LinqToEntitySample
{
    public class LinqToEntityGV<T> : AbsGridViewMehtod<T, DbContext> where T : class
    {       
        protected LinqToEntityGV() { }

        protected LinqToEntityGV(DbContext DbContext) : base(DbContext) { }

        #region 取得資料表名稱
        private ObjectContext _objectContext = null;

        /// <summary>
        /// 容器名稱
        /// </summary>
        protected internal string DefaultContainerName
        {
            get
            {
                return Context == null ? "it" : objectContext.DefaultContainerName;
            }
            set
            {
                objectContext.DefaultContainerName = value;
            }
        }
        protected internal ObjectContext objectContext
        {
            get
            {
                return _objectContext == null ? ((IObjectContextAdapter)this.Context).ObjectContext : _objectContext;
            }
            set { _objectContext = value; }
        }
        #endregion        

        protected override List<T> GetList(IQueryable<T> query, int StartIndex, int PageSize, string SortExpression = "")
        {
            //檢查是否需要排序           
            return GetPagerCommand(Sort(query, SortExpression), StartIndex, PageSize).ToList();
        }       

        protected override string GetPrimaryKey(IQueryable<T> query)
        {
            return ((ObjectQuery)query).Context.CreateObjectSet<T>().EntitySet.ElementType.KeyMembers[0].Name;
        }
    }
}
