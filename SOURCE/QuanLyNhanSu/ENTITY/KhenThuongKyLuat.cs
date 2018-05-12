using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    public class KhenThuongKyLuat
    {
        public string MaNhanVien { get; set; }
        public string SoQuyetDinh { get; set; }
        public DateTime ThoiGian { get; set; }

        public KhenThuongKyLuat(string maNhanVien, string soQuyetDinh, DateTime thoiGian)
        {
            MaNhanVien = maNhanVien;
            SoQuyetDinh = soQuyetDinh;
            ThoiGian = thoiGian;
        }
    }
}
