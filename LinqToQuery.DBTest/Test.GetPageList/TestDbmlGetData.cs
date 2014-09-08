using LinqToSqlSample.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace LinqToQuery.DBTest
{
    /// <summary>
    /// 測試-模擬ObjectDataSource透過"篩選資料","起始Index","取得筆數","排序欄位"取得DBML資料
    /// </summary>
    [TestClass]
    public class TestDbmlGetData
    {

        private DBMLCompareCustomerID compareCustomerID = new DBMLCompareCustomerID();

        #region 輸出Customers

        private CustomersExtention customersGetData = new CustomersExtention();


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

        #endregion 沒有FilterData

        #region 有使用FilterData

        private Customers FilterCustomers = new Customers { City = "台北市" };

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

        #endregion 有使用FilterData 
        #endregion

        #region 輸出CustomersPartial

        #region 沒有FilterData

        CustomersPartialExtention CustomerPartialMethod = new CustomersPartialExtention();

         Customers customerFilter = new Customers()
            {
                ContactTitle = "訂貨員",
                City = "台北市"
            };

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartial_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersPartial> ExpectedCustomersPartial = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "ALFKI"},
                new CustomersPartial{CustomerID = "ANATR"},
                new CustomersPartial{CustomerID = "ANTON"},
                new CustomersPartial{CustomerID = "AROUT"},
                new CustomersPartial{CustomerID = "BERGS"}
            };

            List<CustomersPartial> ActualCustomersPartial = CustomerPartialMethod.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得_錯誤的_CustomerPartial_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersPartial> ExpectedCustomersPartial = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "1"},
                new CustomersPartial{CustomerID = "2"},
                new CustomersPartial{CustomerID = "3"},
                new CustomersPartial{CustomerID = "4"},
                new CustomersPartial{CustomerID = "5"}
            };

            List<CustomersPartial> ActualCustomersPartial = CustomerPartialMethod.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartial_第1到第3筆的資料_由CustomerID_遞減排序()
        {
            List<CustomersPartial> ExpectedCustomersPartial = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "XXYYZ"},
                new CustomersPartial{CustomerID = "WOLZA"},
                new CustomersPartial{CustomerID = "WILMK"},
            };

            List<CustomersPartial> ActualCustomersPartial = CustomerPartialMethod.GetData(0, 3, "CustomerID Desc");

            CollectionAssert.AreEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartial_資料總筆數()
        {
            int ActualDataCount = CustomerPartialMethod.GetDataCount();

            Assert.AreEqual(92, ActualDataCount);
        }

        #endregion 沒有FilterData

        #region 有使用FilterData

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartial_台北市_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersPartial> ExpectedCustomers = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "ALFKI"},
                new CustomersPartial{CustomerID = "BOLID"},
                new CustomersPartial{CustomerID = "BONAP"},
                new CustomersPartial{CustomerID = "DRACD"},
                new CustomersPartial{CustomerID = "FOLKO"}
            };

            List<CustomersPartial> ActualCustomers = CustomerPartialMethod.GetData(customerFilter,0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_無法_取得CustomerPartial_台北市_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersPartial> ExpectedCustomers = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "ALFKI"},
                new CustomersPartial{CustomerID = "BOLID"},
                new CustomersPartial{CustomerID = "BONAP"},
                new CustomersPartial{CustomerID = "DRACD"},
                new CustomersPartial{CustomerID = "FOLKO"}
            };

            List<CustomersPartial> ActualCustomers = CustomerPartialMethod.GetData(new Customers(), 0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartial_台北市_第1到第5筆的資料_由CustomerID_遞減排序()
        {
            List<CustomersPartial> ExpectedCustomers = new List<CustomersPartial>
            {
                new CustomersPartial{CustomerID = "XXYYZ"},
                new CustomersPartial{CustomerID = "VINET"},
                new CustomersPartial{CustomerID = "VICTE"},
                new CustomersPartial{CustomerID = "THEBI"},
                new CustomersPartial{CustomerID = "SANTG"}
            };

            List<CustomersPartial> ActualCustomers = CustomerPartialMethod.GetData(FilterCustomers, 0, 5, "CustomerID Desc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartail_台北市_第1到第5筆的資料的總筆數()
        {
            List<CustomersPartial> ActualCustomers = CustomerPartialMethod.GetData(FilterCustomers, 0, 3, "CustomerID Desc");

            Assert.AreEqual(3, ActualCustomers.Count);
        }

        #endregion 有使用FilterData

        #endregion

        #region 輸出CustomersFilterPartial

        #region 沒有FilterData

        CustomersFilterPartialExtention CustomersFilterPartialMethod = new CustomersFilterPartialExtention();

        CustomersFilter customerFilterParm = new CustomersFilter()
        {
            StartPostalCode = 10000,
            EndStartPostalCode = 50500
        };

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerFilterPartial_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomersPartial = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "ALFKI"},
                new CustomersFitlerPartial{CustomerID = "ANATR"},
                new CustomersFitlerPartial{CustomerID = "ANTON"},
                new CustomersFitlerPartial{CustomerID = "AROUT"},
                new CustomersFitlerPartial{CustomerID = "BERGS"}
            };

            List<CustomersFitlerPartial> ActualCustomersPartial = CustomersFilterPartialMethod.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得_錯誤的_CustomerFilterPartial_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomersPartial = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "1"},
                new CustomersFitlerPartial{CustomerID = "2"},
                new CustomersFitlerPartial{CustomerID = "3"},
                new CustomersFitlerPartial{CustomerID = "4"},
                new CustomersFitlerPartial{CustomerID = "5"}
            };

            List<CustomersFitlerPartial> ActualCustomersPartial = CustomersFilterPartialMethod.GetData(0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerFilterPartial_第1到第3筆的資料_由CustomerID_遞減排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomersPartial = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "XXYYZ"},
                new CustomersFitlerPartial{CustomerID = "WOLZA"},
                new CustomersFitlerPartial{CustomerID = "WILMK"},
            };

            List<CustomersFitlerPartial> ActualCustomersPartial = CustomersFilterPartialMethod.GetData(0, 3, "CustomerID Desc");

            CollectionAssert.AreEqual(ExpectedCustomersPartial, ActualCustomersPartial, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerFilterPartial_資料總筆數()
        {
            int ActualDataCount = CustomerPartialMethod.GetDataCount();

            Assert.AreEqual(92, ActualDataCount);
        }

        #endregion 沒有FilterData

        #region 有使用FilterData

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerFilterPartial_PostalCode_10000_到_50050_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomers = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "ALFKI"},
                new CustomersFitlerPartial{CustomerID = "AROUT"},
                new CustomersFitlerPartial{CustomerID = "BERGS"},
                new CustomersFitlerPartial{CustomerID = "BOLID"},
                new CustomersFitlerPartial{CustomerID = "BONAP"}
            };

            List<CustomersFitlerPartial> ActualCustomers = CustomersFilterPartialMethod.GetData(customerFilterParm, 0, 5, "CustomerID Asc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_無法_取得CustomerFilterPartial_PostalCode_10000_到_50050_第1到第5筆的資料_由CustomerID_遞增排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomers = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "ALFKI"},
                new CustomersFitlerPartial{CustomerID = "BOLID"},
                new CustomersFitlerPartial{CustomerID = "BONAP"},
                new CustomersFitlerPartial{CustomerID = "DRACD"},
                new CustomersFitlerPartial{CustomerID = "FOLKO"}
            };

            List<CustomersFitlerPartial> ActualCustomers = CustomersFilterPartialMethod.GetData(new CustomersFilter(), 0, 5, "CustomerID Asc");

            CollectionAssert.AreNotEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerFilterPartial_PostalCode_10000_到_50050_第1到第5筆的資料_由CustomerID_遞減排序()
        {
            List<CustomersFitlerPartial> ExpectedCustomers = new List<CustomersFitlerPartial>
            {
                new CustomersFitlerPartial{CustomerID = "XXYYZ"},
                new CustomersFitlerPartial{CustomerID = "WILMK"},
                new CustomersFitlerPartial{CustomerID = "TOMSP"},
                new CustomersFitlerPartial{CustomerID = "SEVES"},
                new CustomersFitlerPartial{CustomerID = "SANTG"}
            };

            List<CustomersFitlerPartial> ActualCustomers = CustomersFilterPartialMethod.GetData(customerFilterParm, 0, 5, "CustomerID Desc");

            CollectionAssert.AreEqual(ExpectedCustomers, ActualCustomers, compareCustomerID);
        }

        [TestMethod]
        public void 整合測試_由DBML_取得CustomerPartail_PostalCode_10000_到_50050_第1到第5筆的資料的總筆數()
        {
            List<CustomersFitlerPartial> ActualCustomers = CustomersFilterPartialMethod.GetData(customerFilterParm, 0, 3, "CustomerID Desc");

            Assert.AreEqual(3, ActualCustomers.Count);
        }

        #endregion 有使用FilterData

        #endregion

    }

 

    /// <summary>
    /// 比對CustomerID
    /// </summary>
    public class DBMLCompareCustomerID : IComparer<Customers>, IComparer, IComparer<CustomersPartial>, IComparer<CustomersFitlerPartial>
    {
        public int Compare(Customers x, Customers y)
        {
            if (x.CustomerID == y.CustomerID)
                return 0;
            else
                return -1;
        }

           public int Compare(CustomersPartial x, CustomersPartial y)
        {
            if (x.CustomerID == y.CustomerID)
                return 0;
            else
                return -1;
        }

        public int Compare(object x, object y)
        {
            if(x.GetType() == typeof(Customers))
                return Compare(x as Customers, y as Customers);
            else if(x.GetType() == typeof(CustomersPartial))
                return Compare(x as CustomersPartial, y as CustomersPartial);
            else if (x.GetType() == typeof(CustomersFitlerPartial))
                return Compare(x as CustomersFitlerPartial, y as CustomersFitlerPartial);

            return x == y ? 0 : -1;
        }

        public int Compare(CustomersFitlerPartial x, CustomersFitlerPartial y)
        {
            if (x.CustomerID == y.CustomerID)
                return 0;
            else
                return -1;
        }
    }
}