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
    class AddSoQuyetDinhKhenThuongKyLuat
    {
        public void AddProc(SoQDKhenThuongKyLuat soqdktkl)
        SqlConnection conn = new SqlConnection("DLC-20180225XEC\\TRUNGNGUYEN;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddSoQuyetDinhKhenThuongKyLuat", conn);
        cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("MaCV", SqlDbType.Char, 10)).Value = chucvu.MaChucVu;
                cmd.Parameters.Add(new SqlParameter("TenCV", SqlDbType.Text)).Value = chucvu.TenChucVu;

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
