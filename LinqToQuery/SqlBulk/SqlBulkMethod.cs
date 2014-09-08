using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LinqToQuery.ConvertMethod;

namespace LinqToQuery.SqlBulk
{
    /// <summary>
    /// SqlBulk的方法
    /// </summary>
    public  class SqlBulkMethod
    {
        /// <summary>
        /// 籍由SqlBulk新增資料
        /// </summary>
        /// <typeparam name="TSource">要新增的資料類別</typeparam>
        /// <param name="source">要新增的資料</param>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="databaseContext">DBML的DataContext</param>
        public void Insert<TSource>(IEnumerable<TSource> source, string tableName, DataContext databaseContext)
            where TSource : class
        {
            var dataTable = source.ToDataTable();
            string ConnectionString = databaseContext.Connection.ConnectionString;
            using (SqlConnection SqlConn = new SqlConnection(ConnectionString))
            {
                //開啟連結
                SqlConn.Open();
                //執行交易
                using (SqlTransaction tran = SqlConn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConn, SqlBulkCopyOptions.Default , tran))
                    {
                        bulkCopy.DestinationTableName = "[" + tableName + "]";

                        ColumnMapping(bulkCopy, dataTable);

                        bulkCopy.WriteToServer(dataTable);
                    }
                    //認可
                    tran.Commit();
                }
            }
        }
        /// <summary>
        /// 將來源與目的端的資料欄位做對應欄位的動作
        /// </summary>
        /// <param name="bulkCopy">目的端的SqlBulkCopy物件</param>
        /// <param name="dataTable">來源資料</param>
        private void ColumnMapping(SqlBulkCopy bulkCopy, DataTable dataTable)
        {
            foreach (DataColumn Column in dataTable.Columns)
            {
                string DataColumnName = Column.ColumnName;
                var BulkMappingInfo = new SqlBulkCopyColumnMapping(DataColumnName, DataColumnName);
                bulkCopy.ColumnMappings.Add(BulkMappingInfo);
            }          
        }
    }
}
