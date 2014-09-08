using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToQuery.GetPageListMethod
{
    /// <summary>
    /// 取得分頁和排序資料的基礎方法
    /// </summary>
    /// <typeparam name="TSource">要查詢的Query、Where條件、輸出List的資料類型</typeparam>
    /// <typeparam name="TContext">Conetxt的資料類型</typeparam>
    public class GetPageListMethod<TSource, TContext> : IContext<TContext>, IContextToQuery<TContext, TSource>, IDataSourceSelect<TSource>
        where TContext : class, IDisposable
        where TSource : class 
    {
        IContextToQuery<TContext, TSource> contextToQueryMethod = new ContextToQueryMethod<TContext, TSource>();

        IContext<TContext> contextMethod = new ContextMethod<TContext>();

        QueryableConvertMethod queryableConvertMethod = new QueryableConvertMethod();

        LinqFilterData<TSource, TContext> LinqFilterDataMethod;        

        internal GetPageListMethod()
        {

        }

        public GetPageListMethod(LinqFilterData<TSource, TContext> LinqFilterDataMethod)
        {
            this.LinqFilterDataMethod = LinqFilterDataMethod;
        }

        public IQueryable<TSource> query
        {
            get { return contextToQueryMethod.query; }
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
            using (Context)
            {
                return queryableConvertMethod.GetPagerAndOrderList(GetCustomQuery(FilterData, query), startRowIndex, maximumRows, SortExpression);
            }
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
            using (Context)
            {
                return queryableConvertMethod.GetPagerAndOrderList(query, startRowIndex, maximumRows, SortExpression);
            }
        }


        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TSource FilterData)
        {
            using (Context)
            {
                return GetCustomQuery(FilterData, query).Count();
            }
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <returns>資料總筆數</returns>
        public int GetDataCount()
        {
            using (Context)
            {
                return query.Count();
            }
        }

        public TContext Context
        {
            get { return contextMethod.Context; }
        }


        /// <summary>
        /// 取得自訂的Query
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="query">查詢的Query</param>
        /// <returns>篩選Where的Query</returns>
        private IQueryable<TSource> GetCustomQuery(TSource FilterData, IQueryable<TSource> query)
        {
            IQueryable<TSource> WhereQuery = GetFilterQuery(FilterData, query, LinqFilterDataMethod.LinqWhere);
            return LinqFilterDataMethod.LinqSelect(WhereQuery);
        }

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
            return queryableConvertMethod.GetFilterQuery(FilterData, Query, FilterMethod);
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
        internal List<TQuery> GetPagerAndOrderList<TQuery>(IQueryable<TQuery> Query, int startRowIndex, int maximumRows, string SortExpression)
        {
            return queryableConvertMethod.GetPagerAndOrderList(Query, startRowIndex, maximumRows, SortExpression);
        }
    }

    /// <summary>
    /// 取得分頁和排序資料的共用方法
    /// </summary>
    /// <typeparam name="TSource">要查詢的Query及Where條件的資料類型</typeparam>
    /// <typeparam name="TContext">Conetxt的資料類型</typeparam>
    /// <typeparam name="TOutPut">回傳List的資料類型</typeparam>
    public class GetPageListMethod<TSource, TContext, TOutPut> : IDataSourceSelect<TSource, TOutPut>
        where TSource : class
        where TContext : class,IDisposable
        where TOutPut : class 
    {
        GetPageListMethod<TSource, TContext> OriginalGetPageListMethod = new GetPageListMethod<TSource ,TContext>();

        LinqFilterData<TSource, TContext,TOutPut> GetPageOutputListMethod;


        public GetPageListMethod(LinqFilterData<TSource, TContext, TOutPut> LinqFilterOutPutDataMethod)
        {
            this.GetPageOutputListMethod = LinqFilterOutPutDataMethod;
        }

        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TSource FilterData)
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
                return GetPageOutputListMethod.LinqSelect(OriginalGetPageListMethod.query).Count();
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
        public List<TOutPut> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression)
        {
            using (OriginalGetPageListMethod.Context)
            {
                return OriginalGetPageListMethod.GetPagerAndOrderList(GetCustomQuery(FilterData, OriginalGetPageListMethod.query), startRowIndex, maximumRows, SortExpression);
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
                return OriginalGetPageListMethod.GetPagerAndOrderList(GetPageOutputListMethod.LinqSelect(OriginalGetPageListMethod.query), startRowIndex, maximumRows, SortExpression);
            }
        }

        /// <summary>
        /// 取得自訂的Query
        /// </summary>
        /// <param name="FilterData">要篩選資料的條件</param>
        /// <param name="query">查詢的Query</param>
        /// <returns>篩選Select及Where的Query</returns>
        private IQueryable<TOutPut> GetCustomQuery(TSource FilterData, IQueryable<TSource> query)
        {
            IQueryable<TSource> WhereQuery = OriginalGetPageListMethod.GetFilterQuery(FilterData, query, GetPageOutputListMethod.LinqWhere);
            return GetPageOutputListMethod.LinqSelect(WhereQuery);
        }    
    }
}
