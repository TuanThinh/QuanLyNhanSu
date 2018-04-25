using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    public class PhongBan
    {
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public PhongBan(string maPhongBan, string tenPhongBan, string diaChi, string sdt)
        {
            MaPhongBan = maPhongBan;
            TenPhongBan = tenPhongBan;
            DiaChi = diaChi;
            SDT = sdt;
        }
    }
}
