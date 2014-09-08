using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqToQuery.OperateDataBase
{
    /// <summary>
    /// 操作資料庫會使用到的方法
    /// </summary>
    /// <typeparam name="TSource">ORM產生的資料表類別</typeparam>
    public interface IOperateDataBase<TSource> where TSource : class
    {
        /// <summary>
        /// 取得篩選資料的Query
        /// </summary>
        /// <typeparam name="TValue">篩選的欄位</typeparam>
        /// <param name="Predicate">篩選的條件</param>
        /// <returns>篩選資料的Query</returns>
        IQueryable<TSource> Get<TValue>(Expression<Func<TSource, TValue>> Predicate) where TValue : class;

        /// <summary>
        /// 取得全部資料的Query
        /// </summary>
        /// <returns>查詢全部資料的Query</returns>
        IQueryable<TSource> Get();

        /// <summary>
        /// 新增資料，並取得新增後的SN
        /// </summary>
        /// <param name="InsertObject">要新增的資料</param>
        /// <returns>新增後的SN</returns>
        int Insert(TSource InsertObject);

        /// <summary>
        /// 修改資料
        /// </summary>
        /// <param name="UpdateObjcet">要修改的資料</param>
        void Update(TSource UpdateObjcet);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="DelteObjcet">要刪除的資料</param>
        void Delete(TSource DelteObjcet);
    }
}
