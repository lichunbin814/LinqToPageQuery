using System;
using System.Linq;
using System.Reflection;
namespace LinqToQuery
{
    /// <summary>
    /// 將Context型別轉換為Class
    /// </summary>
    /// <typeparam name="TContext">Conetxt(ORM)的型別</typeparam>  
    public interface IContext<TContext>
        where TContext : class, IDisposable
    {
        /// <summary>
        /// Context容器
        /// </summary>
        TContext Context { get; }   
    }
}
