using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqToSqlSample
{
    public class DataContextExtension<T> where T : class
    {
        /// <summary>
        /// 由query的上層找Mapping的Class並取得主鍵名稱
        /// </summary>
        /// <param name="query">要反查的query</param>
        /// <returns>主鍵名稱</returns>
        public  string GetPrimaryKey(IQueryable<T> query)
        {
            //取得query資料表的所有屬性
            PropertyInfo[] ProInfos = query.ElementType.GetProperties();
            return
                ProInfos.Where(ProInfo =>
                        //傳回非繼承的屬性
                        ProInfo.GetCustomAttributes(false)
                        //類別與資料庫資料表中的資料行產生關聯的屬性
                        .OfType<ColumnAttribute>()
                        //IsPrimaryKey == true
                        .Select(MemInfo => MemInfo.IsPrimaryKey).FirstOrDefault())
                    //若無法取得主鍵名稱 ，則回傳第一個欄位
                    .Select(ProInfo => (ProInfo).Name).FirstOrDefault() ?? ProInfos[0].Name;
        }
    }
}
