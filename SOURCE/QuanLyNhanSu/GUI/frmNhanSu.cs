﻿using QuanLyNhanSu.DATA; using QuanLyNhanSu.ENTITY; using System; using System.Collections.Generic; using System.ComponentModel; using System.Data; using System.Drawing; using System.Globalization; using System.Linq; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; using System.Data.SqlClient;  namespace QuanLyNhanSu.GUI {     public partial class frmNhanSu : Form     {         EditThongTinNhanVien editThongTinNhanVien = new EditThongTinNhanVien();          public frmNhanSu()         {             InitializeComponent();         }          public void lockControl()         {             txtBacLuong.Enabled = false;             txtDanToc.Enabled = false;             txtDiaChi.Enabled = false;             txtHoTen.Enabled = false;             txtMaCV.Enabled = false;             txtMaNV.Enabled = false;             txtMaPB.Enabled = false;             txtMaTDHV.Enabled = false;             txtQuocTich.Enabled = false;             txtSDT.Enabled = false;             rdbNam.Enabled = false;             rdbNu.Enabled = false;             dtNgaySinh.Enabled = false;             btnHuy.Enabled = false;             btnLuu.Enabled = false;             btnSua.Enabled = false;             btnXoa.Enabled = false;             btnThem.Enabled = true;         }          public void openControl()         {             txtBacLuong.Enabled = true;             txtDanToc.Enabled = true;             txtDiaChi.Enabled = true;             txtHoTen.Enabled = true;             txtMaCV.Enabled = true;             txtMaNV.Enabled = true;             txtMaPB.Enabled = true;             txtMaTDHV.Enabled = true;             txtQuocTich.Enabled = true;             txtSDT.Enabled = true;             rdbNam.Enabled = true;             rdbNu.Enabled = true;             dtNgaySinh.Enabled = true;             btnHuy.Enabled = true;             btnLuu.Enabled = true;         }          private void btnThem_Click(object sender, EventArgs e)         {             openControl();             txtMaNV.Focus();         }          private void frmNhanSu_Load(object sender, EventArgs e)         {             lockControl();             lsvNhanVien.FullRowSelect = true;
            loadList();         }          private void loadList()
        {
            lsvNhanVien.Items.Clear();
            try             {                 SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");                 SqlCommand com = new SqlCommand("Select *from NHANVIEN", conn);                 conn.Open();                 SqlDataReader dr = com.ExecuteReader();                 while (dr.Read())                 {//ok
                    addList(dr);                 }             }             catch (Exception ex)             {                  throw;             }
        }          private void addList(SqlDataReader dr)
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
        }          private void btnLuu_Click(object sender, EventArgs e)         {                     }                  private void btnHuy_Click(object sender, EventArgs e)         {             lockControl();         }          private void lsvNhanVien_MouseClick(object sender, MouseEventArgs e)         {             openControl();              btnSua.Enabled = true;              txtMaNV.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;             txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;             //gioi tinh             string gioiTinh = lsvNhanVien.SelectedItems[0].SubItems[2].Text;              if (gioiTinh.Equals("Nam") || gioiTinh.Equals("nam"))             {                 rdbNam.Checked = true;                 rdbNu.Checked = false;             }             else             {                 rdbNam.Checked = false;                 rdbNu.Checked = true;             }             // ngay sinh             //DateTime.ParseExact(myStr, "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture);             dtNgaySinh.Value = DateTime.ParseExact(lsvNhanVien.SelectedItems[0].SubItems[3].Text, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;             txtDanToc.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;             txtQuocTich.Text = lsvNhanVien.SelectedItems[0].SubItems[6].Text;             txtSDT.Text = lsvNhanVien.SelectedItems[0].SubItems[7].Text;             txtMaPB.Text = lsvNhanVien.SelectedItems[0].SubItems[8].Text;             txtMaCV.Text = lsvNhanVien.SelectedItems[0].SubItems[9].Text;             txtMaTDHV.Text = lsvNhanVien.SelectedItems[0].SubItems[10].Text;             txtBacLuong.Text = lsvNhanVien.SelectedItems[0].SubItems[11].Text;              editThongTinNhanVien.MaNhanVienCu = txtMaNV.Text;          }                  // sua thong tin bang nhan su - tall            private void btnSua_Click(object sender, EventArgs e)         {             lockControl();             //dtNgaySinh.Value = DateTime.ParseExact(lsvNhanVien.SelectedItems[0].SubItems[3].Text, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);             string _gioiTinh = lsvNhanVien.SelectedItems[0].SubItems[2].Text;             if (_gioiTinh.Equals("Nam") || _gioiTinh.Equals("nam"))             {                 rdbNam.Checked = true;                 rdbNu.Checked = false;             }             else             {                 rdbNam.Checked = false;                 rdbNu.Checked = true;             }             NhanVien nhanVien = new NhanVien(txtMaNV.Text, txtHoTen.Text, _gioiTinh, dtNgaySinh.Value, txtDiaChi.Text,                                          txtDanToc.Text, txtQuocTich.Text, txtSDT.Text, txtMaPB.Text, txtMaCV.Text,                                          txtMaTDHV.Text, txtBacLuong.Text);             try             {                 editThongTinNhanVien.ExcuteProc(nhanVien);             }             catch (Exception _e)             {                 MessageBox.Show("Sửa thông tin nhân viên không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);             }         }
// đây đoạn này..........
//tim kiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvNhanVien.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
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
        //dc rồi đó ok cảm ơn ô, để t làm nốt mấy form kia ok

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
    } } 