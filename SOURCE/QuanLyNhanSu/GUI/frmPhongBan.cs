﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.GUI
{
    public partial class frmPhongBan : Form
    {
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
            lockControl();
            DAL.NguoiDung_Controler nd = new DAL.NguoiDung_Controler();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaPB.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kt==false)
            {
                string query = "delete from PHONGBAN where MaPB = '" + txtMaPB.Text.Trim() + "'";
                DAL.Connector conn = new DAL.Connector();
                conn.execNonQuery(query);
            }
            lockControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            kt = false;
        }
    }
}
