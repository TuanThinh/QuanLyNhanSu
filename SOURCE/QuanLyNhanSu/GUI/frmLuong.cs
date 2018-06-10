using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhanSu.DATA;
using QuanLyNhanSu.DATA.AddData;
using QuanLyNhanSu.ENTITY;
using QuanLyNhanSu.DAL;

namespace QuanLyNhanSu.GUI
{
    public partial class frmLuong : Form
    {
        AddLuong addLuong = new AddLuong();
        public frmLuong()
        {
            InitializeComponent();
        }
        bool kt;
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
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            lsvLuong.Items.Clear();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
                SqlCommand com = new SqlCommand("Select *from LUONG", conn);
                conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["BacLuong"].ToString();
            item.SubItems.Add(dr["LuongCB"].ToString());
            item.SubItems.Add(dr["HeSoLuong"].ToString());
            item.SubItems.Add(dr["HeSoPhuCap"].ToString());
            lsvLuong.Items.Add(item);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtBacLuong.Focus();
            kt = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            float bacluong = float.Parse(txtBacLuong.Text.Trim());
            float luongCB = float.Parse(txtLuongCB.Text.Trim());
            float hesoluong = float.Parse(txtHeSoLuong.Text.Trim());
            float hesophucap = float.Parse(txtHeSoPhuCap.Text.Trim());
            Luong luong = new Luong(bacluong, luongCB, hesoluong, hesophucap);
            if (kt==true)
            {
                if (txtBacLuong.Text == null || txtHeSoLuong.Text == null || txtLuongCB.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addLuong.AddProc(luong);
                        MessageBox.Show("Lưu Thông tin Thành công!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm thông tin không thành công!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Luong_Controller luong_Controller = new Luong_Controller();
                luong_Controller.EditLuong(luong);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvLuong.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Bậc lương"))
            {
                query = "select * from LUONG where BacLuong like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Lương cơ bản"))
            {
                query = "select * from LUONG where LuongCB like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Hệ số lương"))
            {
                query = "select * from LUONG where HeSoLuong like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from LUONG where HeSoPhuCap like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            openControl();
            kt = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from LUONG where BacLuong = '" + txtBacLuong.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
        }

        private void lsvLuong_MouseClick(object sender, MouseEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtBacLuong.Text = lsvLuong.SelectedItems[0].SubItems[0].Text;
            txtLuongCB.Text = lsvLuong.SelectedItems[0].SubItems[1].Text;
            txtHeSoLuong.Text = lsvLuong.SelectedItems[0].SubItems[2].Text;
            txtHeSoPhuCap.Text = lsvLuong.SelectedItems[0].SubItems[3].Text;
        }
    }
}
