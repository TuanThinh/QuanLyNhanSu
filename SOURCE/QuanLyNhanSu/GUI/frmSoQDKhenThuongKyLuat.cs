using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; using QuanLyNhanSu.DATA.AddData; using QuanLyNhanSu.DATA.EditData; using QuanLyNhanSu.ENTITY;
using System.Data.SqlClient;

namespace QuanLyNhanSu.GUI
{
    public partial class frmSoQDKhenThuongKyLuat : Form
    {
        AddSoQDKTKL addSoQDKTKL = new AddSoQDKTKL();

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
            lsvSoQDKhenThuongKyLuat.Items.Clear();
            try             {                 SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");                 SqlCommand com = new SqlCommand("Select *from SOQUYETDINHKHENTHUONG_KYLUAT", conn);                 conn.Open();                 SqlDataReader dr = com.ExecuteReader();                 while (dr.Read())                 {                     addList(dr);                 }             }             catch (Exception ex)             {                  throw;             }
        }

        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["SoQD"].ToString();
            item.SubItems.Add(dr["LyDo"].ToString());
            item.SubItems.Add(dr["HinhThuc"].ToString());
            lsvSoQDKhenThuongKyLuat.Items.Add(item);
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
            SoQDKhenThuongKyLuat soQDKTKL = new SoQDKhenThuongKyLuat(txtSoQDKhenThuongKyLuat.Text, txtSoQDKhenThuongKyLuat.Text, txtHinhThuc.Text);             if (txtSoQDKhenThuongKyLuat.Text == null )             {                 MessageBox.Show("Bạn chưa điền đủ thông tin!");             }             else             {                 try                 {                     addSoQDKTKL.AddProc(soQDKTKL);                     MessageBox.Show("Lưu Thông tin Thành công!");                 }                 catch (Exception a)                 {                     new Exception("Error: " + a.Message);                     MessageBox.Show("Thêm thông tin không thành công!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);                 }             }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvSoQDKhenThuongKyLuat.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Số QĐ khen thưởng - kỷ luật"))
            {
                query = "select * from SOQUYETDINHKHENTHUONG_KYLUAT where SoQD like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Lý do"))
            {
                query = "select * from SOQUYETDINHKHENTHUONG_KYLUAT where LyDo like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from SOQUYETDINHKHENTHUONG_KYLUAT where HinhThuc like '" + value + "%'";
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
