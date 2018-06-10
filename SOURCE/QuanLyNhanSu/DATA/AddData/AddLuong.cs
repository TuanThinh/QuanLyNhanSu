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
    class AddLuong
    {
        public void AddProc(Luong Luong)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into LUONG(BacLuong, LuongCB, HeSoLuong, HeSoPhuCap) values (@BacLuong, @LuongCB, @heSoLuong, @HeSoPhuCap)", conn);
                cmd.Parameters.Add(new SqlParameter("@BacLuong", SqlDbType.Float)).Value = Luong.BacLuong;
                cmd.Parameters.Add(new SqlParameter("@LuongCB", SqlDbType.Float)).Value = Luong.LuongCoBan;
                cmd.Parameters.Add(new SqlParameter("@HeSoLuong", SqlDbType.Float)).Value = Luong.HeSoLuong;
                cmd.Parameters.Add(new SqlParameter("@HeSoPhuCap", SqlDbType.Float)).Value = Luong.HeSoPhuCap;

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
