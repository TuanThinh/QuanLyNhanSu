using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DATA.AddData
{
    class AddSoQDKTKL
    {
       public void AddProc (SoQDKhenThuongKyLuat soQDKTKL)
        {
             SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into SOQUYETDINHKHENTHUONG_KYLUAT(SoQD, LyDo, HinhThuc) values (@SoQD, @LyDo, @HinhThuc)", conn);
                cmd.Parameters.Add(new SqlParameter("@SoQD", SqlDbType.Char, 10)).Value = soQDKTKL.SoQD;
                cmd.Parameters.Add(new SqlParameter("@LyDo", SqlDbType.Text)).Value = soQDKTKL.LyDo;
                cmd.Parameters.Add(new SqlParameter("@HinhThuc", SqlDbType.Text)).Value = soQDKTKL.HinhThuc;

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

