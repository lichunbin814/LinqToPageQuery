using System.Linq;

namespace LinqToQuery
{
    /// <summary>
    /// 將Queryable實作分頁的方法
    /// </summary>
    internal interface IDataPager
    {
        /// <summary>
        /// 取得分頁的查詢Query
        /// </summary>
        /// <param name="query">要加入分頁的Query</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">>要取得的資料筆數</param>
        /// <returns>加上分頁的Query</returns>
        IQueryable<TPage> GetPagerQuery<TPage>(IQueryable<TPage> query, int startRowIndex, int maximumRows);

        /// <summary>
        /// 取得排序Query(若為空值，預設使用主鍵由大至小排序)
        /// </summary>
        /// <param name="query">要加入排序的Query</param>
        /// <param name="SortExpression">排序的語法</param>
        /// <returns>加上排序的Query</returns>
        IQueryable<TSort> CheckSortExpression<TSort>(IQueryable<TSort> query, string SortExpression);
    }
}