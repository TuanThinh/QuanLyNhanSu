using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    public class Luong
    {
        public float BacLuong { get; set; }
        public float LuongCoBan { get; set; }
        public float HeSoLuong { get; set; }
        public float HeSoPhuCap { get; set; }

        public Luong(float bacLuong, float luongCoBan, float heSoLuong, float heSoPhuCap)
        {
            BacLuong = bacLuong;
            LuongCoBan = luongCoBan;
            HeSoLuong = heSoLuong;
            HeSoPhuCap = heSoPhuCap;
        }
    }
}
