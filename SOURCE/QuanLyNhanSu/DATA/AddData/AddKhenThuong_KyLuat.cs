using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyNhanSu.DATA.AddData
{
    class AddKhenThuong_KyLuat
    {
        public void AddProc(KhenThuongKyLuat KhenThuongKyLuat)
        {
            SqlConnection conn = new SqlConnection("Server = DLC-20180225XEC\\TRUNGNGUYEN;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ADDKHENTHUONG_KYLUAT", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.Char, 10)).Value = KhenThuongKyLuat.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@SoQD", SqlDbType.Char, 10)).Value = KhenThuongKyLuat.SoQuyetDinh;
                cmd.Parameters.Add(new SqlParameter("@ThoiGian", SqlDbType.Date)).Value = KhenThuongKyLuat.ThoiGian;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
