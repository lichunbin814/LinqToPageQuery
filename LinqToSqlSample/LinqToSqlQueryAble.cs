using GenericSelect;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Dynamic;

namespace LinqToSqlSample
{
    public class LinqToSqlGV<T> : AbsGridViewMehtod<T,DataContext> where T : class
    {
        //protected DataContext Context { get; set; }

        //protected LinqToSqlGV(DataContext DbContext) : base(DbContext) {}

        //public IQueryable<T> DynamicSort(IQueryable<T> query, string SortExpression, bool ParimaryKeySort)
        //{
        //    if (SortExpression == "")
        //    {
        //        //是否由主鍵排序
        //        string PrimaryKey = ParimaryKeySort ? GetPrimaryKey(query) : SortExpression;
        //        //主鍵若非空值由大到小排序，反之則不排序
        //        return PrimaryKey != "" ? query.OrderBy(string.Format("{0} Desc", PrimaryKey)) : query;
        //    }
        //    else
        //    {
        //        //依SortExporession排序
        //        return query.OrderBy(SortExpression);
        //    }
        //}

        //public int GetDataCount(IQueryable<T> query)
        //{
        //    using (Context)
        //    {
        //        return query.Count();
        //    }
        //}

        //public List<T> GetList(IQueryable<T> query, int StartIndex, int PageSize, string SortExpression = "", bool ParimaryKeySort = false)
        //{
        //    //檢查是否需要排序
        //    return GetPagerCommand(DynamicSort(query, SortExpression, ParimaryKeySort), StartIndex, PageSize).ToList();
        //}

        //public IQueryable<T> GetPagerCommand(IQueryable<T> query, int StartIndex, int PageSize)
        //{
        //    return query.Skip(StartIndex).Take(PageSize);
        //}

        /// <summary>
        /// 由query的上層找Mapping的Class並取得主鍵名稱
        /// </summary>
        /// <param name="query">要反查的query</param>
        /// <returns>主鍵名稱</returns>
        protected override string GetPrimaryKey(IQueryable<T> query)
        {
            return new DataContextExtension<T>().GetPrimaryKey(query);
        }
    }
}