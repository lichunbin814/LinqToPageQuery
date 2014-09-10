using System.Collections.Generic;

namespace LinqToQuery
{
    /// <summary>
    /// DataSource的查詢資料方法
    /// </summary>
    /// <typeparam name="TSource">資料表類別(ORM)</typeparam>
    internal interface IDataSourceSelect<TSource>
     where TSource : class
    {
        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        List<TSource> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression);

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        List<TSource> GetData(int startRowIndex, int maximumRows, string SortExpression);

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        int GetDataCount(TSource FilterData);

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        int GetDataCount();
    }

    /// <summary>
    /// DataSource的查詢資料方法
    /// </summary>
    /// <typeparam name="TSource">資料表類別(ORM)</typeparam>
    /// <typeparam name="TOutPut">輸出的資料表類別(ORM)</typeparam>
    internal interface IDataSourceSelect<TSource,TOutPut>
        where TOutPut : class
        where TSource : class
    {
        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        List<TOutPut> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression);

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        List<TOutPut> GetData(int startRowIndex, int maximumRows, string SortExpression);

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        int GetDataCount(TSource FilterData);

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        int GetDataCount();
    } 
}