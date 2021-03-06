﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhanSu.ENTITY;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.DATA.AddData
{
    class AddPhongBan
    {
        public void AddProc(PhongBan phongban)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into PHONGBAN(MaPB, TenPB, DiaChi, SDT) values (@MaPB, @TenPB, @DiaChi, @SDT)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaPB", SqlDbType.Char, 10)).Value = phongban.MaPhongBan;
                cmd.Parameters.Add(new SqlParameter("@TenPB", SqlDbType.Text)).Value = phongban.TenPhongBan;
                cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.Text)).Value = phongban.DiaChi;
                cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Text)).Value = phongban.SDT;

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
