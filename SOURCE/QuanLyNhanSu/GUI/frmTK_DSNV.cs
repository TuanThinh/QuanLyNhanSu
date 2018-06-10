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
    public partial class frmTK_DSNV : Form
    {
        public frmTK_DSNV()
        {
            InitializeComponent();
        }
        public SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True");
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    //cn.ConnectionString = @"Data Source=.;Initial Catalog=NHANVIEN;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {

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

    private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = HienDL("select * from NHANVIEN");
        }
    }
}
