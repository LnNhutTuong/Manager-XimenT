using System;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
namespace DAO
{
    public class NhanVien_DAO
    {
        public static DataTable DanhSachNhanVien()
        {
            DataProvider dp = new DataProvider();    

            SqlCommand cmd = new SqlCommand(@" SELECT MaNV, TenNV, Ten_dang_nhap, Mat_khau, nv.MaCV, HinhAnh , TenCV 
                            FROM (select * from NhanVien) as nv
                            Join (select * from ChucVu) as cv
                            On nv.MaCV = cv.MaCV");
            
            DataTable table = dp.TruyVanLayDuLieu(cmd);
       
            return table;
        }

        public static List<string> DanhSachMaNV()
        {
            List<string> dsMaNV = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaNV From NhanVien");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaNV.Add(row["MaNV"].ToString());
            }
            
            return dsMaNV;
        }

        public static bool ThemNhanVien(NhanVien_DTO nv)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@" Insert Into NhanVien
                            Values(@MaNV, @TenNV, @MaCV , @Ten_dang_nhap, @Mat_khau , @HinhAnh)");
                
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar,5).Value = nv.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar, 100).Value = nv.TenNV;
            cmd.Parameters.Add("@MaCV", SqlDbType.VarChar, 5).Value = nv.MaCV;
            cmd.Parameters.Add("@Ten_dang_nhap", SqlDbType.VarChar, 30).Value = nv.Ten_dang_nhap;
            cmd.Parameters.Add("@Mat_khau", SqlDbType.VarChar, 50).Value = nv.Mat_khau;
            cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = (object)nv.HinhAnh ?? DBNull.Value;
            
            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable TimNhanVienTheoMa (string maNV)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  SELECT MaNV, TenNV, Ten_dang_nhap, Mat_khau , nv.MaCV, TenCV, HinhAnh
                                                FROM NhanVien as nv
                                                Join ChucVu as cv
                                                On nv.MaCV = cv.MaCV 
                                                Where MaNV = @MaNV");

            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar,5).Value = maNV;


            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }


        public static bool SuaNhanVien (NhanVien_DTO nv, string maNVcu )
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@" Update NhanVien
                                                Set MaNV = @MaNVMoi,
                                                    TenNV = @TenNV,
                                                    MaCV = @MaCV,
                                                    Ten_dang_nhap = @Ten_dang_nhap,
                                                    Mat_khau = @Mat_khau,
                                                    HinhAnh = @HinhAnh
                                                Where MaNV = @MaNVCu");
            cmd.Parameters.Add("@MaNVMoi", SqlDbType.VarChar, 5).Value = nv.MaNV;
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar, 100).Value = nv.TenNV;
            cmd.Parameters.Add("@MaCV", SqlDbType.VarChar, 5).Value = nv.MaCV;
            cmd.Parameters.Add("@Ten_dang_nhap", SqlDbType.VarChar, 30).Value = nv.Ten_dang_nhap;
            cmd.Parameters.Add("@Mat_khau", SqlDbType.VarChar, 50).Value = nv.Mat_khau;
            cmd.Parameters.Add("@MaNVCu", SqlDbType.VarChar, 5).Value = maNVcu;
            cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = (object)nv.HinhAnh ?? DBNull.Value;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaNhanVien(NhanVien_DTO nv)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From NhanVien Where MaNV = @MaNV ");

            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = nv.MaNV;

            int k = dp.TruyVanKhongLayDuLieu(cmd);

            return k > 0;
        }
    }
}
