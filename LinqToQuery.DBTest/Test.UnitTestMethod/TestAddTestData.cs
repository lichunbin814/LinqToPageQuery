using LinqToSqlSample.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToQuery.UnitTestMethod;
using LinqToQuery.DBTest.Compare;
using LinqToQuery.DBTest.DataBase;

namespace LinqToQuery.DBTest.Test.UnitTestMethod
{
    [TestClass]
    public class TestAddTestData
    {
        AddTestData<SqlBulkTest, LinqToQueryDBTestDataContext> InitUnitTest = new AddTestData<SqlBulkTest, LinqToQueryDBTestDataContext>();

        List<SqlBulkTest> TestData = new List<SqlBulkTest>
            {
             new SqlBulkTest { A1 = "7", A2 = "9", A3 = "3" },
             new SqlBulkTest { A1 = "7", A2 = "9", A3 = "3" },
             new SqlBulkTest { A1 = "7", A2 = "9", A3 = null }
            };

        [TestMethod, Priority(1)]
        public void InitData()
        {
            InitUnitTest.action(TestData);


            List<SqlBulkTest> ActualData = DbData;
            CollectionAssert.AreEqual(TestData, ActualData, sqlBulkTestCompare);

        }

        List<SqlBulkTest> DbData
        {
            get
            {
                return InitUnitTest.Context.SqlBulkTest.Select(Data => Data).ToList(); 
            }
        }

        SqlBulkTestCompare sqlBulkTestCompare = new SqlBulkTestCompare();

        [TestMethod, Priority(4)]
        public void 測試_清除單元測試的資料()
        {
            InitUnitTest.TurncateTable();
            bool IsHaveData = DbData.Any();
            Assert.AreEqual(false, IsHaveData);
        }
    }
}
