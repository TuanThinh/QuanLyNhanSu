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
    public class EditThongTinHopDongLaoDong
    {
        public string MaHopDongCu { get; set; }
        /// <summary>
        /// Thu tuc sua thong tin bang hop dong lao dong
        /// </summary>
        /// <param name="hopDongLaoDong"></param>
        public void ExcuteProc(HopDongLaoDong hopDongLaoDong)
        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=.;Database=QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditHopDongLaoDong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maHopDongCu", SqlDbType.Char, 10)).Value = this.MaHopDongCu;
                cmd.Parameters.Add(new SqlParameter("@maHopDong", SqlDbType.Char, 10)).Value = hopDongLaoDong.MaHopDong;
                cmd.Parameters.Add(new SqlParameter("@maNhanVien", SqlDbType.Text)).Value = hopDongLaoDong.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@loaiHopDong", SqlDbType.Text)).Value = hopDongLaoDong.LoaiHopDong;
                cmd.Parameters.Add(new SqlParameter("@tuNgay", SqlDbType.Date)).Value = hopDongLaoDong.TuNgay.ToString("yyyy-MM-dd HH:mm:SS"); 
                cmd.Parameters.Add(new SqlParameter("@denNgay", SqlDbType.Date)).Value = hopDongLaoDong.DenNgay.ToString("yyyy-MM-dd HH:mm:SS");

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
