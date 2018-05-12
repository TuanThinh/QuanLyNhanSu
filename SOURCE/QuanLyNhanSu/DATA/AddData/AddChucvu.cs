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
    class AddChucvu
    {
        public void AddProc(ChucVu chucvu)
        {
            SqlConnection conn = new SqlConnection("Server = DLC-20180225XEC\\TRUNGNGUYEN;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                //Console.WriteLine("haha");
                SqlCommand cmd = new SqlCommand("ADDCHUCVU", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MaCV", SqlDbType.Char, 10)).Value = chucvu.MaChucVu;
                cmd.Parameters.Add(new SqlParameter("@TenCV", SqlDbType.Text)).Value = chucvu.TenChucVu;

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
