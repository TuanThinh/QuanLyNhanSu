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
    public partial class frmTrinhDoHocVan : Form
    {
        bool kt;
        public frmTrinhDoHocVan()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtChuyenNganhHoc.Enabled = false;
            txtMaTDHV.Enabled = false;
            txtTenTDHV.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtChuyenNganhHoc.Enabled = true;
            txtMaTDHV.Enabled = true;
            txtTenTDHV.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmTrinhDoHocVan_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Controler nd = new DAL.NguoiDung_Controler();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaTDHV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kt == false)
            {
                string query = "delete from TRINHDOHOCVAN where MaTDHV = '" + txtMaTDHV.Text.Trim() + "'";
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
