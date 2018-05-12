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
using QuanLyNhanSu.DATA; using QuanLyNhanSu.DATA.AddData;


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

            lsvLuong.Items.Clear();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
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
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvLuong.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
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
    }
}
