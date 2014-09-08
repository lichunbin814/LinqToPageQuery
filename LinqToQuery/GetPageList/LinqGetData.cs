using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;

namespace Tw.Com.Hamastar.LinqToQuery
{
    /// <summary>
    /// 使用Linq取得資料
    /// </summary>
    /// <typeparam name="TSource">由ORM將資料表轉換的Class</typeparam>
    /// <typeparam name="TContext">實作IDisposeable的Context類型</typeparam>
    public class LinqGetData<TSource, TContext>
        where TSource : class
        where TContext : class, IDisposable
    {
        /// <summary>
        /// Context容器
        /// </summary>
        protected TContext Context
        {
            get
            { return Activator.CreateInstance(typeof(TContext)) as TContext; }
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="query">要轉為SQL的Query</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount()
        {
            using (Context)
            {
                return query.Count();
            }
        }

        #region 取得資料

        private IDataPager DataPagerQueryable = new DataPagerQueryable();

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TSource> GetData(int startRowIndex, int maximumRows, string SortExpression)
        {
            using (Context)
            {
                return GetList(query, startRowIndex, maximumRows, SortExpression);
            }
        }

        public List<TQuery> GetList<TQuery>(IQueryable<TQuery> Query, int startRowIndex, int maximumRows, string SortExpression)
        {
            //檢查是否需要排序
            IQueryable<TQuery> SortQuery = DataPagerQueryable.CheckSortExpression(Query, SortExpression);
            IQueryable<TQuery> PagerQuery = DataPagerQueryable.GetPagerQuery(SortQuery, startRowIndex, maximumRows);
            return PagerQuery.ToList();
        }

        #endregion 取得資料

        #region 依照TSource自動建立IQueryable

        private IQueryable<TSource> _query = null;

        public IQueryable<TSource> query
        {
            get
            {
                return _query = _query ?? GenerateQuery(Context);
            }
        }

        private IQueryable<TSource> GenerateQuery(TContext Context)
        {

            Type ContextType = Context.GetType().BaseType;
            if (ContextType == typeof(ObjectContext))
            {
                return (Context as ObjectContext).CreateQuery<TSource>(typeof(TSource).Name);
            }
            else if (ContextType == typeof(DataContext))
            {
                return (Context as DataContext).GetTable<TSource>();
            }

            throw new Exception("未知的Context型別");
        }

        #endregion 依照TSource自動建立IQueryable
    }
}