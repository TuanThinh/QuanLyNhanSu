using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class KhenThuongKyLuat_Controller : Connect
    {
        public void EditKhenThuongKyLuat(KhenThuongKyLuat khenThuongKyLuat)
        {
            try
            {
                openConnection();
                string query = "update KHENTHUONG_KYLUAT set SoQD = @soqd, ThoiGian = @thoigian where MaNV = @manv";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@manv", khenThuongKyLuat.MaNhanVien);
                cmd.Parameters.AddWithValue("@soqd", khenThuongKyLuat.SoQuyetDinh);
                cmd.Parameters.AddWithValue("@thoigian", khenThuongKyLuat.ThoiGian);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
