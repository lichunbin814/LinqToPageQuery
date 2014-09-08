using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;
using System.Text;
using LinqToQuery;

namespace LinqToQuery
{
    /// <summary>
    /// 籍由Context(ORM)取得特定資料表類別(ORM)的Query
    /// </summary>
    /// <typeparam name="TContext">Conetxt(ORM)的型別</typeparam>
    /// <typeparam name="TSource">要轉換的Query資料表類別(ORM)</typeparam>
    public class ContextToQueryMethod<TContext,TSource> : IContextToQuery<TContext,TSource>
        where TContext : class, IDisposable
        where TSource : class
    {
        IContext<TContext> contextMethod = new ContextMethod<TContext>();
    
        private IQueryable<TSource> _query = null;
        /// <summary>
        /// 由Context轉換後的Query
        /// </summary>
        public IQueryable<TSource> query
        {
            get
            {
                return _query = _query ?? GenerateQuery(contextMethod.Context);
            }
        }

        /// <summary>
        /// 依照傳入的Conetxt類型回傳特定的資料表類別Query
        /// </summary>
        /// <param name="Context">Context(ORM)的類別</param>
        /// <returns>Context預設回傳的資料表Query</returns>
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
    }
}
