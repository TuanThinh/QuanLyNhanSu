using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.frmNhanSu frm = new frmNhanSu();
            frm.ShowDialog();
        }

        private void chứcVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmChucVu frm = new frmChucVu();
            frm.ShowDialog();
        }

        private void phòngBanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmPhongBan frm = new frmPhongBan();
            frm.ShowDialog();
        }

        private void lươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmLuong frm = new frmLuong();
            frm.ShowDialog();
        }

        private void trìnhĐộHọcVấnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTrinhDoHocVan frm = new frmTrinhDoHocVan();
            frm.ShowDialog();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.frmHopDongLaoDong frm = new frmHopDongLaoDong();
            frm.ShowDialog();
        }

        private void khenThưởngKỷLuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmKhenThuongKyLuat frm = new frmKhenThuongKyLuat();
            frm.ShowDialog();
        }

        private void sốQĐKhenThưởngKỷLuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmSoQDKhenThuongKyLuat frm = new frmSoQDKhenThuongKyLuat();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_NV_PB frm = new frmTK_NV_PB();
            frm.ShowDialog();
        }

        private void nhânViênChứcVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_NV_CV frm = new frmTK_NV_CV();
            frm.ShowDialog();
        }

        private void nhânViênTrìnhĐộHọcVấnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_NV_TDHV frm = new frmTK_NV_TDHV();
            frm.ShowDialog();
        }

        private void nhânViênSắpHếtHạnHợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_NV_HD frm = new frmTK_NV_HD();
            frm.ShowDialog();
        }

        private void nhânViênĐượcKhenThưởngKỷLuậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_NV_KT_KL frm = new frmTK_NV_KT_KL();
            frm.ShowDialog();
        }

        private void danhSáchNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.frmTK_DSNV frm = new frmTK_DSNV();
            frm.ShowDialog();
        }

        private void mnuHT_DoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void mnuHT_DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
        }

        private void mnuHT_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmNguoiDung frm = new frmNguoiDung();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string query = "select Them, Sua, Xoa, CreateLogin from NGUOIDUNG where MaNV = '" + DAL.NguoiDung_Controller.MaNV + "' and MatKhau = '" + DAL.NguoiDung_Controller.matkhau + "'";
            DAL.Connect sqlConn = new DAL.Connect();
            sqlConn.openConnection();
            SqlDataReader dr = sqlConn.execCommand(query);
            while (dr.Read())
            {
                if (dr["CreateLogin"].ToString().Equals("True"))
                {
                    mnuHT_QLND.Enabled = true;
                }
                else
                {
                    mnuHT_QLND.Enabled = false;
                }

                if (dr["Them"].ToString().Equals("False") && dr["Sua"].ToString().Equals("False") && dr["Xoa"].ToString().Equals("False"))
                {
                    mnuDM.Enabled = false;
                }
                else
                {
                    mnuDM.Enabled = true;
                }
            }
        }
    }
}
