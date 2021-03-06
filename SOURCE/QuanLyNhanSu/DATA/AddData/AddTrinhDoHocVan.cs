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
    class AddTrinhDoHocVan
    {
        public void AddProc(TrinhDoHocVan trinhdohocvan)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TRINHDOHOCVAN(MaTDHV, TenTDHV, ChuyenNganhHoc) values (@MaTDHV, @TenTDHV, @ChuyenNganhHoc)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaTDHV", SqlDbType.Char, 10)).Value = trinhdohocvan.MaTDHV;
                cmd.Parameters.Add(new SqlParameter("@TenTDHV", SqlDbType.Text)).Value = trinhdohocvan.TenTDHV;
                cmd.Parameters.Add(new SqlParameter("@ChuyenNganhHoc", SqlDbType.Text)).Value = trinhdohocvan.ChuyenNganhHoc;

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
