using System;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;


namespace LinqToQuery
{
    /// <summary>
    /// Context(ORM)的方法
    /// </summary>
    /// <typeparam name="TContext">Context資料型別</typeparam>
    public class ContextMethod<TContext> : IContext<TContext>
        where TContext : class,IDisposable
    {
        /// <summary>
        /// Context容器
        /// </summary>
        public TContext Context
        {
            get
            { return Activator.CreateInstance(typeof(TContext)) as TContext; }
        }
    }
}