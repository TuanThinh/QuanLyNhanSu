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
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        bool kt;

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            showList();
            lockControl();
        }
        public void lockControl()
        {
            txtMatKhau.Enabled = false;
            txtMaNV.Enabled = false;
            ckbSua.Enabled = false;
            ckbThem.Enabled = false;
            ckbXoa.Enabled = false;
            ckbAd.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            lsvNguoiDung.Enabled = true;
        }

        public void openControl()
        {
            txtMatKhau.Enabled = true;
            txtMaNV.Enabled = true;
            //txtXacNhan.Enabled = false;
            ckbSua.Enabled = true;
            ckbThem.Enabled = true;
            ckbXoa.Enabled = true;
            ckbAd.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            lsvNguoiDung.Enabled = false;
        }

        public void reset()
        {
            txtMaNV.ResetText();
            txtMatKhau.ResetText();
            //txtXacNhan.ResetText();
            ckbThem.Checked = false;
            ckbSua.Checked = false;
            ckbXoa.Checked = false;
        }
        private void showList()
        {
            //combobox.item.add();
            //combobox.selectedindex = 1
            string query = "select * from NGUOIDUNG";
            DAL.Connect conn = new DAL.Connect();
            conn.openConnection();
            SqlDataReader dr = conn.execCommand(query);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["MaNV"].ToString().Trim();
                item.SubItems.Add(dr["MatKhau"].ToString().Trim());
                item.SubItems.Add(dr["Them"].ToString().Trim());
                item.SubItems.Add(dr["Sua"].ToString().Trim());
                item.SubItems.Add(dr["Xoa"].ToString().Trim());
                item.SubItems.Add(dr["CreateLogin"].ToString().Trim());
                lsvNguoiDung.Items.Add(item);
            }

        }

        private void clearList()
        {
            lsvNguoiDung.Items.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            reset();
            //txtXacNhan.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
            openControl();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ENTITY.NguoiDung nd = new ENTITY.NguoiDung();
            nd.MaNV = txtMaNV.Text.Trim();
            DialogResult check = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                clearList();
                DAL.NguoiDung_Controller user = new DAL.NguoiDung_Controller();
                user.deleteNGUOIDUNG(nd);
                showList();
            }
            lockControl();
            reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            clearList();
            ENTITY.NguoiDung nd = new ENTITY.NguoiDung();
            nd.MaNV = txtMaNV.Text.Trim();
            nd.MatKhau = txtMatKhau.Text.Trim();
            nd.Them = ckbThem.Checked ? true : false;
            nd.Sua = ckbSua.Checked ? true : false;
            nd.Xoa = ckbXoa.Checked ? true : false;
            nd.Ad = ckbAd.Checked ? true : false;
            if (kt == true)
            {
                DAL.NguoiDung_Controller user = new DAL.NguoiDung_Controller();
                user.insertNGUOIDUNG(nd);
                showList();
            }
            else
            {
                DAL.NguoiDung_Controller user = new DAL.NguoiDung_Controller();
                user.updateNGUOIDUNG(nd);
                showList();
            }
            lockControl();
            reset();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void lsvNguoiDung_MouseClick(object sender, MouseEventArgs e)
        {
            if (lsvNguoiDung.SelectedItems.Count > 0)
            {

                txtMaNV.Text = lsvNguoiDung.SelectedItems[0].SubItems[0].Text;
                txtMatKhau.Text = lsvNguoiDung.SelectedItems[0].SubItems[1].Text;

                ckbThem.Checked = lsvNguoiDung.SelectedItems[0].SubItems[2].Text.Equals("True") ? true : false;
                ckbSua.Checked = lsvNguoiDung.SelectedItems[0].SubItems[3].Text.Equals("True") ? true : false;
                ckbXoa.Checked = lsvNguoiDung.SelectedItems[0].SubItems[4].Text.Equals("True") ? true : false;
                ckbAd.Checked = lsvNguoiDung.SelectedItems[0].SubItems[5].Text.Equals("True") ? true : false;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                //if (lsvNguoiDung.SelectedItems[0].SubItems[2].Text.Equals("True"))
                //{
                //    ckbThem.Checked = true;
                //}
            }
        }
    }
}
