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
    public partial class frmSoQDKhenThuongKyLuat : Form
    {
        public frmSoQDKhenThuongKyLuat()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtHinhThuc.Enabled = false;
            txtLyDo.Enabled = false;
            txtSoQDKhenThuongKyLuat.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtHinhThuc.Enabled = true;
            txtLyDo.Enabled = true;
            txtSoQDKhenThuongKyLuat.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmSoQDKhenThuongKyLuat_Load(object sender, EventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtSoQDKhenThuongKyLuat.Focus();
        }
    }
}
