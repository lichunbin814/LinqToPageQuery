using System;
using System.Collections.Generic;
using System.Linq;

namespace Tw.Com.Hamastar.LinqToQuery
{
    public abstract class LinqFilterData<TSource, TContext, TOutPut> : LinqGetData<TSource, TContext>, IDataSourceSelect<TOutPut, TSource>
        where TSource : class
        where TContext : class,IDisposable
        where TOutPut : class
    {
        /// <summary>
        /// 取得資料總筆數(分頁用)
        /// </summary>
        /// <param name="query">要轉為SQL的Query</param>
        /// <returns>資料總筆數</returns>
        public int GetDataCount(TSource FilterData)
        {
            using (Context)
            {
                return CustomQuery(FilterData, query).Count();
            }
        }

        /// <summary>
        /// 取得排序且分頁的資料
        /// </summary>
        /// <param name="query">要轉為SQL的Query</param>
        /// <param name="startRowIndex">起始位置</param>
        /// <param name="maximumRows">要取得的資料筆數</param>
        /// <param name="SortExpression">排序的欄位</param>
        /// <returns>經過排序且分頁的資料</returns>
        public List<TOutPut> GetData(TSource FilterData, int startRowIndex, int maximumRows, string SortExpression)
        {
            using (Context)
            {
                return GetList(CustomQuery(FilterData, query), startRowIndex, maximumRows, SortExpression);
            }
        }

        /// <summary>
        /// 自訂的Where篩選方式
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected internal abstract IQueryable<TSource> LinqWhere(TSource FilterData, IQueryable<TSource> query);

        /// <summary>
        /// 自訂Select的語法
        /// </summary>
        /// <param name="query">待修改的Query</param>
        /// <returns>自訂的Select語法</returns>
        protected internal abstract IQueryable<TOutPut> LinqSelect(IQueryable<TSource> query);

        /// <summary>
        /// 取得自訂的Query
        /// </summary>
        /// <param name="query">待修改的Query</param>
        /// <returns>篩選Select及Where的Query</returns>
        private IQueryable<TOutPut> CustomQuery(TSource FilterData, IQueryable<TSource> query)
        {
            IQueryable<TSource> WhereQuery = LinqWhere(FilterData, query);
            return LinqSelect(WhereQuery);            
        }
    }
}