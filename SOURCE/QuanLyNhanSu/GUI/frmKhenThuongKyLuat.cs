
using QuanLyNhanSu.ENTITY;
using System;
using QuanLyNhanSu.DATA;
using QuanLyNhanSu.DATA.AddData;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhanSu.DAL;

namespace QuanLyNhanSu.GUI
{
    public partial class frmKhenThuongKyLuat : Form
    {
      //  AddKhenThuong_KyLuat;
        AddKhenThuong_KyLuat addKhenThuong_KyLuat = new AddKhenThuong_KyLuat();
        public frmKhenThuongKyLuat()
        {
            InitializeComponent();
        }
        bool kt;
        public void lockControl()
        {
            txtMaNV.Enabled = false;
            txtSoQDKhenThuongKyLuat.Enabled = false;
            dtThoiGian.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtMaNV.Enabled = true;
            txtSoQDKhenThuongKyLuat.Enabled = true;
            dtThoiGian.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmKhenThuongKyLuat_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            lsvKhenThuongKyLuat.Items.Clear();

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
                SqlCommand com = new SqlCommand("Select *from KHENTHUONG_KYLUAT", conn);
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
            item.Text = dr["MaNV"].ToString();
            item.SubItems.Add(dr["SoQD"].ToString());
            item.SubItems.Add(dr["ThoiGian"].ToString());
            lsvKhenThuongKyLuat.Items.Add(item);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            KhenThuongKyLuat khenThuongKyLuat = new KhenThuongKyLuat(txtMaNV.Text, txtSoQDKhenThuongKyLuat.Text, dtThoiGian.Value);
            if (kt==true)
            {
                if (txtMaNV.Text == null || txtSoQDKhenThuongKyLuat.Text == null )
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addKhenThuong_KyLuat.AddProc(khenThuongKyLuat);
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
                //try
                //{
                //    editThongTinKhenThuongKyLuat.ExcuteProc(khenThuongKyLuat);
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Sửa thông tin khen thưởng kỷ luật không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                KhenThuongKyLuat_Controller khenThuongKyLuat_Controller = new KhenThuongKyLuat_Controller();
                khenThuongKyLuat_Controller.EditKhenThuongKyLuat(khenThuongKyLuat);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            kt = true;
            txtMaNV.Focus();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void lsvKhenThuongKyLuat_MouseClick(object sender, MouseEventArgs e)
        {
            //openControl();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaNV.Text = lsvKhenThuongKyLuat.SelectedItems[0].SubItems[0].Text;
            txtSoQDKhenThuongKyLuat.Text = lsvKhenThuongKyLuat.SelectedItems[0].SubItems[1].Text;
            dtThoiGian.Value = DateTime.ParseExact(lsvKhenThuongKyLuat.SelectedItems[2].SubItems[1].Text, "yyyy/MM/dd hh:mm:ss tt", CultureInfo.InvariantCulture);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            openControl();
            kt = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvKhenThuongKyLuat.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã nhân viên"))
            {
                query = "select * from KHENTHUONG_KYLUAT where MaNV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Số QĐ khen thưởng - kỷ luật"))
            {
                query = "select * from KHENTHUONG_KYLUAT where SoQD like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from KHENTHUONG_KYLUAT where ThoiGian like '" + value + "%'";
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
            string query = "delete from KHENTHUONG_KYLUAT where MaNV = '" + txtMaNV.Text.Trim() + "'and SoQD = '" + txtSoQDKhenThuongKyLuat.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
        }

        private void btnRf_Click(object sender, EventArgs e)
        {
            loadList();
        }
    }
}
