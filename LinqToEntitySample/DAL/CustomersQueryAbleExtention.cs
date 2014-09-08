using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Tw.Com.Hamastar.LinqToQuery;

namespace LinqToEntitySample.DAL
{    

    [DataObjectAttribute]
    public class CustomersQueryAbleExtention : LinqFilterData<Customers,NorthwindChineseEntities,CustomersPartial>
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
                City1 = Customer.City,
                Address1 = Customer.Address
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

    public class CustomersPartial 
    {

        public string City1 { get; set; }

        public string Address1 { get; set; }
    }
  
}