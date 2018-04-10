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
    public partial class frmHopDongLaoDong : Form
    {
        bool kt;
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtLoaiHopDong.Enabled = false;
            txtMaHopDong.Enabled = false;
            txtMaNV.Enabled = false;
            dtNgayBatDau.Enabled = false;
            dtNgayKetThuc.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtLoaiHopDong.Enabled = true;
            txtMaHopDong.Enabled = true;
            txtMaNV.Enabled = true;
            dtNgayBatDau.Enabled = true;
            dtNgayKetThuc.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            DAL.NguoiDung_Controler nd = new DAL.NguoiDung_Controler();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            lockControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kt==false)
            {
                string query = "delete from HOPDONGLAODONG where MaHD = '" + txtMaHopDong.Text.Trim() + "'";
                DAL.Connector conn = new DAL.Connector();
                conn.execNonQuery(query);
            }
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaHopDong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
        }
    }
}
