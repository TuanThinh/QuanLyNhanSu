﻿using QuanLyNhanSu.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyNhanSu.DATA.AddData
{
    class AddKhenThuong_KyLuat
    {
        public void AddProc(KhenThuongKyLuat KhenThuongKyLuat)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into KHENTHUONG_KYLUAT(MaNV, SoQD, ThoiGian) values (@MaNV, @SoQD, @ThoiGian)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.Char, 10)).Value = KhenThuongKyLuat.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@SoQD", SqlDbType.Char, 10)).Value = KhenThuongKyLuat.SoQuyetDinh;
                cmd.Parameters.Add(new SqlParameter("@ThoiGian", SqlDbType.Date)).Value = KhenThuongKyLuat.ThoiGian;

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
