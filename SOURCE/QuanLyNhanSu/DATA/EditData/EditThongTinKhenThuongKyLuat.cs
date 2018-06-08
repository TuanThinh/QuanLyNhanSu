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
    class EditThongTinKhenThuongKyLuat
    {
        public string MaNhanVienCu { get; set; }
        public string SoQuyetDinhCu { get; set; }

        /// <summary>
        /// thu tuc sua thong tin bang khen thuong ky luat
        /// </summary>
        /// <param name="khenThuongKyLuat"></param>
        public void ExcuteProc(KhenThuongKyLuat khenThuongKyLuat)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=.;Database=QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditKhenThuongKyLuat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maChucVuCu", SqlDbType.Char, 10)).Value = this.MaNhanVienCu;
                cmd.Parameters.Add(new SqlParameter("@soQuyetDinhCu", SqlDbType.Char, 10)).Value = this.SoQuyetDinhCu;
                cmd.Parameters.Add(new SqlParameter("@maChucVu", SqlDbType.Char, 10)).Value = khenThuongKyLuat.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@soQuyetDinh", SqlDbType.Char, 10)).Value = khenThuongKyLuat.SoQuyetDinh;
                cmd.Parameters.Add(new SqlParameter("@thoiGian", SqlDbType.Date)).Value = khenThuongKyLuat.ThoiGian.ToString("yyyy-MM-dd HH:mm:SS");

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
