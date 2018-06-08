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
    class EditThongTinLuong
    {
        public float BacLuongCu { get; set; }

        /// <summary>
        /// thu tuc sua thong tin bang luong
        /// </summary>
        /// <param name="chucVu"></param>
        public void ExcuteProc(Luong luong)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=.;Database=QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditLuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@bacLuongCu", SqlDbType.Float)).Value = this.BacLuongCu;
                cmd.Parameters.Add(new SqlParameter("@bacLuong", SqlDbType.Float)).Value = luong.BacLuong;
                cmd.Parameters.Add(new SqlParameter("@luongCoBan", SqlDbType.Float)).Value = luong.LuongCoBan;
                cmd.Parameters.Add(new SqlParameter("@heSoLuong", SqlDbType.Float)).Value = luong.HeSoLuong;
                cmd.Parameters.Add(new SqlParameter("@heSoPhuCap", SqlDbType.Float)).Value = luong.HeSoPhuCap;

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
