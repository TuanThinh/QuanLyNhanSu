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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMKCu.Text.Trim().Equals(DAL.NguoiDung_Controller.matkhau))
            {
                if (txtMKMoi.Text.Trim().Equals(txtXacNhan.Text.Trim()))
                {
                    string query = "update NGUOIDUNG set MatKhau = '" + txtMKMoi.Text.Trim() + "' where MaNV = '" + DAL.NguoiDung_Controller.MaNV + "'";
                    DAL.Connect conn = new DAL.Connect();
                    conn.openConnection();
                    SqlCommand cmd = new SqlCommand(query, conn.Conn);
                    cmd.ExecuteNonQuery();
                    DAL.NguoiDung_Controller.matkhau = txtMKMoi.Text.Trim();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtXacNhan.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMKCu.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
