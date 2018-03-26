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
    public partial class frmLuong : Form
    {
        public frmLuong()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtBacLuong.Enabled = false;
            txtHeSoLuong.Enabled = false;
            txtHeSoPhuCap.Enabled = false;
            txtLuongCB.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtBacLuong.Enabled = true;
            txtHeSoLuong.Enabled = true;
            txtHeSoPhuCap.Enabled = true;
            txtLuongCB.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtBacLuong.Focus();
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
