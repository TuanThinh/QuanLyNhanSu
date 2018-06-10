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
    class AddNhanVien
    {
        public void AddProc(NhanVien nhanvien)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into NHANVIEN(MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, DanToc, QuocTich, SDT, MaPB, MaCV, MaTDHV, BacLuong) values (@MaNV, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @DanToc, @QuocTich, @SDT, @MaPB, @MaCV, @MaTDHV, @BacLuong)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.Char, 10)).Value = nhanvien.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@HoTen", SqlDbType.Text)).Value = nhanvien.HoTen;
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.Text)).Value = nhanvien.GioiTinh;
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date)).Value = nhanvien.NgaySinh/*.ToString("yyyy-mm-dd")*/;
                cmd.Parameters.Add(new SqlParameter("@Diachi", SqlDbType.Text)).Value = nhanvien.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@DanToc", SqlDbType.Text)).Value = nhanvien.DanToc;
                cmd.Parameters.Add(new SqlParameter("@QuocTich", SqlDbType.Text)).Value = nhanvien.QuocTich;
                cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Text)).Value = nhanvien.SoDienThoai;
                cmd.Parameters.Add(new SqlParameter("@MaPB", SqlDbType.Char, 10)).Value = nhanvien.MaPhongBan;
                cmd.Parameters.Add(new SqlParameter("@MaCV", SqlDbType.Char, 10)).Value = nhanvien.MaChucVu;
                cmd.Parameters.Add(new SqlParameter("@MaTDHV", SqlDbType.Char, 10)).Value = nhanvien.MaTrinhDoHocVan;
                cmd.Parameters.Add(new SqlParameter("@BacLuong", SqlDbType.Float)).Value = nhanvien.BacLuong;


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
