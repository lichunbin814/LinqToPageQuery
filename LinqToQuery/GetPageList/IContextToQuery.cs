using System;
using System.Linq;

namespace LinqToQuery
{
    /// <summary>
    /// 籍由Context(ORM)取得特定資料表類別(ORM)的Query
    /// </summary>
    /// <typeparam name="TContext">Conetxt(ORM)的型別</typeparam>
    /// <typeparam name="TSource">要轉換的Query資料表類別(ORM)</typeparam>
    internal interface IContextToQuery<TContext, TSource>
        where TContext : class, IDisposable
        where TSource : class
    {
        /// <summary>
        /// 由Context轉換後的Query
        /// </summary>
        IQueryable<TSource> query { get; }      
    }
}