using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ENTITY
{
    class NguoiDung
    {
        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        private string matkhau;

        public string MatKhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        private bool them;

        public bool Them
        {
            get { return them; }
            set { them = value; }
        }
        private bool sua;

        public bool Sua
        {
            get { return sua; }
            set { sua = value; }
        }
        private bool xoa;

        public bool Xoa
        {
            get { return xoa; }
            set { xoa = value; }
        }
        private bool ad;

        public bool Ad
        {
            get { return ad; }
            set { ad = value; }
        }
    }
}
