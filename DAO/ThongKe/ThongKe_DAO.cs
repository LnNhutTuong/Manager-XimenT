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
        #region TRÊN TRÊN TRÊN TRÊN

            #region THỐNG KÊ FULL (Doanh Thu và số lượng SP đã bán )NHƯNG THEO THỜI GIAN CHỌN TỪ DATEPICK
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
            #endregion        

            #region TỔNG SỐ ĐƠN HÀNG FULL
            public static DataTable TongSoDonHangTheoThoiGian(int trangThai, DateTime tuNgay, DateTime denNgay)
            {
                DataProvider dp = new DataProvider();

                SqlCommand cmd = new SqlCommand(@"  Select Count(MaDH) as SoDonHang From DonHang as dh
                                                    Where TrangThai = @TrangThai 
                                                    and CAST(dh.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay");

                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = trangThai;
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

            DataTable table = dp.TruyVanLayDuLieu(cmd);

                return table;
            }
        #endregion

            #region TỔNG SỐ LƯỢNG SẢN PHẨM THEO THỜI GIAN
            public static DataTable TongSoSanPhamTheoThoiGian(DateTime tuNgay, DateTime denNgay)
            {
                DataProvider dp = new DataProvider();

                SqlCommand cmd = new SqlCommand(@"  Select sum(sp.SoLuongTon) as Conlai, sum(ct.So_Luong) as daban ,sum(sp.SoLuongTon + ct.So_Luong) as TongSoLuong
                                                    from SanPham as sp 
                                                    Join CtDonHang as ct On ct.MaSP = sp.MaSP
                                                    where sp.MaSP = ct.MaSP adn CAST(dh.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay");

                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                DataTable table = dp.TruyVanLayDuLieu(cmd);

                return table;
            }
            #endregion

        #endregion


        #region DƯỚI DƯỚI DƯỚI DƯỚI

            #region THỐNG KÊ FULL
        public static DataTable ThongKeDoanhThuFull()
            {
            DataProvider dp = new DataProvider();
            string sql = @" SELECT 
                                CONCAT(N'Quý ', DATEPART(QUARTER, dh.NgayTao), '/', YEAR(dh.NgayTao)) as Quy,                                
                                SUM(dh.TongTien) as DoanhThu
                            FROM DonHang as dh
                            WHERE dh.TrangThai = '2'
                            GROUP BY YEAR(dh.NgayTao), DATEPART(QUARTER, dh.NgayTao)
                            ORDER BY YEAR(dh.NgayTao) ASC, DATEPART(QUARTER, dh.NgayTao) ASC";

            SqlCommand cmd = new SqlCommand(sql);

            return dp.TruyVanLayDuLieu(cmd);
            }
            #endregion

            #region TỔNG SỐ ĐƠN HÀNG FULL
            public static DataTable LayDonHangFull(int trangThai)
            {
                DataProvider dp = new DataProvider();

                SqlCommand cmd = new SqlCommand(@" SELECT 
                                                        Count(dh.MaDH) as SoLuong
                                                    FROM DonHang as dh
                                                    WHERE dh.TrangThai = @TrangThai");

                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = trangThai;

                DataTable table = dp.TruyVanLayDuLieu(cmd);

                return table;
            }
            #endregion

        #endregion



        #region TỔNG SỐ LƯỢNG SẢN PHẨM ( LẪN BÁN VÀ CHƯA BÁN)
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
        #endregion

      
        #region TỔNG SỐ THƯƠNG HIỆU
        public static DataTable TongSoThuongHieu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaTH) as TongSoThuongHieu from  ThuongHieu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

        #region TỔNG SỐ DANH MỤC
        public static DataTable TongSoDanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaDM) as TongSoDanhMuc from  DanhMuc");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

        #region TỔNG SỐ TIỀN NHẬP SẢN PHẨM
        public static DataTable TongSoTienNhapSP()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Sum(GiaNhap) as GiaNhap from SanPham");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

        #region LỢI NHUẬN
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
        #endregion
    }
}

