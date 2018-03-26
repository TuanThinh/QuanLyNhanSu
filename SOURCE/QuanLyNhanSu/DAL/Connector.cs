using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyNhanSu.DAL
{
    class Connector
    {
        private string strConn = "Data Source=DESKTOP-DPEU76K;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        private SqlCommand cmd = null;
        private SqlConnection conn = null;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public Connector()
        {
            conn = new SqlConnection(strConn);
        }

        public void openConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConn);
            }
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public SqlDataReader execCommand(string sql)
        {
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            return dr;
        }
       
    }
}
