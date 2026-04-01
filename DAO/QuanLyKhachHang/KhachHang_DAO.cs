using DTO;
using DTO.QuanLyKhachHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.QuanLyKhachHang
{
    public class KhachHang_DAO
    {
        public static DataTable DanhSachKhachHang()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From KhachHang");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static List<string> DanhSachMaKH()
        {
            List<string> dsMaKH = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaKH From KhachHang");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaKH.Add(row["MaKH"].ToString());
            }

            return dsMaKH;
        }

        public static bool ThemKhanchHang(KhachHang_DTO kh)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Insert Into KhachHang
                                                Values (@MaKH, @TenKH, @Dien_Thoai, @Dia_Chi)");

            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 5).Value = kh.MaKH;
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 100).Value = kh.TenKH;
            cmd.Parameters.Add("@Dien_Thoai", SqlDbType.VarChar, 20).Value = kh.SoDienThoai;
            cmd.Parameters.Add("@Dia_Chi", SqlDbType.NVarChar, 100).Value = kh.DiaChi;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool SuaKhachHang(KhachHang_DTO kh, string maKhCu)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@" Update KhachHang
                                                Set TenKH = @TenKH,
                                                    Dia_Chi = @Dia_Chi,
                                                    Dien_Thoai = @Dien_Thoai   
                                                Where MaKH = @maKhCu");
            cmd.Parameters.Add("@maKhCu", SqlDbType.VarChar, 5).Value = maKhCu;
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 100).Value = kh.TenKH;
            cmd.Parameters.Add("@Dien_Thoai", SqlDbType.VarChar, 20).Value = kh.SoDienThoai;
            cmd.Parameters.Add("@Dia_Chi", SqlDbType.NVarChar, 100).Value = kh.DiaChi;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaKhachHang(string maKH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From KhachHang Where MaKH = @MaKH");

            cmd.Parameters.Add("@MaKh", SqlDbType.VarChar, 5).Value = maKH;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable TimKiemKhachHang(string tuKhoa)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select * From KhachHang Where MaKH Like  '%' + @tuKhoa + '%' or TenKH Like '%' + @tuKhoa + '%'");
            cmd.Parameters.Add("@tuKhoa", SqlDbType.NVarChar).Value = tuKhoa;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable Top3KhachHang()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  select top 3 with ties kh.*, Sum(ct.Thanh_tien) as TongTien
                                                from KhachHang as kh 
                                                Join DonHang as dh On dh.MaKH = kh.MaKH
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                group by kh.MaKH, kh.Dia_chi, kh.Dien_Thoai, kh.TenKH
                                                order by TongTien asc");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
    }
}
