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
    public partial class frmTK_NV_PB : Form
    {
        public frmTK_NV_PB()
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
        private void BtnXong_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTen as N'Họ và Tên',B.MaPB as N'Mã Nhân Viên',B.TenPB as N'Tên Phòng Ban' from NHANVIEN  A inner join PHONGBAN B on A.MaPB = B.MaPB and A.MaPB Like '%" + txtKeyValue.Text + "%'");
        }
    }
}
