﻿using QuanLyNhanSu.DATA;
using QuanLyNhanSu.ENTITY;
using System;
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
using QuanLyNhanSu.DATA.AddData;
using QuanLyNhanSu.DAL;

namespace QuanLyNhanSu.GUI
{
    public partial class frmNhanSu : Form
    {
        AddNhanVien addNhanVien = new AddNhanVien();
        public frmNhanSu()
        {
            InitializeComponent();
        }
        bool kt;
        public void lockControl()
        {
            txtBacLuong.Enabled = false;
            txtDanToc.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtMaCV.Enabled = false;
            txtMaNV.Enabled = false;
            txtMaPB.Enabled = false;
            txtMaTDHV.Enabled = false;
            txtQuocTich.Enabled = false;
            txtSDT.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            dtNgaySinh.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        public void openControl()
        {
            txtBacLuong.Enabled = true;
            txtDanToc.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtMaCV.Enabled = true;
            txtMaNV.Enabled = true;
            txtMaPB.Enabled = true;
            txtMaTDHV.Enabled = true;
            txtQuocTich.Enabled = true;
            txtSDT.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            dtNgaySinh.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaNV.Focus();
            kt = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            lsvNhanVien.FullRowSelect = true;
            loadList();
        }

        private void loadList()
        {
            lsvNhanVien.Items.Clear();
            try
            {
                DAL.Connect sql = new Connect();
                SqlDataReader dr = sql.execCommand("Select * from NHANVIEN");
                while (dr.Read())
                {//ok
                    addList(dr);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["MaNV"].ToString();
            item.SubItems.Add(dr["HoTen"].ToString());
            item.SubItems.Add(dr["GioiTinh"].ToString());
            item.SubItems.Add(dr["NgaySinh"].ToString());
            item.SubItems.Add(dr["DiaChi"].ToString());
            item.SubItems.Add(dr["DanToc"].ToString());
            item.SubItems.Add(dr["QuocTich"].ToString());
            item.SubItems.Add(dr["SDT"].ToString());
            item.SubItems.Add(dr["MaPB"].ToString());
            item.SubItems.Add(dr["MaCV"].ToString());
            item.SubItems.Add(dr["MaTDHV"].ToString());
            item.SubItems.Add(dr["BacLuong"].ToString());
            lsvNhanVien.Items.Add(item);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            string _gioiTinh = rdbNam.Checked ? "Nam" : "Nu";
            NhanVien nhanVien = new NhanVien(txtMaNV.Text, txtHoTen.Text, _gioiTinh, dtNgaySinh.Value, txtDiaChi.Text,
                                        txtDanToc.Text, txtQuocTich.Text, txtSDT.Text, txtMaPB.Text, txtMaCV.Text,
                                        txtMaTDHV.Text, txtBacLuong.Text);
            if (kt==true)
            {
                if (txtMaNV.Text == null || txtHoTen.Text == null || txtMaCV.Text == null || txtMaTDHV.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addNhanVien.AddProc(nhanVien);
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
                //    editThongTinNhanVien.ExcuteProc(nhanVien);
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Sửa thông tin nhân viên không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                NhanVien_Controller nhanVien_Controller = new NhanVien_Controller();
                nhanVien_Controller.EditNhanVien(nhanVien);
            }
            loadList();
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void lsvNhanVien_MouseClick(object sender, MouseEventArgs e)
        {
            //openControl();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaNV.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
            txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
            //gioi tinh
            string gioiTinh = lsvNhanVien.SelectedItems[0].SubItems[2].Text; 
            if (gioiTinh.Equals("Nam") || gioiTinh.Equals("nam"))
            {
                rdbNam.Checked = true;
                rdbNu.Checked = false;
            }
            else
            {
                rdbNam.Checked = false;
                rdbNu.Checked = true;
            }
            // ngay sinh
            //DateTime.ParseExact(myStr, "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture);
            try
            {
                dtNgaySinh.Value = DateTime.Parse(lsvNhanVien.SelectedItems[0].SubItems[3].Text);
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                txtDanToc.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;
                txtQuocTich.Text = lsvNhanVien.SelectedItems[0].SubItems[6].Text;
                txtSDT.Text = lsvNhanVien.SelectedItems[0].SubItems[7].Text;
                txtMaPB.Text = lsvNhanVien.SelectedItems[0].SubItems[8].Text;
                txtMaCV.Text = lsvNhanVien.SelectedItems[0].SubItems[9].Text;
                txtMaTDHV.Text = lsvNhanVien.SelectedItems[0].SubItems[10].Text;
                txtBacLuong.Text = lsvNhanVien.SelectedItems[0].SubItems[11].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        
        // sua thong tin bang nhan su - tall



        private void btnSua_Click(object sender, EventArgs e)
        {
            openControl();
            kt = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNhanVien.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = cmbKey.Text.Trim();
            string value = cmbValue.Text.Trim();
            string query;
            //cái hàm kết nối ô để đâu
            if(key.Equals("Mã nhân viên"))
            {
                query = "select * from NHANVIEN where MaNV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if(key.Equals("Họ tên"))
            {
                query = "select * from NHANVIEN where HoTen like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Giới tính"))
            {
                query = "select * from NHANVIEN where GioiTinh like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Địa chỉ"))
            {
                query = "select * from NHANVIEN where DiaChi like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Dân tộc"))
            {
                query = "select * from NHANVIEN where DanToc like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Quốc tịch"))
            {
                query = "select * from NHANVIEN where QuocTich like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from NHANVIEN where SDT like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }


        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadList();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from NHANVIEN where MaNV = '" + txtMaNV.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
            loadList();
        }
    }
}
