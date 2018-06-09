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
            string datasource = @"PC\NGUYENMTA";

            //
            string database = "QuanLyNhanSu";
            string username = "";
            string password = "";

            string connString =  @"Data Source="+datasource+";Initial Catalog="+database+";Persist Security Info=True;User ID="+username+";Password="+password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }

    
        


        
}
