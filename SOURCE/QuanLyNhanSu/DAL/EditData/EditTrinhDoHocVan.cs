using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DATA.EditData
{
    public class EditTrinhDoHocVan
    {
        public string MaTrinhDoHocVanCu { get; set; }

        public void ExcuteProc(TrinhDoHocVan trinhDoHocVan)

        {
            //SqlConnection conn = DBUtils.GetDBConnection();
            SqlConnection conn = new SqlConnection("Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true");
            // conn.ConnectionString = "Server=DEVSERVER-WIN7\\SQLEXPRESS;Database=ThucTapNhom_QuanLyNhanSu;Integrated Security=true";
            //Trusted_Connection=true";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("EditTrinhDoHocVan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@maTrinhDoHocVanCu", SqlDbType.Char, 10)).Value = this.MaTrinhDoHocVanCu;
                cmd.Parameters.Add(new SqlParameter("@maTrinhDoHocVan", SqlDbType.Char, 10)).Value = trinhDoHocVan.MaTrinhDoHocVan;
                cmd.Parameters.Add(new SqlParameter("@tenTrinhDoHocVan", SqlDbType.Text)).Value = trinhDoHocVan.TenTrinhDoHocVan;
                cmd.Parameters.Add(new SqlParameter("@chuyenNganhHoc", SqlDbType.Text)).Value = trinhDoHocVan.ChuyenNganhHoc;
                //excute proc
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
