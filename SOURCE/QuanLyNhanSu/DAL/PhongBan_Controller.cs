using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class PhongBan_Controller : Connect
    {
        public void EditPhongBan(PhongBan phongBan)
        {
            try
            {
                openConnection();
                string query = "update PHONGBAN set TenPB = @ten, DiaChi = @diachi, SDT = @sdt where MaPB = @ma";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@ma", phongBan.MaPhongBan);
                cmd.Parameters.Add(new SqlParameter("@ten", SqlDbType.NVarChar)).Value = phongBan.TenPhongBan;
                cmd.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NVarChar)).Value = phongBan.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@sdt", SqlDbType.NVarChar)).Value = phongBan.SDT;
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
