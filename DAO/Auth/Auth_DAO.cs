using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DTO.Auth
{
    public class Auth_DAO
    {
        public static DataTable LayThongTin(string tenDangNhap)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select *, cv.TenCV from NhanVien as nv
                                                Join ChucVu as cv On cv.MaCV = nv.MaCV
                                                where Ten_dang_nhap = @tenDangNhap");

            cmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar, 30).Value = tenDangNhap;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Update NhanVien
                                            Set Mat_khau = @MatKhauMoi
                                            where Ten_dang_nhap = @tenDangNhap");

            cmd.Parameters.Add("@MatKhauMoi", SqlDbType.VarChar, 250).Value = BC.HashPassword(matKhauMoi);
            cmd.Parameters.Add("@tenDangNhap", SqlDbType.VarChar, 30).Value = tenDangNhap;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool SaoLuuDuLieu(string sDuongDan)
        {
            DataProvider dp = new DataProvider();

            string sTen = "QLNV_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".bak";

            string fullPath = Path.Combine(sDuongDan, sTen);

            SqlCommand cmd = new SqlCommand(
                "BACKUP DATABASE QlCuaHangXimenT TO DISK = @path"
            );
            cmd.Parameters.AddWithValue("@path", fullPath);

            dp.TruyVanKhongLayDuLieu(cmd);

            return true;
        }

        public static bool PhucHoiDuLieu(string sDuongDan)
        {
            DataProvider dp = new DataProvider();


            string sql = @"USE master;
            ALTER DATABASE QlCuaHangXimenT SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE QlCuaHangXimenT FROM DISK = N'" + sDuongDan + "'";;

            SqlCommand cmd = new SqlCommand(sql);

            dp.TruyVanKhongLayDuLieu(cmd);

            return true;


        }
    }
}
