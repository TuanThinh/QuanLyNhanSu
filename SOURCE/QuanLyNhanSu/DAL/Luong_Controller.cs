using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class Luong_Controller : Connect
    {
        public void EditLuong(Luong luong)
        {
            try
            {
                openConnection();
                string query = "update LUONG set LuongCB = @luongcb, HeSoLuong = @hesoluong, HeSoPhuCap = @hesophucap where BacLuong = @bacluong";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@bacluong", luong.BacLuong);
                cmd.Parameters.AddWithValue("@luongcb", luong.LuongCoBan);
                cmd.Parameters.AddWithValue("@hesoluong", luong.HeSoLuong);
                cmd.Parameters.AddWithValue("@hesophucap", luong.HeSoPhuCap);
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
