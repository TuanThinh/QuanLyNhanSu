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
    public class EditThongTinNhanVien
    {
        public string MaNhanVienCu { get; set; }

        /// <summary>
        /// Thuc thi thu tuc sua thong tin nhan vien
        /// </summary>
        /// <param name="nhanVien"></param>
        public void ExcuteProc(NhanVien nhanVien)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maNhanVienCu", SqlDbType.Char, 10)).Value = this.MaNhanVienCu;
                cmd.Parameters.Add(new SqlParameter("@maNhanVien", SqlDbType.Char, 10)).Value = nhanVien.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@hoTen", SqlDbType.Text)).Value = nhanVien.HoTen;
                cmd.Parameters.Add(new SqlParameter("@gioiTinh", SqlDbType.Text)).Value = nhanVien.GioiTinh;
                cmd.Parameters.Add(new SqlParameter("@ngaySinh", SqlDbType.DateTime)).Value = nhanVien.NgaySinh.ToString("yyyy-MM-dd");
                cmd.Parameters.Add(new SqlParameter("@diaChi", SqlDbType.Text)).Value = nhanVien.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@danToc", SqlDbType.Text)).Value = nhanVien.DanToc;
                cmd.Parameters.Add(new SqlParameter("@quocTich", SqlDbType.Text)).Value = nhanVien.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@sdt", SqlDbType.Text)).Value = nhanVien.SoDienThoai;
                cmd.Parameters.Add(new SqlParameter("@maPhongBan", SqlDbType.Char, 10)).Value = nhanVien.MaPhongBan;
                cmd.Parameters.Add(new SqlParameter("@maChucVu", SqlDbType.Char, 10)).Value = nhanVien.MaChucVu;
                cmd.Parameters.Add(new SqlParameter("@maTrinhDoHocVan", SqlDbType.Char, 10)).Value = nhanVien.MaTrinhDoHocVan;
                cmd.Parameters.Add(new SqlParameter("@bacLuong", SqlDbType.Float)).Value = nhanVien.BacLuong;

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
