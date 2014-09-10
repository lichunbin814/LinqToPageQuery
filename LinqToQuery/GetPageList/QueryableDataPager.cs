using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;

namespace LinqToQuery
{
    /// <summary>
    /// 將Queryable實作分頁的方法
    /// </summary>
    internal class DataPagerQueryable : IDataPager
    {
        /// <summary>
        /// 取得Sort的Query
        /// </summary>
        /// <param name="query">要轉為SQL的Query</param>
        /// <param name="SortExpression">要排序的欄位</param>
        /// <returns>加入OrderBy的Query</returns>
        private IQueryable<TSort> GetSortQuery<TSort>(IQueryable<TSort> query, string SortExpression)
        {
            //依SortExporession排序
            return query.OrderBy(SortExpression);
        }

        /// <summary>
        /// 取得分頁的查詢Query
        /// </summary>
        /// <param name="query">要加入分頁的Query</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">>要取得的資料筆數</param>
        /// <returns>加上分頁的Query</returns>
        public IQueryable<TPage> GetPagerQuery<TPage>(IQueryable<TPage> query, int startRowIndex, int maximumRows)
        {
            return query.Skip(startRowIndex).Take(maximumRows);
        }

        IDataMapping DataMap = new DataMappingMethod();

        /// <summary>
        /// 由query的上層找Mapping的Class並取得主鍵名稱或第一個欄位的名稱
        /// </summary>
        /// <param name="query">要反查的query</param>
        /// <returns>主鍵或第一個欄位的名稱</returns>
        private string GetPrimaryOrFirstKey<TQuery>(IQueryable<TQuery> query)
        {
            //取得query資料表的所有屬性
            PropertyInfo[] ProInfos = query.ElementType.GetProperties();
            return DataMap.GetPrimaryKey(ProInfos) ?? ProInfos[0].Name;
        }

        /// <summary>
        /// 取得排序Query(若為空值，預設使用主鍵由大至小排序)
        /// </summary>
        /// <param name="query">要加入排序的Query</param>
        /// <param name="SortExpression">排序的語法</param>
        /// <returns>加上排序的Query</returns>
        public IQueryable<TSort> CheckSortExpression<TSort>(IQueryable<TSort> query, string SortExpression)
        {
            SortExpression = SortExpression == "" ? string.Format("{0} Desc", GetPrimaryOrFirstKey(query)) : SortExpression;
            return GetSortQuery(query, SortExpression);
        }
    }
}