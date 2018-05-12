using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    public class HopDongLaoDong
    {
        public string MaHopDong { get; set; }
        public string MaNhanVien { get; set; }
        public string LoaiHopDong { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }

        public HopDongLaoDong(string maHopDong, string maNhanVien, string loaiHopDong, DateTime tuNgay, DateTime denNgay)
        {
            MaHopDong = maHopDong;
            MaNhanVien = maNhanVien;
            LoaiHopDong = loaiHopDong;
            TuNgay = tuNgay;
            DenNgay = denNgay;
        }
    }
}
