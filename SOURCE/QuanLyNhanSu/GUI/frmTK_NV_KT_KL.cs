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
    public partial class frmTK_NV_KT_KL : Form
    {
        public frmTK_NV_KT_KL()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
           public SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
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
               if (comboBox1.SelectedValue.ToString().Equals ("Mã nhân viên"))
               {
                   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTen as N'Họ và Tên',B.SoQD as N'Số Quyết Định',B.ThoiGian as N'Thời Gian',C.LyDo as N'Lý Do',C.HinhThuc as N'Hình Thức' from (NHANVIEN  A inner join KHENTHUONG_KYLUAT B on A.MaNV = B.MaNV) inner join SOQUYETDINHKHENTHUONG_KYLUAT C on B.SoQD = C.SoQD and A.MaNV Like '%" + txtKeyValue.Text + "%'");
               }
               if (comboBox1.SelectedValue.ToString().Equals("Hình Thức"))
               {
                   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTenas N'Họ và Tên',B.SoQD as N'Số Quyết Định',B.ThoiGian as N'Thời Gian',C.LyDo as N'Lý Do',C.HinhThuc as N'Hình Thức' from (NHANVIEN  A inner join KHENTHUONG_KYLUAT B on A.MaNV = B.MaNV) inner join SOQUYETDINHKHENTHUONG_KYLUAT C on B.SoQD = C.SoQD and C.HinhThuc Like '%" + txtKeyValue.Text + "%'");
               }
           }

        private void btnXong_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Equals("Mã nhân viên"))
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTen as N'Họ và Tên',B.SoQD as N'Số Quyết Định',B.ThoiGian as N'Thời Gian',C.LyDo as N'Lý Do',C.HinhThuc as N'Hình Thức' from (NHANVIEN  A inner join KHENTHUONG_KYLUAT B on A.MaNV = B.MaNV) inner join SOQUYETDINHKHENTHUONG_KYLUAT C on B.SoQD = C.SoQD and A.MaNV Like '%" + txtKeyValue.Text + "%'");
            }
            if (comboBox1.Text.Trim().Equals("Hình Thức"))
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = HienDL("select A.MaNV as N'Mã NV',A.HoTenas N'Họ và Tên',B.SoQD as N'Số Quyết Định',B.ThoiGian as N'Thời Gian',C.LyDo as N'Lý Do',C.HinhThuc as N'Hình Thức' from (NHANVIEN  A inner join KHENTHUONG_KYLUAT B on A.MaNV = B.MaNV) inner join SOQUYETDINHKHENTHUONG_KYLUAT C on B.SoQD = C.SoQD and C.HinhThuc Like '%" + txtKeyValue.Text + "%'");
            }
        }
    }
}
