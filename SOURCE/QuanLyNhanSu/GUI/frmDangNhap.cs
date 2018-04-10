using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.Sql;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using System.Data.SqlClient;

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
            //try
            //{
                //RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                //String[] instances = (String[])rk.GetValue("InstalledInstances");
                //if (instances.Length > 0)
                //{
                //    foreach (String element in instances)
                //    {
                //        if (element == "MSSQLSERVER")
                //        {
                //            cmbServer.Items.Add(System.Environment.MachineName);
                //        }
                //        else
                //        {
                //            cmbServer.Items.Add(System.Environment.MachineName + @"\" + element);
                //        }
                //    }
                //}

                
                    //DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
                    //listBox1.ValueMember = "Name";
                    //listBox1.DataSource = dataTable;

                

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Không load được server \n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DAL.NguoiDung_Controler nd = new DAL.NguoiDung_Controler();
            int check = nd.checkLogin(txtTaiKhoan.Text, txtMatKhau.Text);
            if (check == 1)
            {
                DAL.NguoiDung_Controler.taikhoan = txtTaiKhoan.Text;
                DAL.NguoiDung_Controler.matkhau = txtMatKhau.Text;
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
