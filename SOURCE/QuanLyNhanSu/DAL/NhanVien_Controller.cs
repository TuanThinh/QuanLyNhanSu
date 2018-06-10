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
    class NhanVien_Controller : Connect
    {
        public void EditNhanVien(NhanVien nhanVien)
        {
            try
            {
                openConnection();
                string query = "update NHANVIEN set HoTen = @hoten, GioiTinh = @gioitinh, NgaySinh = @ngaysinh, DiaChi = @diachi, DanToc = @dantoc, QuocTich = @quoctich, SDT = @sdt, MaPB = @mapb, MaCV = @macv, MaTDHV = @matdhv, BacLuong = @bacluong where MaNV = @manv";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@manv", nhanVien.MaNhanVien);
                cmd.Parameters.Add(new SqlParameter("@hoten", SqlDbType.NVarChar)).Value = nhanVien.HoTen;
                cmd.Parameters.Add(new SqlParameter("@gioitinh", SqlDbType.NVarChar)).Value = nhanVien.GioiTinh;
                cmd.Parameters.AddWithValue("@ngaysinh", nhanVien.NgaySinh);
                cmd.Parameters.Add(new SqlParameter("@diachi", SqlDbType.NVarChar)).Value = nhanVien.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@dantoc", SqlDbType.NVarChar)).Value = nhanVien.DanToc;
                cmd.Parameters.Add(new SqlParameter("@quoctich", SqlDbType.NVarChar)).Value = nhanVien.QuocTich;
                cmd.Parameters.Add(new SqlParameter("@sdt", SqlDbType.NVarChar)).Value = nhanVien.SoDienThoai;
                cmd.Parameters.AddWithValue("@mapb", nhanVien.MaPhongBan);
                cmd.Parameters.AddWithValue("@macv", nhanVien.MaChucVu);
                cmd.Parameters.AddWithValue("@matdhv", nhanVien.MaTrinhDoHocVan);
                cmd.Parameters.AddWithValue("@bacluong", nhanVien.BacLuong);
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
