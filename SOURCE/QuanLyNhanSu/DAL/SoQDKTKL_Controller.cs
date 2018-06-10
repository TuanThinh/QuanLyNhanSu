using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class SoQDKTKL_Controller : Connect
    {
        public void EditSQDKTKL(SoQDKhenThuongKyLuat soQDKhenThuongKyLuat)
        {
            try
            {
                openConnection();
                string query = "update SOQUYETDINHKHENTHUONG_KYLUAT set LyDo = @lydo, HinhThuc = @hinhthuc where SoQD = @soqd";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@hinhthuc", soQDKhenThuongKyLuat.HinhThuc);
                cmd.Parameters.AddWithValue("@lydo", soQDKhenThuongKyLuat.LyDo);
                cmd.Parameters.AddWithValue("@soqd", soQDKhenThuongKyLuat.SoQD);
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
