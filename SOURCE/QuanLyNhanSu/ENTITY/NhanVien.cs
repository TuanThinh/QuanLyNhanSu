using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DanToc { get; set; }
        public string QuocTich { get; set; }
        public string SoDienThoai { get; set; }
        public string MaPhongBan { get; set; }
        public string MaChucVu { get; set; }
        public string MaTrinhDoHocVan { get; set; }
        public string BacLuong { get; set; }

        public NhanVien(string maNV, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string danToc, string quocTich, string soDienThoai,
            string maPhongBan, string maChucVu, string maTrinhDoHocVan, string bacLuong)
        {
            MaNhanVien = maNV;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            DanToc = danToc;
            QuocTich = quocTich;
            SoDienThoai = soDienThoai;
            MaPhongBan = maPhongBan;
            MaChucVu = maChucVu;
            MaTrinhDoHocVan = maTrinhDoHocVan;
            BacLuong = bacLuong;
        }
    }
}
