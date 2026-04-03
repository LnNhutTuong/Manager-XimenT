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
        public static DataTable DoanhThuVaSoLuongSanPham()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select Sum(ct.Thanh_tien) as TongTien, sum(ct.So_Luong) as SoLuongSanPhamBanRa 
                                                from CtDonHang as ct
                                                join DonHang as dh On ct.MaDH = dh.MaDH
                                                Where dh.TrangThai = '2'");
            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
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

        public static DataTable DoanThuTungThang()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  select MONTH(dh.NgayTao) as Thang, YEAR(dh.NgayTao) as Nam, Sum(ct.Thanh_tien) as thanhTien
                                                from DonHang as dh
                                                Join CtDonHang as ct On dh.MaDH = ct.MaDH
                                                group by MONTH(dh.NgayTao), YEAR(dh.NgayTao)
                                                order by Thang, Nam");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable SoSanPhamBanTheoThang()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  select MONTH(dh.NgayTao) as Thang, YEAR(dh.NgayTao) as Nam, Sum(ct.So_Luong) as SoLuongSanPham
                                                from DonHang as dh
                                                Join CtDonHang as ct On dh.MaDH = ct.MaDH
                                                group by MONTH(dh.NgayTao), YEAR(dh.NgayTao)
                                                order by Thang, Nam");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
    }
}

