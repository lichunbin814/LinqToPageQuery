using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tw.Hamastar.Com.LinqToQuery.DBTest.DataBase;
using Tw.Com.Hamastar.LinqToQuery.SqlBulk;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Tw.Com.Hamastar.LinqToQuery;
using LinqToSqlSample.DAL;
using System.Collections;

namespace Tw.Hamastar.Com.LinqToQuery.DBTest
{
    [TestClass]
    public class Test1
    {
        TestGetData testGetData = new TestGetData();

        [TestMethod]
        public void TestMethod1()
        {
            testGetData.整合測試_由DBML_取得Customers_第1到第5筆的資料_由CustomerID_遞增排序();
            testGetData.整合測試_由DBML_取得_錯誤的_Customers_第1到第5筆的資料_由CustomerID_遞增排序();
            testGetData.整合測試_由DBML_取得Customers_第1到第5筆的資料_由CustomerID_遞減排序();
            testGetData.整合測試_由DBML_取得Customers_資料總筆數();
            testGetData.整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞增排序();
            testGetData.整合測試_由DBML_無法_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞增排序();
            testGetData.整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞減排序();
            testGetData.整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料的總筆數();
        }
    }

    /// <summary>
    /// 測試-模擬ObjectDataSource透過"篩選資料","起始Index","取得筆數","排序欄位"取得資料
    /// </summary>
    [TestClass]
    public class TestGetData
    {
        public LinqFilterData<Customers, NorthwindChineseDataContext> customersGetData = new CustomersExtention();        

        CompareCustomerID compareCustomerID = new CompareCustomerID();

        #region 沒有FilterData
        [TestMethod]
        public void 整合測試_由DBML_取得Customers_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "ALFKI"},
                new Customers{CustomerID = "ANATR"},
                new Customers{CustomerID = "ANTON"},
                new Customers{CustomerID = "AROUT"},
                new Customers{CustomerID = "BERGS"}
            };

            List<Customers> ActualCustomers = customersGetData.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得_錯誤的_Customers_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "1"},
                new Customers{CustomerID = "2"},
                new Customers{CustomerID = "3"},
                new Customers{CustomerID = "4"},
                new Customers{CustomerID = "5"}
            };

            List<Customers> ActualCustomers = customersGetData.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得Customers_第1到第5筆的資料_由CustomerID_遞減排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "XXYYZ"},
                new Customers{CustomerID = "WOLZA"},
                new Customers{CustomerID = "WILMK"},                
            };

            List<Customers> ActualCustomers = customersGetData.GetData(0, 3, "CustomerID Desc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        

        [TestMethod]
        public void 整合測試_由DBML_取得Customers_資料總筆數()
        {
            int ActualDataCount = customersGetData.GetDataCount();

            Assert.AreEqual(92, ActualDataCount);
        } 
        #endregion

        #region 有使用FilterData
        Customers FilterCustomers = new Customers { City = "台北市" };

        [TestMethod]
        public void 整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "ALFKI"},
                new Customers{CustomerID = "BOLID"},
                new Customers{CustomerID = "BONAP"},
                new Customers{CustomerID = "DRACD"},
                new Customers{CustomerID = "FOLKO"}
            };

            List<Customers> ActualCustomers = customersGetData.GetData(FilterCustomers, 0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_無法_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "ALFKI"},
                new Customers{CustomerID = "BOLID"},
                new Customers{CustomerID = "BONAP"},
                new Customers{CustomerID = "DRACD"},
                new Customers{CustomerID = "FOLKO"}
            };

            List<Customers> ActualCustomers = customersGetData.GetData(new Customers(), 0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料_由CustomerID_遞減排序()
        {
            List<Customers> ExpectedCustomers = new List<Customers>
            {
                new Customers{CustomerID = "XXYYZ"},
                new Customers{CustomerID = "VINET"},
                new Customers{CustomerID = "VICTE"},
                new Customers{CustomerID = "THEBI"},
                new Customers{CustomerID = "SANTG"}
            };

            List<Customers> ActualCustomers = customersGetData.GetData(FilterCustomers, 0, 5, "CustomerID Desc");
            
            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得Customers_台北市_第1到第5筆的資料的總筆數()
        {
            List<Customers> ActualCustomers = customersGetData.GetData(FilterCustomers, 0, 3, "CustomerID Desc");

            Assert.AreEqual(3, ActualCustomers.Count);
        } 
        #endregion
    }

    /// <summary>
    /// 比對CustomerID
    /// </summary>
    public class CompareCustomerID : IComparer<Customers>, IComparer
    {
        public int Compare(Customers x, Customers y)
        {
            if (x.CustomerID == y.CustomerID)
                return 0;
            else
                return -1;
        }

        public int Compare(object x, object y)
        {
            return Compare(x as Customers, y as Customers);
        }
    }
}
