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
    class HopDongLaoDong_Controller : Connect
    {
        public void EditHopDongLaoDong(HopDongLaoDong hopDongLaoDong)
        {
            try
            {
                openConnection();
                string query = "update HOPDONGLAODONG set MaNV = @manv, LoaiHD = @loaihd, TuNgay = @tungay, DenNgay = @denngay where MaHD = @mahd";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@mahd", hopDongLaoDong.MaHopDong);
                cmd.Parameters.AddWithValue("@manv", hopDongLaoDong.MaNhanVien);
                //cmd.Parameters.AddWithValue("@loaihd", hopDongLaoDong.LoaiHopDong);
                cmd.Parameters.Add(new SqlParameter("@loaihd", SqlDbType.NVarChar)).Value = hopDongLaoDong.LoaiHopDong;
                cmd.Parameters.AddWithValue("@tungay", hopDongLaoDong.TuNgay);
                cmd.Parameters.AddWithValue("@denngay", hopDongLaoDong.DenNgay);
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
