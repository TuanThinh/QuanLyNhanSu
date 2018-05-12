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
    public class EditThongTinPhongBan
    {
        public string MaPhongBanCu { get; set; }

        /// <summary>
        /// Thuc thi thu tuc sua thong tin phong ban
        /// </summary>
        /// <param name="phongBan"></param>
        public void ExcuteProc(PhongBan phongBan)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditPhongBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maPhongBanCu", SqlDbType.Char, 10)).Value = this.MaPhongBanCu;
                cmd.Parameters.Add(new SqlParameter("@maPhongBan", SqlDbType.Char, 10)).Value = phongBan.MaPhongBan;
                cmd.Parameters.Add(new SqlParameter("@tenPhongBan", SqlDbType.Text)).Value = phongBan.TenPhongBan;
                cmd.Parameters.Add(new SqlParameter("@diaChi", SqlDbType.Text)).Value = phongBan.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@sdt", SqlDbType.Text)).Value = phongBan.SDT;

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
