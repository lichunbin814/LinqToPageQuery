using System;
using System.Collections.Generic;
using System.Linq;
using LinqToQuery.GetPageListMethod;

namespace LinqToQuery
{
    #region 篩選及輸出都是TSource
    /// <summary>
    /// 取得分頁和排序的資料
    /// </summary>
    /// <typeparam name="TSource">要查詢的Query、Where條件、輸出List的資料類型</typeparam>
    /// <typeparam name="TContext">Conetxt的資料類型</typeparam>
    public abstract class LinqFilterData<TSource, TContext> : IDataSourceSelect<TSource>
        where TSource : class
        where TContext : class,IDisposable
    {
        public LinqFilterData() 
        {
            OriginalGetPageListMethod = new GetPageListMethod<TSource, TContext>(this);
        }

        GetPageListMethod<TSource, TContext> OriginalGetPageListMethod;


        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TSource FilterData)
        {
           return OriginalGetPageListMethod.GetDataCount(FilterData);
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        public int GetDataCount()
        {
            return OriginalGetPageListMethod.GetDataCount();
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TSource> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression)
        {
            return OriginalGetPageListMethod.GetData(FilterData, startRowIndex, maximumRows, SortExpression);            
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TSource> GetData(int startRowIndex, int maximumRows, string SortExpression)
        {
            return OriginalGetPageListMethod.GetData(startRowIndex, maximumRows, SortExpression);
        }

        /// <summary>
        /// 自訂的Where篩選方式
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="query">查詢的Query</param>
        /// <returns></returns>
        protected internal abstract IQueryable<TSource> LinqWhere(TSource FilterData, IQueryable<TSource> query);

        /// <summary>
        /// 自訂Select的語法
        /// </summary>
        /// <param name="query">待修改的Query</param>
        /// <returns>自訂的Select語法</returns>
        protected internal virtual IQueryable<TSource> LinqSelect(IQueryable<TSource> query)
        {
            return query;
        }      
    }   


    #endregion

    #region 篩選TSource、輸出TOutPut
    /// <summary>
    /// 取得分頁和排序的資料
    /// </summary>
    /// <typeparam name="TSource">要查詢的Query及Where條件的資料類型</typeparam>
    /// <typeparam name="TContext">Conetxt的資料類型</typeparam>
    /// <typeparam name="TOutPut">回傳List的資料類型</typeparam>
    public abstract class LinqFilterData<TSource, TContext, TOutPut> : IDataSourceSelect<TSource, TOutPut>
        where TSource : class
        where TContext : class,IDisposable
        where TOutPut : class 
    {
        public LinqFilterData()
        {
            GetPageOutputListMethod = new GetPageListMethod<TSource,TContext, TOutPut>(this);
        }

        GetPageListMethod<TSource, TContext,TOutPut> GetPageOutputListMethod;

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TSource FilterData)
        {
            return GetPageOutputListMethod.GetDataCount(FilterData);
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        public int GetDataCount()
        {
            return GetPageOutputListMethod.GetDataCount();
        }
        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TOutPut> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression)
        {
            return GetPageOutputListMethod.GetData(FilterData, startRowIndex, maximumRows, SortExpression);
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TOutPut> GetData(int startRowIndex, int maximumRows, string SortExpression)
        {
            return GetPageOutputListMethod.GetData( startRowIndex, maximumRows, SortExpression);
        }          

        /// <summary>
        /// 自訂的Where篩選方式
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="query">查詢的Query</param>
        /// <returns>實作Where的Query</returns>
        protected internal abstract IQueryable<TSource> LinqWhere(TSource FilterData, IQueryable<TSource> query);

        /// <summary>
        /// 自訂Select的語法
        /// </summary>
        /// <param name="query">待修改的Query</param>
        /// <returns>自訂的Select語法</returns>
        protected internal abstract IQueryable<TOutPut> LinqSelect(IQueryable<TSource> query);

           
    } 
    #endregion

    #region 篩選TFilter、輸出TOutPut  

    /// <summary>
    /// 取得分頁和排序的資料
    /// </summary>
    /// <typeparam name="TSource">要查詢的Query資料類型</typeparam>
    /// <typeparam name="TFilter">Where條件的資料類型</typeparam>
    /// <typeparam name="TContext">Conetxt的資料類型</typeparam>
    /// <typeparam name="TOutPut">回傳List的資料類型</typeparam>
    public abstract class LinqFilterData<TSource, TFilter, TContext, TOutPut> : IDataSourceSelect<TFilter, TOutPut>
        where TFilter : class
        where TSource : class
        where TContext : class,IDisposable
        where TOutPut : class
    {
        GetPageListMethod< TSource , TContext> OriginalGetPageListMethod = new GetPageListMethod< TSource , TContext>();


        QueryableConvertMethod queryableConvertMethod = new QueryableConvertMethod();

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TFilter FilterData)
        {
            using (OriginalGetPageListMethod.Context)
            {
                return GetCustomQuery(FilterData, OriginalGetPageListMethod.query).Count();
            }
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        public int GetDataCount()
        {
            using (OriginalGetPageListMethod.Context)
            {
                return LinqSelect(OriginalGetPageListMethod.query).Count();
            }
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TOutPut> GetData(TFilter FilterData, int startRowIndex, int maximumRows, string SortExpression)
        {
            using (OriginalGetPageListMethod.Context)
            {
                IQueryable<TOutPut> CustomQuery = GetCustomQuery(FilterData, OriginalGetPageListMethod.query);
                return queryableConvertMethod.GetPagerAndOrderList(CustomQuery, startRowIndex, maximumRows, SortExpression);
            }
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TOutPut> GetData(int startRowIndex, int maximumRows, string SortExpression)
        {
            using (OriginalGetPageListMethod.Context)
            {
                IQueryable<TOutPut> SelectQuery = LinqSelect(OriginalGetPageListMethod.query);
                return queryableConvertMethod.GetPagerAndOrderList(SelectQuery, startRowIndex, maximumRows, SortExpression);
            }
        }

        /// <summary>
        /// 自訂的Where篩選方式
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="query">查詢的Query</param>
        /// <returns></returns>
        protected internal abstract IQueryable<TSource> LinqWhere(TFilter FilterData, IQueryable<TSource> query);

        /// <summary>
        /// 自訂Select的語法
        /// </summary>
        /// <param name="query">待修改的Query</param>
        /// <returns>自訂的Select語法</returns>
        protected internal abstract IQueryable<TOutPut> LinqSelect(IQueryable<TSource> query);

        /// <summary>
        /// 取得自訂的Query
        /// </summary>
        /// <param name="FilterData">待修改的Query</param>
        /// <param name="query">查詢的Query</param>
        /// <returns>篩選Select及Where的Query</returns>
        private IQueryable<TOutPut> GetCustomQuery(TFilter FilterData, IQueryable<TSource> query)
        {
            IQueryable<TSource> WhereQuery = queryableConvertMethod.GetFilterQuery(FilterData, query, LinqWhere);
            return LinqSelect(WhereQuery);
        }
    }
    #endregion

}