using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ThongKe
{
    public class ThongKe_DAO
    {
        #region TRÊN TRÊN TRÊN TRÊN

            #region THỐNG KÊ FULL (Doanh Thu và số lượng SP đã bán )NHƯNG THEO THỜI GIAN CHỌN TỪ DATEPICK
            public static DataTable ThongKeTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
            {
                DataProvider dp = new DataProvider();

                SqlCommand cmd = new SqlCommand(@"SELECT SUM(ct.Thanh_tien) as DoanhThu,
                                    SUM(ct.So_Luong) as SoLuong
                                FROM DonHang as dh
                                JOIN CtDonHang as ct On dh.MaDH = ct.MaDH
                                WHERE CAST(dh.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay and dh.TrangThai = '2'");

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

            #region TỔNG SỐ LƯỢNG SẢN PHẨM 
            public static DataTable TongSoSanPham()
            {
                DataProvider dp = new DataProvider();

                SqlCommand cmd = new SqlCommand(@"  SELECT sum (sp.SoLuongTon + ct.So_Luong) as TongSoLuong
                                                    FROM SanPham as sp
                                                    JOIN CtDonHang as ct On sp.MaSP = ct.MaSP");

                DataTable table = dp.TruyVanLayDuLieu(cmd);

                return table;
            }
        #endregion

            #region TỔNG SỐ LƯỢNG SẢN PHẨM ĐÃ BÁN THEO THỜI GIAN
        public static DataTable TongSoSanPhamDaBanTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  SELECT sum (ct.So_Luong) as TongSoLuong
                                                    From CtDonHang as ct
                                                    Join DonHang as dh On ct.MaDH = dh.MaDH
                                                    WHERE CAST(dh.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay and dh.TrangThai = 2"); 
            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", denNgay);

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

            #region TỔNG SỐ THƯƠNG HIỆU
        public static DataTable TongSoThuongHieu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaTH) as TongSoLuong from  ThuongHieu");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

            #region TỔNG SỐ DANH MỤC
        public static DataTable TongSoDanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select Count(MaDM) as TongSoLuong from  DanhMuc");

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

        #region top 5 sản phẩm pro vip
        public static DataTable Top5SanPham()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  SELECT TOP 5 with ties sp.TenSP, SUM(ct.So_Luong) as SoLuong 
                                                FROM CtDonHang ct JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                                                GROUP BY sp.TenSP ORDER BY SoLuong DESC");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

        #region top 3 Danh Muc 
        public static DataTable Top3DanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  SELECT TOP 3 with ties dm.TenDM, SUM(ct.So_Luong) as SoLuong 
                                                FROM CtDonHang ct 
                                                JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                                                JOIN DanhMuc dm ON sp.MaDM = dm.MaDM
                                                GROUP BY dm.TenDM ORDER BY SoLuong DESC");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion

        #region top 3 Thuong hiu 
        public static DataTable Top3ThuongHieu()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  SELECT TOP 3 with ties th.TenTH, SUM(ct.So_Luong) as SoLuong 
                                                FROM CtDonHang ct 
                                                JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                                                JOIN ThuongHieu th ON sp.MaTH = th.MaTH
                                                GROUP BY th.TenTH ORDER BY SoLuong DESC");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
        #endregion
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

        #region Report
        public static TongHop_DTO LayThongKeTongHop(DateTime tuNgay, DateTime denNgay)
        {
            TongHop_DTO tongHop = new TongHop_DTO();

            // Doanh thu
            DataTable dtDoanhThu = ThongKe_DAO.ThongKeTheoKhoangThoiGian(tuNgay, denNgay);
            if (dtDoanhThu != null && dtDoanhThu.Rows.Count > 0)
            {
                tongHop.DoanhThu = dtDoanhThu.Rows[0]["DoanhThu"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dtDoanhThu.Rows[0]["DoanhThu"]);
                tongHop.SoLuongSanPhamDaBan = dtDoanhThu.Rows[0]["SoLuong"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(dtDoanhThu.Rows[0]["SoLuong"]);
            }

            // Đơn hàng thành công
            DataTable dtThanhCong = ThongKe_DAO.TongSoDonHangTheoThoiGian(2, tuNgay, denNgay);
            if (dtThanhCong != null && dtThanhCong.Rows.Count > 0)
            {
                tongHop.SoDonHangThanhCong = Convert.ToInt32(dtThanhCong.Rows[0]["SoDonHang"]);
            }

            // Đơn hàng bị hủy
            DataTable dtBiHuy = ThongKe_DAO.TongSoDonHangTheoThoiGian(3, tuNgay, denNgay);
            if (dtBiHuy != null && dtBiHuy.Rows.Count > 0)
            {
                tongHop.SoDonHangBiHuy = Convert.ToInt32(dtBiHuy.Rows[0]["SoDonHang"]);
            }

            tongHop.TuNgay = tuNgay;
            tongHop.DenNgay = denNgay;

            return tongHop;
        }
        #endregion
    }
}

