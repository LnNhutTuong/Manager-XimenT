using DTO;
using DTO.QuanLySanPham;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.QuanLySanPham
{
    public class SanPham_DAO
    {
        public static DataTable DanhSachSanPham()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  Select *, dm.TenDM, th.TenTH, nv.MaNV 
                                                From SanPham as sp
                                                Join DanhMuc as dm
                                                On dm.MaDM = sp.MaDM
                                                Join ThuongHieu as th
                                                On th.MaTH = sp.MaTH
                                                Join NhanVien as nv
                                                On nv.MaNV = sp.MaNV");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static List<string> DanhSachMaSP()
        {
            List<string> dsMaSP = new List<string>();

            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select MaSP From SanPham");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            foreach (DataRow row in table.Rows)
            {
                dsMaSP.Add(row["MaSP"].ToString());
            }

            return dsMaSP;
        }

        public static DataTable SanPhamTheoMa(string maSP)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Select *, dm.TenDM, th.TenTH, nv.MaNV 
                                                From SanPham as sp
                                                Join DanhMuc as dm
                                                On dm.MaDM = sp.MaDM
                                                Join ThuongHieu as th
                                                On th.MaTH = sp.MaTH
                                                Join NhanVien as nv
                                                On nv.MaNV = sp.MaNV
                                                Where MaSP = @MaSP");

            cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 5).Value = maSP;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }

        public static bool ThemSanPham(SanPham_DTO sp)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  INSERT INTO SanPham 
                                                (MaSP, TenSP, Size, MaDM, MaTH, MaNV, SoLuongTon, NgayThem, HinhAnh, Gia)
                                                Values @MaSP, @TenSP, @Size, @MaDM, @MaTH, @MaNV, @SoLuongTon, @NgayThem, @HinhAnh, @Gia");
            cmd.Parameters.Add("@MaSp", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@TenSP", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@Size", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@NgayThem", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@HinhAnh", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@Gia", SqlDbType.VarChar, 5).Value = sp.MaSP;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }
    }
}
