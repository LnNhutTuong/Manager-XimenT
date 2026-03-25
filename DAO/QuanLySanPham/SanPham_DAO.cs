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
                                                Values (@MaSP, @TenSP, @Size, @MaDM, @MaTH, @MaNV, @SoLuongTon, @NgayThem, @HinhAnh, @Gia)");
            cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = sp.TenSP;
            cmd.Parameters.Add("@Size", SqlDbType.NVarChar, 100).Value = sp.Size;
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = sp.MaDM;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = sp.MaTH;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = sp.MaNV;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.SmallInt).Value = sp.SoLuongTon;
            cmd.Parameters.Add("@NgayThem", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = (object)sp.HinhAnh ?? DBNull.Value;
            cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = sp.Gia;
                
            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool SuaSanPham (SanPham_DTO sp, string maSP)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"  UPDATE SanPham 
                                                SET  TenSP = @TenSP,
                                                     Size = @Size,
                                                     MaDM =  @MaDM,
                                                     MaTH =  @MaTH,
                                                     MaNV = @MaNV,
                                                     SoLuongTon = @SoLuongTon,
                                                     NgaySua = @NgaySua,
                                                     HinhAnh = @HinhAnh,
                                                     Gia = @Gia
                                                Where MaTH = @oldMaTH ");
            cmd.Parameters.Add("@MaSp", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = sp.TenSP;
            cmd.Parameters.Add("@Size", SqlDbType.NVarChar, 100).Value = sp.Size;
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = sp.MaDM;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = sp.MaTH;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = sp.MaNV;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.SmallInt).Value = sp.SoLuongTon;
            cmd.Parameters.Add("@NgaySua", SqlDbType.DateTime).Value = sp.NgayThem;
            cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = sp.HinhAnh;
            cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = sp.Gia;
            cmd.Parameters.Add("@oldMaTH", SqlDbType.VarChar, 5).Value = maSP;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaSanPham(SanPham_DTO sp)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From SanPham Where MaSP = @MaSP");

            cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 5).Value = sp.MaSP;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }
    }
}
