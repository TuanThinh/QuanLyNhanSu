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


namespace QuanLyNhanSu.GUI
{
    public partial class frmTK_NV_CV : Form
    {
        public frmTK_NV_CV()
        {
            InitializeComponent();
        }
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                //    cn.ConnectionString = @"Data Source=HIEP\SQLEXPRESS;Initial Catalog=NHANVIEN;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }

        //Phương thức truy vấn để xem dữ liệu
        public DataTable HienDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;

            Ngatketnoi();
        }

        //Phương thức truy vấn dữ liệu: Insert, Update, Delete
        public SqlCommand ThucThiDl(string sql)
        {
            Ketnoi();

            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            return cm;

            Ngatketnoi();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void BtnXong_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTen as N'Họ và Tên',A.MaCV as N'Mã Chức Vụ',B.TenCV as N'Tên Chức Vụ' from NHANVIEN  A inner join CHUCVU  B on A.MaCV = B.MaCV and B.MaCV  Like '%" + txtKeyValue.Text + "%'");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnXong_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTen as N'Họ và Tên',A.MaCV as N'Mã Chức Vụ',B.TenCV as N'Tên Chức Vụ' from NHANVIEN  A inner join CHUCVU  B on A.MaCV = B.MaCV and B.MaCV  Like '%" + txtKeyValue.Text + "%'");
        }
    }
}
