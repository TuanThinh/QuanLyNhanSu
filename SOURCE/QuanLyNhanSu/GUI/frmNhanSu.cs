using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.GUI
{
    public partial class frmNhanSu : Form
    {
        public frmNhanSu()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtBacLuong.Enabled = false;
            txtDanToc.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtMaCV.Enabled = false;
            txtMaNV.Enabled = false;
            txtMaPB.Enabled = false;
            txtMaTDHV.Enabled = false;
            txtQuocTich.Enabled = false;
            txtSDT.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            dtNgaySinh.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        public void openControl()
        {
            txtBacLuong.Enabled = true;
            txtDanToc.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtMaCV.Enabled = true;
            txtMaNV.Enabled = true;
            txtMaPB.Enabled = true;
            txtMaTDHV.Enabled = true;
            txtQuocTich.Enabled = true;
            txtSDT.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            dtNgaySinh.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaNV.Focus();
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }
    }
}
