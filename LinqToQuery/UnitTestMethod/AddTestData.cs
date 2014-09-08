using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using LinqToQuery.SqlBulk;

namespace LinqToQuery.UnitTestMethod
{
    /// <summary>
    /// 單元測試操作測試資料的方法
    /// </summary>
    public class AddTestData<TSource, TContext>
        where TSource : class
        where TContext : class,IDisposable
    {
        private TContext _context;
        public TContext Context
        {
            get
            {
                return _context == null ? _context = new ContextMethod<TContext>().Context : _context;
            }
        }

        private IEnumerable<TSource> TestSampleData;

        private string TableName = typeof(TSource).Name;

        private SqlBulkMethod sqlBulkMethod = new SqlBulkMethod();

        bool _IsInit = true;

        /// <summary>
        /// 開始新增測試用資料
        /// </summary>
        /// <param name="TestSampleData">測試用的資料</param>
        /// <param name="IsInit">是否需要初使化，若無指定則由私有變數_IsInit决定初使化的動作</param>
        public void action(IEnumerable<TSource> TestSampleData  , bool? IsInit = null)
        {            
            if (IsInit == null ? _IsInit : (bool)IsInit)
            {
                TurncateTable();

                sqlBulkMethod.Insert(TestSampleData, TableName, Context as DataContext);

                _IsInit = false;
            }
        }       
       

        [TestMethod, Priority(4)]
        public void TurncateTable()
        {
            (Context as DataContext).ExecuteCommand(string.Format("truncate table {0}", TableName));
        }
    }
}
