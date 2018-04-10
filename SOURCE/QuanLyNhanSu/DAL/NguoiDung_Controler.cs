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
    class NguoiDung_Controler : Connector
    {
        public static string taikhoan;
        public static string matkhau;

        public int checkLogin(string name, string pass)
        {
            try
            {
                string query = "select * from NGUOIDUNG where TaiKhoan = '" + name.Trim() + "' and MatKhau = '" + pass.Trim() + "'";
                SqlDataReader dr = execCommand(query);
                if (dr.HasRows == true)
                    return 1;
                closeConnection();
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
                SqlDataReader dr = execCommand(sql);
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
                closeConnection();
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
                string query = "insert into NGUOIDUNG(MaNV, MatKhau, Them, Sua, Xoa, CreateLogin) values (@MaNV, @MatKhau, @Them, @Sua, @Xoa, @Ad)";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@MaNV", nd.MaNV);
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
                string query = "update NGUOIDUNG set MatKhau = @MatKhau, @Them = @Them, Sua = @Sua, Xoa = @Xoa, CreateLogin = @Ad where MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@MaNV", nd.MaNV);
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
                string query = "delete from NGUOIDUNG where MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand("deleteNGUOIDUNG", Conn);
                cmd.Parameters.AddWithValue("@MaNV", nd.MaNV);
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
