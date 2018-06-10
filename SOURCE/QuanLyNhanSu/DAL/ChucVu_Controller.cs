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
    class ChucVu_Controller : Connect
    {
        public void EditChucVu(ChucVu chucVu)
        {
            try
            {
                openConnection();
                string query = "update CHUCVU set TenCV = @ten where MaCV = @ma";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@ma", chucVu.MaChucVu);
                //cmd.Parameters.AddWithValue("@ten", chucVu.TenChucVu);
                cmd.Parameters.Add(new SqlParameter("@ten", SqlDbType.NVarChar)).Value = chucVu.TenChucVu;
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
