using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqToQuery
{
    public class DataMappingMethod : IDataMapping
    {
        /// <summary>
        /// 取得主鍵名稱
        /// </summary>
        /// <param name="ProInfos">所有的屬性</param>
        /// <returns>主鍵名稱</returns>
        public string GetPrimaryKey(PropertyInfo[] ProInfos)
        {
            return ProInfos.Where(ProInfo =>
                //傳回非繼承的屬性
                       ProInfo.GetCustomAttributes(false)
                           //類別與資料庫資料表中的資料行產生關聯的屬性
                       .OfType<ColumnAttribute>()
                           //IsPrimaryKey == true
                       .Select(MemInfo => MemInfo.IsPrimaryKey).FirstOrDefault())
                    //取得主鍵名稱
                   .Select(ProInfo => (ProInfo).Name).FirstOrDefault();
        }
    }
}
