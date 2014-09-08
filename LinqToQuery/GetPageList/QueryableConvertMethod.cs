using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;

namespace LinqToQuery
{
    /// <summary>
    /// 轉換Queryable成為不同類型的查詢條件
    /// </summary>
    internal class QueryableConvertMethod
    {
        /// <summary>
        /// 轉換Queryable成為不同類型的查詢條件
        /// </summary>
        internal QueryableConvertMethod() { }

        /// <summary>
        /// 將Queryable實作分頁的方法
        /// </summary>
        private IDataPager DataPagerQueryable = new DataPagerQueryable();

        /// <summary>
        /// 將Query實作Where條件
        /// </summary>
        /// <typeparam name="TFilter">要篩選資料的資料表類別(ORM)</typeparam>
        /// <typeparam name="TQuery">查詢的Query資料表類別(ORM)</typeparam>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="Query">查詢的Query</param>
        /// <param name="FilterMethod">實作Where條件的方法</param>
        /// <returns>實作Where條件的Query</returns>
        protected internal IQueryable<TQuery> GetFilterQuery<TFilter, TQuery>(TFilter FilterData, IQueryable<TQuery> Query, Func<TFilter, IQueryable<TQuery>, IQueryable<TQuery>> FilterMethod)
        {
            return FilterData == null ? Query : FilterMethod(FilterData, Query);
        }

        /// <summary>
        /// 取得分頁及排序的List資料
        /// </summary>
        /// <typeparam name="TQuery">要轉換為List的Query資料表類別(ORM)</typeparam>
        /// <param name="Query">要轉換為List的Query</param>
        /// <param name="startRowIndex">分頁的起始資料列索引</param>
        /// <param name="maximumRows">分頁要取得的資料列數目</param>
        /// <param name="SortExpression">要排序的資料欄位</param>
        /// <returns>實作分頁及排序後的List</returns>
        protected internal List<TQuery> GetPagerAndOrderList<TQuery>(IQueryable<TQuery> Query, int startRowIndex, int maximumRows, string SortExpression)
        {
            //檢查是否需要排序
            IQueryable<TQuery> SortQuery = DataPagerQueryable.CheckSortExpression(Query, SortExpression);
            IQueryable<TQuery> PagerQuery = DataPagerQueryable.GetPagerQuery(SortQuery, startRowIndex, maximumRows);
            return PagerQuery.ToList();
        }
    }
}