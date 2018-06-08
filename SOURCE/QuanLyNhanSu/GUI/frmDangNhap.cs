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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            int check = nd.checkLogin(txtMaNV.Text, txtMatKhau.Text);
            if (check == 1)
            {
                DAL.NguoiDung_Controller.MaNV = txtMaNV.Text;
                DAL.NguoiDung_Controller.matkhau = txtMatKhau.Text;
                this.Hide();
                GUI.frmMain main = new frmMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
