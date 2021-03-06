﻿using QuanLyNhanSu.DATA;
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
using System.Globalization;
using System.Data.SqlClient;
using QuanLyNhanSu.DAL;

namespace QuanLyNhanSu.GUI
{
    public partial class frmHopDongLaoDong : Form
    {
        AddHopDongLaoDong addhopdonglaodong = new AddHopDongLaoDong();
        
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }
        bool kt;
        public void lockControl()
        {
            txtLoaiHopDong.Enabled = false;
            txtMaHopDong.Enabled = false;
            txtMaNV.Enabled = false;
            dtNgayBatDau.Enabled = false;
            dtNgayKetThuc.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        public void openControl()
        {
            
            txtLoaiHopDong.Enabled = true;
            txtMaHopDong.Enabled = true;
            txtMaNV.Enabled = true;
            dtNgayBatDau.Enabled = true;
            dtNgayKetThuc.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            loadList();
        }

        private void loadList()
        {
            lsvHopDongLaoDong.Items.Clear();
            try
            {
                DAL.Connect sql = new Connect();
                SqlDataReader dr = sql.execCommand("Select * from HOPDONGLAODONG");
                while (dr.Read())
                {
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
            item.Text = dr["MaHD"].ToString();
            item.SubItems.Add(dr["MaNV"].ToString());
            item.SubItems.Add(dr["LoaiHD"].ToString());
            item.SubItems.Add(dr["TuNgay"].ToString());
            item.SubItems.Add(dr["DenNgay"].ToString());
            lsvHopDongLaoDong.Items.Add(item);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            HopDongLaoDong hopdonglaodong = new HopDongLaoDong(txtMaHopDong.Text, txtMaNV.Text, txtLoaiHopDong.Text, dtNgayBatDau.Value, dtNgayKetThuc.Value);
            if (kt==true)
            {
                if (txtMaHopDong.Text == null || txtLoaiHopDong.Text == null || txtMaNV.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addhopdonglaodong.AddProc(hopdonglaodong);
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
                //    editThongTinHopDongLaoDong.ExcuteProc(hopdonglaodong);
                //}
                //catch (Exception _e)
                //{
                //    MessageBox.Show("Sửa thông tin hợp đồng lao động không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                HopDongLaoDong_Controller hopDongLaoDong_Controller = new HopDongLaoDong_Controller();
                hopDongLaoDong_Controller.EditHopDongLaoDong(hopdonglaodong);
            }
            //txtMaHopDong.Focus();
            loadList();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            kt = true;
            txtMaHopDong.Focus();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void lsvHopDongLaoDong_MouseClick(object sender, MouseEventArgs e)
        {
            //openControl();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            try
            {
                txtMaHopDong.Text = lsvHopDongLaoDong.SelectedItems[0].SubItems[0].Text;
                txtMaNV.Text = lsvHopDongLaoDong.SelectedItems[0].SubItems[1].Text;
                txtLoaiHopDong.Text = lsvHopDongLaoDong.SelectedItems[0].SubItems[2].Text;
                dtNgayBatDau.Value = DateTime.ParseExact(lsvHopDongLaoDong.SelectedItems[0].SubItems[3].Text, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                dtNgayKetThuc.Value = DateTime.ParseExact(lsvHopDongLaoDong.SelectedItems[0].SubItems[4].Text, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {

            }
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
            lsvHopDongLaoDong.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã hợp đồng"))
            {
                query = "select * from HOPDONGLAODONG where MaHD like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Mã nhân viên"))
            {
                query = "select * from HOPDONGLAODONG where MaNV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Loại hợp đồng"))
            {
                query = "select * from HOPDONGLAODONG where LoaiHD like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Ngày bắt đầu"))
            {
                query = "select * from HOPDONGLAODONG where TuNgay like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from HOPDONGLAODONG where DenNgay like '" + value + "%'";
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
            string query = "delete from HOPDONGLAODONG where MaHD = '" + txtMaHopDong.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
            loadList();
        }

        private void btnRf_Click(object sender, EventArgs e)
        {
            loadList();
        }
    }
}
