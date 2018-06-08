using QuanLyNhanSu.DATA; using QuanLyNhanSu.DATA.AddData; using QuanLyNhanSu.DATA.EditData; using QuanLyNhanSu.ENTITY; using System; using System.Collections.Generic; using System.ComponentModel; using System.Data; using System.Drawing; using System.Linq; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; using System.Data.SqlClient;  namespace QuanLyNhanSu.GUI {     public partial class frmChucVu : Form     {         AddChucvu addChucVu = new AddChucvu();          EditThongTinChucVu editThongTinChucVu = new EditThongTinChucVu();        //  string[] data = { };         //ListViewItem listViewItem = new ListViewItem()         bool kt;          public frmChucVu()         {             InitializeComponent();         }                   public void lockControl()         {             txtMaCV.Enabled = false;             txtTenCV.Enabled = false;             btnHuy.Enabled = false;             btnLuu.Enabled = false;             btnSua.Enabled = false;             btnXoa.Enabled = false;             btnThem.Enabled = true;         }          public void openControl()         {             txtMaCV.Enabled = true;             txtTenCV.Enabled = true;             btnHuy.Enabled = true;             btnLuu.Enabled = true;         }          private void frmChucVu_Load(object sender, EventArgs e)         {             lockControl();             DAL.NguoiDung_Controller nd = new DAL.NguoiDung_Controller();
            nd.checkPermissions(btnThem, btnSua, btnXoa);             lsvChucVu.Items.Clear();             try             {                 SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");                 SqlCommand com = new SqlCommand("Select *from CHUCVU", conn);                 conn.Open();                 SqlDataReader dr = com.ExecuteReader();                 while (dr.Read())                 {                     addList(dr);                 }             }             catch (Exception ex)             {                  throw;             }                    }          private void btnThem_Click(object sender, EventArgs e)         {             openControl();             kt = true;             btnSua.Enabled = false;             btnXoa.Enabled = false;         }          private void btnLuu_Click(object sender, EventArgs e)         {             lockControl();             //txtMaCV.Focus();             ChucVu chucVu = new ChucVu(txtMaCV.Text, txtTenCV.Text);             if (kt == true)
            {
                if (txtMaCV.Text == null || txtTenCV.Text == null)
                {
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                }
                else
                {
                    try
                    {
                        addChucVu.AddProc(chucVu);
                        MessageBox.Show("Lưu Thông tin Thành công!");
                    }
                    catch (Exception a)
                    {
                        new Exception("Error: " + a.Message);
                        MessageBox.Show("Thêm thông tin không thành công!", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }             else
            {
                try
                {
                    editThongTinChucVu.ExcuteProc(chucVu);
                }
                catch (Exception _e)
                {
                    MessageBox.Show("Sửa thông tin chức vụ không thành công", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }         }          private void btnHuy_Click(object sender, EventArgs e)         {             lockControl();         }          private void lsvChucVu_MouseClick(object sender, MouseEventArgs e)         {             btnXoa.Enabled = true;             btnSua.Enabled = true;              txtMaCV.Text = lsvChucVu.SelectedItems[0].SubItems[0].Text;             txtTenCV.Text = lsvChucVu.SelectedItems[0].SubItems[1].Text;              editThongTinChucVu.MaChucVuCu = txtMaCV.Text;         }          private void btnSua_Click(object sender, EventArgs e)         {             openControl();             kt = false;             btnThem.Enabled = false;             btnXoa.Enabled = false;         }         private void addList(SqlDataReader dr)
        {
            ListViewItem item = new ListViewItem();
            item.Text = dr["MaCV"].ToString();
            item.SubItems.Add(dr["TenCV"].ToString());
            lsvChucVu.Items.Add(item);
        }         private void txtMaCV_TextChanged(object sender, EventArgs e)         {          }          private void lsvChucVu_SelectedIndexChanged(object sender, EventArgs e)         {                      }          private void groupBox1_Enter(object sender, EventArgs e)         {          }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvChucVu.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
            conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            string key = comboBox1.Text.Trim();
            string value = txtTimKiem.Text.Trim();
            string query;
            if (key.Equals("Mã chức vụ"))
            {
                query = "select * from CHUCVU where MaCV like '" + value + "%'";
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    addList(dr);
                }
            }
            else
            {
                query = "select * from CHUCVU where TenCV like '" + value + "%'";
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
            string query = "delete from CHUCVU where MaCV = '" + txtMaCV.Text.Trim() + "'";
            DAL.Connect conn = new DAL.Connect();
            conn.execNonQuery(query);
        }
    } } 