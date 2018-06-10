using System;
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
    public partial class frmTrinhDoHocVan : Form
    {
        AddTrinhDoHocVan addTrinhdohocvan = new AddTrinhDoHocVan();
        public frmTrinhDoHocVan()
        {
            InitializeComponent();
        }
        bool kt;
        public void lockControl()
        {
            txtChuyenNganhHoc.Enabled = false;
            txtMaTDHV.Enabled = false;
            txtTenTDHV.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void openControl()
        {
            txtChuyenNganhHoc.Enabled = true;
            txtMaTDHV.Enabled = true;
            txtTenTDHV.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void frmTrinhDoHocVan_Load(object sender, EventArgs e)
        {
            lockControl();
            DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);
            loadList();
        }

        private void loadList()
        {
            lsvTrinhDoHocVan.Items.Clear();
            try
            {
                DAL.Connect sql = new Connect();
                SqlDataReader dr = sql.execCommand("Select *from TRINHDOHOCVAN");
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
            item.Text = dr["MaTDHV"].ToString();
            item.SubItems.Add(dr["TenTDHV"].ToString());
            item.SubItems.Add(dr["ChuyenNganhHoc"].ToString());
            lsvTrinhDoHocVan.Items.Add(item);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openControl();
            txtMaTDHV.Focus();
            kt = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lockControl();
            txtMaTDHV.Focus();
            TrinhDoHocVan trinhdohocvan = new TrinhDoHocVan(txtMaTDHV.Text, txtTenTDHV.Text, txtChuyenNganhHoc.Text);
            if (kt == true)
            {
                if (txtMaTDHV.Text == null || txtTenTDHV.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addTrinhdohocvan.AddProc(trinhdohocvan);
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
                TrinhDoHocVan_Controller trinhDoHocVan_Controller = new TrinhDoHocVan_Controller();
                trinhDoHocVan_Controller.EditTrinhDoHocVan(trinhdohocvan);
            }
            loadList();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lockControl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvTrinhDoHocVan.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã TĐHV"))
            {
                query = "select * from TRINHDOHOCVAN where MaTDHV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else if (key.Equals("Tên TĐHV"))
            {
                query = "select * from TRINHDOHOCVAN where TenTDHV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from TRINHDOHOCVAN where ChuyenNganhHoc like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            openControl();
            kt = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "delete from TRINHDOHOCVAN where MaTDHV = '" + txtMaTDHV.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
            loadList();
        }

        private void lsvTrinhDoHocVan_MouseClick(object sender, MouseEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaTDHV.Text = lsvTrinhDoHocVan.SelectedItems[0].SubItems[0].Text;
            txtTenTDHV.Text = lsvTrinhDoHocVan.SelectedItems[0].SubItems[1].Text;
            txtChuyenNganhHoc.Text = lsvTrinhDoHocVan.SelectedItems[0].SubItems[2].Text;
        }

        private void btnRf_Click(object sender, EventArgs e)
        {
            loadList();
        }
    }
}
