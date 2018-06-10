using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class Connect
    {
        private string strConn = @"Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        private SqlCommand cmd = null;
        private SqlConnection conn = null;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public Connect()
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
                openConnection();
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
        public void execNonQuery(string sql)
        {
            try
            {
                openConnection();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
