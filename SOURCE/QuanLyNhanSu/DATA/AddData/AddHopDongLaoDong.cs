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
    class AddHopDongLaoDong
    {
        public void AddProc(HopDongLaoDong HopDongLaoDong)
        {
             SqlConnection conn = new SqlConnection("Server=.;Database=QuanLyNhanSu;Integrated Security=true");

        try
        {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into HOPDONGLAODONG(MaHD, MaNV, LoaiHD, TuNgay, DenNgay) values (@MaHD, @MaNV, @LoaiHD, @TuNgay, @DenNgay)", conn);
                cmd.Parameters.Add(new SqlParameter("@MaHD", SqlDbType.Char, 10)).Value = HopDongLaoDong.MaHopDong;
                cmd.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.Char, 10)).Value = HopDongLaoDong.MaNhanVien;
                cmd.Parameters.Add(new SqlParameter("@LoaiHD", SqlDbType.Text)).Value = HopDongLaoDong.LoaiHopDong;
                cmd.Parameters.Add(new SqlParameter("@TuNgay", SqlDbType.Date)).Value = HopDongLaoDong.TuNgay;
                cmd.Parameters.Add(new SqlParameter("@DenNgay", SqlDbType.Date)).Value = HopDongLaoDong.DenNgay;

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
