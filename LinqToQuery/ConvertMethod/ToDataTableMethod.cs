using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqToQuery.ConvertMethod
{
    public static class ToDataTableMethod
    {
        ///// <summary>
        ///// List轉為DataTable
        ///// </summary>
        ///// <typeparam name="TSource">List的型別</typeparam>
        ///// <param name="ListData">要轉換的List</param>
        ///// <returns>由List轉型而成的DataTable</returns>
        //public static DataTable ToDataTable<TSource>(this IList<TSource> ListData)
        //{    
        //    var Dt = new DataTable(typeof(TSource).Name);
        //    PropertyInfo[] Props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo Prop in Props)
        //    {
        //        Type MappingType = GetMappingType(Prop);
        //        Dt.Columns.Add(Prop.Name, MappingType);
        //    }           

        //    foreach (TSource Data in ListData)
        //    {
        //        var Values = Props.Select(Prop => Prop.GetValue(Data, null)).ToArray();
        //        Dt.Rows.Add(Values);
        //    }
        //    return Dt;
        //}

        private static bool IsNullable(Type type)
        {
            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// 取得Property的型別
        /// </summary>
        /// <param name="SourceProperty">Property來源</param>
        /// <returns>若為可Null型別</returns>
        private static Type GetPropType(PropertyInfo SourceProperty)
        {
            Type PropType = SourceProperty.PropertyType;

            if ((PropType.IsGenericType) && (PropType.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                PropType = PropType.GetGenericArguments()[0];
            }

            return PropType;


        }


        /// <summary>
        /// 將實作IEnumerable的介面轉為DataTable
        /// </summary>
        /// <typeparam name="TSource">IEnumerable型別</typeparam>
        /// <param name="EnumerableData">要轉換的IEnumerable資料</param>
        /// <returns>由IEnumerable轉換而成的DataTable</returns>
        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> EnumerableData)
        {
            var Dt = new DataTable(typeof(TSource).Name);
            PropertyInfo[] Props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo Prop in Props)
            {
                Type MappingType = GetPropType(Prop);
                Dt.Columns.Add(Prop.Name, MappingType);
            }
            

            foreach (TSource Data in EnumerableData)
            {
                var Values = Props.Select(Prop => Prop.GetValue(Data, null)).ToArray();
                Dt.Rows.Add(Values);
            }            
           
            return Dt;
        }
    }
}
