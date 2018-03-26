using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.GUI
{
    public partial class frmNguoiDung : Form
    {
        bool kt;

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        public void lockControl()
        {
            txtMatKhau.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtXacNhan.Enabled = false;
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
            txtTaiKhoan.Enabled = true;
            txtXacNhan.Enabled = false;
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
            txtTaiKhoan.ResetText();
            txtMatKhau.ResetText();
            txtXacNhan.ResetText();
            ckbThem.Checked = false;
            ckbSua.Checked = false;
            ckbXoa.Checked = false;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            DAL.NguoiDung_Model nd = new DAL.NguoiDung_Model();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            showList();
            lockControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kt = true;
            openControl();
            reset();
            txtXacNhan.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            clearList();
            ENTITY.NguoiDung nd = new ENTITY.NguoiDung();
            nd.TaiKhoan = txtTaiKhoan.Text.Trim();
            nd.MatKhau = txtMatKhau.Text.Trim();
            nd.Them = ckbThem.Checked ? true : false;
            nd.Sua = ckbSua.Checked ? true : false;
            nd.Xoa = ckbXoa.Checked ? true : false;
            nd.Ad = ckbAd.Checked ? true : false;
            if (kt == true)
            {
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
                user.insertNGUOIDUNG(nd);
                showList();
            }
            else
            {
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
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

        private void showList()
        {
            //combobox.item.add();
            //combobox.selectedindex = 1
            string query = "select * from NGUOIDUNG";
            DAL.Connector conn = new DAL.Connector();
            conn.openConnection();
            SqlDataReader dr = conn.execCommand(query);
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr["TaiKhoan"].ToString().Trim();
                item.SubItems.Add(dr["MatKhau"].ToString().Trim());
                item.SubItems.Add(dr["Them"].ToString().Trim());
                item.SubItems.Add(dr["Sua"].ToString().Trim());
                item.SubItems.Add(dr["Xoa"].ToString().Trim());
                item.SubItems.Add(dr["Ad"].ToString().Trim());
                lsvNguoiDung.Items.Add(item);
            }
            
        }

        private void clearList()
        {
            lsvNguoiDung.Items.Clear();
        }

        private void lsvNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNguoiDung.SelectedItems.Count > 0)
            {

                txtTaiKhoan.Text = lsvNguoiDung.SelectedItems[0].SubItems[0].Text;
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
            nd.TaiKhoan = txtTaiKhoan.Text.Trim();
            DialogResult check =  MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                clearList();
                DAL.NguoiDung_Model user = new DAL.NguoiDung_Model();
                user.deleteNGUOIDUNG(nd);
                showList();
            }
            lockControl();
            reset();
        }
    }
}
