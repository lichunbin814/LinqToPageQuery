using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LinqToQuery;

namespace LinqToEntitySample.DAL
{    

    [DataObjectAttribute]
    public class CustomersPartialExtention : LinqFilterData<Customers,NorthwindChineseEntities,CustomersPartial>
    {

        protected override IQueryable<Customers> LinqWhere(Customers FilterData, IQueryable<Customers> query)
        {
            if(FilterData.City != "")
            {
                query = query.Where(Customer => Customer.City == FilterData.City);
            }

            return query;
        }


        protected override IQueryable<CustomersPartial> LinqSelect(IQueryable<Customers> query)
        {
            return query.Select(Customer => new CustomersPartial
            {
                CustomerID= Customer.CustomerID,
                City = Customer.City,
                Address = Customer.Address
            });
        }
    }

    public class CustomersFilterPartialExtention : LinqFilterData<Customers, CustomersFilter, NorthwindChineseEntities, CustomersFitlerPartial>
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

        
    public class CustomersExtention : LinqFilterData<Customers, NorthwindChineseEntities>
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

    public class CustomersFilter
    {
        public int StartPostalCode { get; set; }


        public int EndStartPostalCode { get; set; }
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
  
}