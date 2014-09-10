using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using LinqToQuery;

namespace LinqToSqlSample.DAL
{
    [DataObjectAttribute]
    public class CustomersPartialExtention : LinqFilterData<Customers, NorthwindChineseDataContext, CustomersPartial>
    {
        protected override IQueryable<Customers> LinqWhere(Customers FilterData, IQueryable<Customers> query)
        {
            if (FilterData.City != "")
            {
                query = query.Where(Customer => Customer.City == FilterData.City);
            }

            return query;
        }

        protected override IQueryable<CustomersPartial> LinqSelect(IQueryable<Customers> query)
        {
            return query.Select(Customer => new CustomersPartial
            {
                CustomerID = Customer.CustomerID,
                Address = Customer.Address,
                City = Customer.City
            });
        }
    }

    public class CustomersFilterPartialExtention : LinqFilterData<Customers, CustomersFilter, NorthwindChineseDataContext, CustomersFitlerPartial>
    {

        protected override IQueryable<Customers> LinqWhere(CustomersFilter FilterData, IQueryable<Customers> query)
        {
            if (FilterData.StartPostalCode > 0 && FilterData.EndStartPostalCode > 0)
            {
                query = query.Where(customer =>
                    customer.PostalCode >= FilterData.StartPostalCode &
                    customer.PostalCode <= FilterData.EndStartPostalCode);
            }

            return query;
        }

        protected override IQueryable<CustomersFitlerPartial> LinqSelect(IQueryable<Customers> query)
        {
            return query.Select(customer => new CustomersFitlerPartial
            {
                CustomerID = customer.CustomerID,
                Address = customer.Address                
            });
        }
    }

    [DataObjectAttribute]
    public class CustomersExtention : LinqFilterData<Customers, NorthwindChineseDataContext>
    {
        protected override IQueryable<Customers> LinqWhere(Customers FilterData, IQueryable<Customers> query)
        {
            if (FilterData.City != "")
            {
                query = query.Where(Customer => Customer.City == FilterData.City);
            }

            return query;
        }
    }



    public class CustomersFitlerPartial
    {
        public string CustomerID { get; set; }

        public string Address { get; set; }
    }

    public class CustomersPartial
    {
        public string CustomerID { get; set; }


        public string City { get; set; }

        public string Address { get; set; }
    }

    public class CustomersFilter
    {
        public int StartPostalCode { get; set; }


        public int EndStartPostalCode { get; set; }
    }
}