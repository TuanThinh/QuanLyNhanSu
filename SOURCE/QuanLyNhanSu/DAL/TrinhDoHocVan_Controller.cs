using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAL
{
    class TrinhDoHocVan_Controller : Connect
    {
        public void EditTrinhDoHocVan(TrinhDoHocVan trinhDoHocVan)
        {
            try
            {
                openConnection();
                string query = "update TRINHDOHOCVAN set TenTDHV = @ten, ChuyenNganhHoc = @chuyennganh where MaTDHV = @matdhv";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.AddWithValue("@matdhv", trinhDoHocVan.MaTDHV);
                cmd.Parameters.AddWithValue("@ten", trinhDoHocVan.TenTDHV);
                cmd.Parameters.AddWithValue("@chuyennganh", trinhDoHocVan.ChuyenNganhHoc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
