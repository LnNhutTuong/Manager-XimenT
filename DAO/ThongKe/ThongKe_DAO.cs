using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO.ThongKe
{
    public class ThongKe_DAO
    {
        public static DataTable ThongKeFull()
        {
            DataProvider dp = new DataProvider();
            string sql = @"    SELECT 
                                SUM(ct.Thanh_tien) as DoanhThu,
                                SUM(ct.So_Luong) as SoLuong
                            FROM DonHang as dh
                            JOIN CtDonHang as ct On dh.MaDH = ct.MaDH
                             WHERE  dh.TrangThai = '2'";

            SqlCommand cmd = new SqlCommand(sql);

            return dp.TruyVanLayDuLieu(cmd);
        }

        public static DataTable ThongKeTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            DataProvider dp = new DataProvider();
            string sql = @"SELECT 
                                CAST(dh.NgayTao AS DATE) as Ngay, 
                                SUM(ct.Thanh_tien) as DoanhThu,
                                SUM(ct.So_Luong) as SoLuong
                            FROM DonHang as dh
                            JOIN CtDonHang as ct On dh.MaDH = ct.MaDH
                            WHERE CAST(dh.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay and dh.TrangThai = '2'
                            GROUP BY CAST(dh.NgayTao AS DATE)
                            ORDER BY Ngay ASC";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", denNgay);

            return dp.TruyVanLayDuLieu(cmd);
        }

        public static DataTable LayDonHangTheoTrangThai(int trangThai)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"select Count(MaDH) as SoDonHang from DonHang where TrangThai = @TrangThai");

            cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = trangThai;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable TongSoSanPham()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select sum(sp.SoLuongTon) as Conlai, sum(ct.So_Luong) as daban ,sum(sp.SoLuongTon + ct.So_Luong) as TongSoLuong
                                                from SanPham as sp 
                                                Join CtDonHang as ct On ct.MaSP = sp.MaSP
                                                where sp.MaSP = ct.MaSP");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable TongSoThuongHieu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaTH) as TongSoThuongHieu from  ThuongHieu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable TongSoDanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaDM) as TongSoDanhMuc from  DanhMuc");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable TongSoTienNhapSP()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Sum(GiaNhap) as GiaNhap from SanPham");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable LoiNhuan()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  select sum(dh.TongTien) - sum(sp.GiaNhap) as LoiNhuan from DonHang as dh 
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                Join SanPham as sp on ct.MaSP = sp.MaSP
                                                Where dh.TrangThai = '2'");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table; 
        }

        public static DataTable ThongKeTheoThang()
        {
            DataProvider dp = new DataProvider();

            string sql = @"SELECT 
                                MONTH(dh.NgayTao) AS Thang, 
                                YEAR(dh.NgayTao) AS Nam, 
                                SUM(ct.Thanh_tien) AS DoanhThu, 
                                SUM(ct.So_Luong) AS SoLuongSanPham
                           FROM DonHang AS dh
                           JOIN CtDonHang AS ct ON dh.MaDH = ct.MaDH
                           GROUP BY MONTH(dh.NgayTao), YEAR(dh.NgayTao)
                           ORDER BY Nam ASC, Thang ASC";

            SqlCommand cmd = new SqlCommand(sql);

            return dp.TruyVanLayDuLieu(cmd);
        }
    }
}

