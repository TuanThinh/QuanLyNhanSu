using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DATA
{
    public class EditThongTinChucVu
    {
        public string MaChucVuCu { get; set; }

        /// <summary>
        /// Thuc thi thu tuc sua thong tin chuc vu
        /// </summary>
        /// <param name="chucVu"></param>
        public void ExcuteProc(ChucVu chucVu)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditChucVu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maChucVuCu", SqlDbType.Char, 10)).Value = this.MaChucVuCu;
                cmd.Parameters.Add(new SqlParameter("@maChucVu", SqlDbType.Char, 10)).Value = chucVu.MaChucVu;
                cmd.Parameters.Add(new SqlParameter("@tenChucVu", SqlDbType.Text)).Value = chucVu.TenChucVu;

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
