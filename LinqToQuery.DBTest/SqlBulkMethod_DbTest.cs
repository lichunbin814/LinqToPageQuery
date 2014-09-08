using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LinqToQuery.SqlBulk;
using LinqToQuery.DBTest.DataBase;

namespace LinqToQuery.DBTest
{
    [TestClass]
    public class SqlBulkMethod_DbTest
    {
        private SqlBulkMethod sqlBulkMethod = new SqlBulkMethod();

        private Collection<SqlBulkTest> SqlBulkTestCollection = new Collection<SqlBulkTest>{
             new SqlBulkTest { A1 = "1", A2 = "2", A3 = "3" },
             new SqlBulkTest { A1 = "1", A2 = "2", A3 = "3" },
             new SqlBulkTest { A1 = "1", A2 = "2", A3 = null }};

        [TestMethod, Priority(1)]
        public void DB測試_新增資料_SqlBulkTest()
        {
            sqlBulkMethod.Insert(SqlBulkTestCollection, "SqlBulkTest", new LinqToQueryDBTestDataContext());

            for (int i = 0; i < SqlBulkTestCollection.Count; i++)
            {
                Assert.AreEqual(SqlBulkTestDbData[i].A1, SqlBulkTestCollection[i].A1);
                Assert.AreEqual(SqlBulkTestDbData[i].A2, SqlBulkTestCollection[i].A2);
                Assert.AreEqual(SqlBulkTestDbData[i].A3, SqlBulkTestCollection[i].A3);
            }
        }

        /// <summary>
        /// 連接的Context
        /// </summary>
        private LinqToQueryDBTestDataContext Context = new LinqToQueryDBTestDataContext();

        /// <summary>
        /// 從資料庫撈回來的資料
        /// </summary>
        private List<SqlBulkTest> SqlBulkTestDbData
        {
            get { return Context.SqlBulkTest.ToList(); }
        }

        [TestMethod, Priority(4)]
        public void DB測試_清除資料_SqlBulkTest()
        {
            Context.ExecuteCommand("truncate table [SqlBulkTest]");

            bool IsHaveData = SqlBulkTestDbData.Any();
            Assert.AreEqual(false, IsHaveData);
        }

        [TestMethod, Priority(999)]
        public void DB測試_釋放資源_SqlBulkTest()
        {
            Context.Dispose();
        }
    }
}