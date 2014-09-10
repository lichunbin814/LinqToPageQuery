using GenericSelect;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToSqlSample;

namespace LinqToEntitySample
{
    public class LinqToEntityQueryAble<T> : AbsGridViewMehtod<T, DbContext> where T : class
    {
        protected override string GetPrimaryKey(IQueryable<T> query)
        {
            return new DataContextExtension<T>().GetPrimaryKey(query);
        }
    }
}
