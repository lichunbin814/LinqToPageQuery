using System;
namespace LinqToQuery
{
    public interface IDataMapping
    {
        /// <summary>
        /// 取得主鍵名稱
        /// </summary>
        /// <param name="ProInfos">所有的屬性</param>
        /// <returns>主鍵名稱</returns>
        string GetPrimaryKey(global::System.Reflection.PropertyInfo[] ProInfos);
    }
}
