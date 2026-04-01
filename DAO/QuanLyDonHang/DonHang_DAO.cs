using DTO;
using DTO.QuanLyDonHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAO.QuanLyDonHang
{
    public class DonHang_DAO
    {
        public static DataTable DanhSachDonHang()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@" Select dh.*, Sum(ct.Thanh_tien) as Tongtien, kh.TenKH
                                                from DonHang as dh
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                Join KhachHang as kh On dh.MaKH = kh.MaKH
                                                group by dh.MaDH, dh.MaKH, dh.MaNV, dh.NgayTao, dh.TrangThai, kh.TenKH");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }   

        public static List<string> DanhSachMaDH()
        {
            List<string> dsMaDH = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaDH From DonHang");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaDH.Add(row["MaDH"].ToString());
            }

            return dsMaDH;
        }

        public static bool ThemDonHang(DonHang_DTO dh, List<CtDonHang_DTO> ctdh)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmdDH = new SqlCommand(@"INSERT INTO DonHang (MaDH, MaKH, MaNV, NgayTao)
                                             VALUES (@MaDH, @MaKH, @MaNV, @NgayTao)");

            cmdDH.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = dh.MaDH;
            cmdDH.Parameters.Add("@MaKH", SqlDbType.VarChar, 5).Value = dh.MaKH;
            cmdDH.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = dh.MaNV;
            cmdDH.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = DateTime.Now;

            int stop = dp.TruyVanKhongLayDuLieu(cmdDH);
             
            if(stop < 0)
            {
                return false;
            }

            foreach (var ct in ctdh)
            {
                SqlCommand cmdCT = new SqlCommand(@"INSERT INTO CtDonHang (MaDH, MaSP, Don_gia, So_Luong, Thanh_tien) 
                                                   VALUES (@MaDH, @MaSP, @DonGia, @SoLuong, @ThanhTien)");
                cmdCT.Parameters.AddWithValue("@MaDH", dh.MaDH);
                cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP);
                cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmdCT.Parameters.AddWithValue("@ThanhTien", ct.SoLuong * ct.DonGia);
                dp.TruyVanKhongLayDuLieu(cmdCT);



                SqlCommand cmdSP = new SqlCommand(@"UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL 
                                                    WHERE MaSP = @MaSP AND SoLuongTon >= @SL");
                cmdSP.Parameters.AddWithValue("@SL", ct.SoLuong);
                cmdSP.Parameters.AddWithValue("@MaSP", ct.MaSP);
                dp.TruyVanKhongLayDuLieu(cmdSP);
            }

            return true;
        }

        public static DataTable DonHangTheoMa(string maDH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select dh.*, Sum(ct.Thanh_tien) as Tongtien, kh.TenKH, nv.TenNV
                                                from DonHang as dh
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                Join KhachHang as kh On kh.MaKH = dh.MaKH
                                                Join NhanVien as nv On nv.MaNV = dh.MaNV
                                                Where dh.MaDH = @MaDH
                                                group by dh.MaDH, dh.MaKH, dh.MaNV, dh.NgayTao, kh.TenKH, nv.TenNV,  dh.TrangThai");

            cmd.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = maDH;
            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static DataTable ChiTietDonHangTheoMa(string maDH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select ct.*, sp.TenSP From CtDonHang as ct
                                                Join SanPham as sp On sp.MaSP = ct.MaSP    
                                                Where MaDH = @MaDH");

            cmd.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = maDH;
            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static bool SuaDonHang(DonHang_DTO dh, List<CtDonHang_DTO> ctdh, string maDH)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmdDH = new SqlCommand(@"Update DonHang
                                                Set MaKH = @MaKH,
                                                    MaNV = @MaNV,
                                                    TrangThai = @TrangThai
                                                Where MaDH = @MaDH");

            cmdDH.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = maDH;
            cmdDH.Parameters.Add("@MaKH", SqlDbType.VarChar, 5).Value = dh.MaKH;
            cmdDH.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = dh.MaNV;
            cmdDH.Parameters.Add("@TrangThai", SqlDbType.Int).Value = dh.TrangThai;

            int stop = dp.TruyVanKhongLayDuLieu(cmdDH);

            if (stop < 0)
            {
                return false;
            }

            SqlCommand cmdHoanKho = new SqlCommand(@"Update SanPham
                                                     Set SoLuongTon = SoLuongTon + ct.So_Luong
                                                        From SanPham as sp 
                                                        Join CtDonHang as ct On sp.MaSP = ct.MaSP
                                                        Where ct.MaDH = @MaDH");
            cmdHoanKho.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = maDH;
            dp.TruyVanKhongLayDuLieu(cmdHoanKho);

            SqlCommand CmdClear = new SqlCommand(@"Delete From CtDonHang Where MaDH = @MaDH");
            CmdClear.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = maDH;
            dp.TruyVanKhongLayDuLieu(CmdClear);

            foreach (var ct in ctdh)
            {
                SqlCommand cmdCT = new SqlCommand(@"INSERT INTO CtDonHang (MaDH, MaSP, Don_gia, So_Luong, Thanh_tien) 
                                                   VALUES (@MaDH, @MaSP, @DonGia, @SoLuong, @ThanhTien)");
                cmdCT.Parameters.AddWithValue("@MaDH", maDH);
                cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP);
                cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmdCT.Parameters.AddWithValue("@ThanhTien", ct.SoLuong * ct.DonGia);
                dp.TruyVanKhongLayDuLieu(cmdCT);



                SqlCommand cmdSP = new SqlCommand(@"UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL 
                                                    WHERE MaSP = @MaSP AND SoLuongTon >= @SL");
                cmdSP.Parameters.AddWithValue("@SL", ct.SoLuong);
                cmdSP.Parameters.AddWithValue("@MaSP", ct.MaSP);
                dp.TruyVanKhongLayDuLieu(cmdSP);
            }

            return true;
        }

        public static DataTable TimKiemDonHang(string tuKhoa, string trangThai)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select dh.*, Sum(ct.Thanh_tien) as Tongtien, kh.TenKH
                                                from DonHang as dh
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                Join KhachHang as kh On dh.MaKH = kh.MaKH
                                                Where (@tuKhoa is null or dh.MaDH Like  '%' + @tuKhoa + '%' or kh.TenKH Like '%' + @tuKhoa + '%')
                                                  And (@TrangThai is null or dh.TrangThai = @TrangThai)    
                                                group by dh.MaDH, dh.MaKH, dh.MaNV, dh.NgayTao, dh.TrangThai, kh.TenKH");
            cmd.Parameters.Add("@tuKhoa", SqlDbType.NVarChar).Value = (object)tuKhoa ?? DBNull.Value;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = (object)trangThai ?? DBNull.Value;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

    }
}
