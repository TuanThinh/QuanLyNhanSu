using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DATA.EditData
{
     public class EditThongTinSoQDKhenThuongKyLuat
    {
        public string soQuyetDinhCu { get; set; }

        public void ExcuteProc(SoQDKhenThuongKyLuat soQDKhenThuongKyLuat)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditSoQuyetDinhKhenThuongKyLuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@soQuyetDinhCu", SqlDbType.Char, 10)).Value = this.soQuyetDinhCu;
                cmd.Parameters.Add(new SqlParameter("@soQuyetDinh", SqlDbType.Char, 10)).Value = soQDKhenThuongKyLuat.SoQD;
                cmd.Parameters.Add(new SqlParameter("@lyDo", SqlDbType.Text)).Value = soQDKhenThuongKyLuat.LyDo;
                cmd.Parameters.Add(new SqlParameter("@hinhThuc", SqlDbType.Text)).Value = soQDKhenThuongKyLuat.HinhThuc;

                //excute proc
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
