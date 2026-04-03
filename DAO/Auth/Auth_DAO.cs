using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


    }
}
