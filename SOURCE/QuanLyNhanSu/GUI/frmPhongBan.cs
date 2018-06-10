using System.Collections.Generic;
using System.ComponentModel;
using QuanLyNhanSu.DATA;
using QuanLyNhanSu.DATA.AddData;
using QuanLyNhanSu.ENTITY;
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
using QuanLyNhanSu.DAL;

namespace QuanLyNhanSu.GUI

{
    public partial class frmPhongBan : Form
    {
        AddPhongBan addphongban = new AddPhongBan();
        bool kt;
        public frmPhongBan()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtDiaChi.Enabled = false;
            txtMaPB.Enabled = false;
            txtSDT.Enabled = false;
            txtTenPB.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        public void openControl()
        {
            txtDiaChi.Enabled = true;
            txtMaPB.Enabled = true;
            txtSDT.Enabled = true;
            txtTenPB.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            lsvPhongBan.Items.Clear();
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
                SqlCommand com = new SqlCommand("Select *from PHONGBAN", conn);
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
            item.Text = dr["MaPB"].ToString();
            item.SubItems.Add(dr["TenPB"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            lsvPhongBan.Items.Add(item);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaPB.Focus();
            kt = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            PhongBan phongban = new PhongBan(txtMaPB.Text, txtTenPB.Text, txtDiaChi.Text, txtSDT.Text);
            txtMaPB.Focus();
            if (kt==true)
            {
                if (txtMaPB.Text == null || txtTenPB.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addphongban.AddProc(phongban);
                        MessageBox.Show("Lưu Thông tin Thành công!");
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show("Thêm thông tin không thành công!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                //if (txtMaPB.Text == null || txtTenPB.Text == null)
                //{
                //    MessageBox.Show("Bạn chưa điền đủ thông tin cần thiết!");
                //}
                //else
                //{
                //    try
                //    {
                //        editThongTinPhongBan.ExcuteProc(phongban);
                //        MessageBox.Show("Lưu Thông tin Thành công!");
                //    }
                //    catch (Exception _e)
                //    {
                //        MessageBox.Show("Sửa thông tin phòng ban không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                PhongBan_Controller phongBan_Controller = new PhongBan_Controller();
                phongBan_Controller.EditPhongBan(phongban);
            }


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            openControl();
            kt = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void lsvPhongBan_MouseClick(object sender, MouseEventArgs e)
        {
            //openControl();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaPB.Text = lsvPhongBan.SelectedItems[0].SubItems[0].Text;
            txtTenPB.Text = lsvPhongBan.SelectedItems[0].SubItems[1].Text;
            txtDiaChi.Text = lsvPhongBan.SelectedItems[0].SubItems[2].Text;
            txtSDT.Text = lsvPhongBan.SelectedItems[0].SubItems[3].Text;

        }
        private void lsvPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            lsvPhongBan.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã phòng ban"))
            {
                query = "select * from PHONGBAN where MaPB like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Tên phòng ban"))
            {
                query = "select * from PHONGBAN where TenPB like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Địa chỉ"))
            {
                query = "select * from PHONGBAN where DiaChi like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from PHONGBAN where SDT like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from PHONGBAN where MaPB = '" + txtMaPB.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
        }
    }
}
