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
using QuanLyNhanSu.DATA;

namespace QuanLyNhanSu.GUI
{
    public partial class frmTK_DSNV : Form
    {
        public frmTK_DSNV()
        {
            InitializeComponent();
        }
        private void frmTK_DSNV_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-NE70A7B\\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
                SqlCommand com = new SqlCommand("Select * from NHANVIEN");
                conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
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
                    item.SubItems.Add(dr["MaTDVH"].ToString());
                    item.SubItems.Add(dr["BacLuong"].ToString());
                    lsvNhanVien.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
