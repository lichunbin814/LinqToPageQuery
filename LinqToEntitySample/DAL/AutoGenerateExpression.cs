using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LinqToEntitySample.DAL
{
    public static class AutoGenerateExpression
    {
        private static ParameterExpression GenerateParameterExpression<T>(string ParameterName)
        {
            return Expression.Parameter(typeof(T), ParameterName);
        }

        public static IQueryable<TSource> EqualsExpression<TSource>(this IQueryable<TSource> query, TSource FilterData)
        {
            string ParameterName = "FilterData";

            //只存取由ORM所建立的資料表類別成員，排除類似EntityState的ORM基底型別
            foreach (PropertyInfo ProInfo in FilterData.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {

                object EqualsValue = ProInfo.GetValue(FilterData, null);

                if (EqualsValue != null)
                {
                    ParameterExpression ParFilterClass = GenerateParameterExpression<Customers>(ParameterName);

                    Expression property = Expression.Property(ParFilterClass, ProInfo.Name);

                    ConstantExpression right = Expression.Constant(EqualsValue, ProInfo.PropertyType);

                    BinaryExpression expEuqals = Expression.Equal(property, right);

                    Expression<Func<TSource, bool>> lambdaExp = Expression.Lambda<Func<TSource, bool>>(expEuqals, ParFilterClass);

                    query = query.Where(lambdaExp);
                }
            }



            return query;
        }
    }
}
