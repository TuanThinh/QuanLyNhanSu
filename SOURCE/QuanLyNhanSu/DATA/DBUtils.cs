using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DATA
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //data source:
            string datasource = @"DEVSERVER-WIN7\SQLEXPRESS";

            //
            string database = "ThucTapNhom_QuanLyNhanSu";
            string username = "sa";
            string password = "1";

            string connString =  @"Data Source="+datasource+";Initial Catalog="+database+";Persist Security Info=True;User ID="+username+";Password="+password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }

    
        


        
}
