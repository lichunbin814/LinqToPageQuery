﻿using LinqToSqlSample.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LinqToSql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private Customers _Customer = null;
    protected internal Customers Customer
    {
        get
        {
            return _Customer = _Customer
            ?? new Customers()
            {
                ContactTitle = "訂貨員",
                City = "台北市"
            };
        }
        set { _Customer = value; }
    }


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["FilterData"] = Customer;
    }
}