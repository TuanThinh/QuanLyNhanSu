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
    public partial class frmChucVu : Form
    {
        bool kt;
        public frmChucVu()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtMaCV.Enabled = false;
            txtTenCV.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        public void openControl()
        {
            txtMaCV.Enabled = true;
            txtTenCV.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Controler nd = new DAL.NguoiDung_Controler();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaCV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kt==false)
            {
                string query = "delete from CHUCVU where MaCV = '" + txtMaCV.Text.Trim() +"'";
                DAL.Connector conn = new DAL.Connector();
                conn.execNonQuery(query);
            }
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
        }
    }
}
