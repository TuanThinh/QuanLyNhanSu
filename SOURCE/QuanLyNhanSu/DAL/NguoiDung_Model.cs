using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhanSu.ENTITY;

namespace QuanLyNhanSu.DAL
{
    class NguoiDung_Model : Connector
    {
        public static string taikhoan;
        public static string matkhau;

        public int checkLogin(string name, string pass)
        {
            try
            {
                string query = "select * from NGUOIDUNG where TaiKhoan = '" + name.Trim() + "' and MatKhau = '" + pass.Trim() + "'";
                Connector conn = new Connector();
                conn.openConnection();
                SqlDataReader dr = conn.execCommand(query);
                if (dr.HasRows == true)
                    return 1;
                conn.closeConnection();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
            return 0;
        }

     
        public void checkPermissions(Button btnThem, Button btnSua, Button btnXoa)
        {
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            try
            {
                string sql = "select * from NGUOIDUNG where TaiKhoan = '" + taikhoan + "' and MatKhau = '" + matkhau + "'";
                DAL.Connector conn = new DAL.Connector();
                conn.openConnection();
                SqlDataReader dr = conn.execCommand(sql);
                while (dr.Read())
                {
                    if (dr["Them"].ToString().Equals("True"))
                    {
                        btnThem.Visible = true;
                    }
                    if (dr["Sua"].ToString().Equals("True"))
                    {
                        btnSua.Visible = true;
                    }
                    if (dr["Xoa"].ToString().Equals("True"))
                    {
                        btnXoa.Visible = true;
                    }
                }
                conn.closeConnection();
            }
            catch (Exception ex)
            {
                new Exception("Error: " + ex.Message);
            }
    
        }

        public void insertNGUOIDUNG(NguoiDung nd)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("insertNGUOIDUNG", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@Them", nd.Them);
                cmd.Parameters.AddWithValue("@Sua", nd.Sua);
                cmd.Parameters.AddWithValue("@Xoa", nd.Xoa);
                cmd.Parameters.AddWithValue("@Ad", nd.Ad);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                new Exception("Error: " + e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public void updateNGUOIDUNG(NguoiDung nd)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("editNGUOIDUNG", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", nd.TaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@Them", nd.Them);
                cmd.Parameters.AddWithValue("@Sua", nd.Sua);
                cmd.Parameters.AddWithValue("@Xoa", nd.Xoa);
                cmd.Parameters.AddWithValue("@Ad", nd.Ad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                new Exception("Error: " + e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public void deleteNGUOIDUNG(NguoiDung nd)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("deleteNGUOIDUNG", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", nd.TaiKhoan);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                new Exception("Error: " + e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        
    }
}
