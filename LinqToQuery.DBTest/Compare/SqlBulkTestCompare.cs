using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToQuery.DBTest.DataBase;

namespace LinqToQuery.DBTest.Compare
{
    public class SqlBulkTestCompare : IComparer, IComparer<SqlBulkTest>
    {
        public int Compare(SqlBulkTest x, SqlBulkTest y)
        {
            return x.A1.Equals(y.A1) ? 0 : -1;
        }

        public int Compare(object x, object y)
        {
            return Compare(x as SqlBulkTest, y as SqlBulkTest);
        }
    }
}
