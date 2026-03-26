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
                                                (MaSP, TenSP, Size, MaDM, MaTH, MaNV, SoLuongTon, NgayThem, HinhAnh, Gia, NgaySua)
                                                Values (@MaSP, @TenSP, @Size, @MaDM, @MaTH, @MaNV, @SoLuongTon, @NgayThem, @HinhAnh, @Gia, @NgaySua)");
            cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 5).Value = sp.MaSP;
            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = sp.TenSP;
            cmd.Parameters.Add("@Size", SqlDbType.NVarChar, 100).Value = sp.Size;
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = sp.MaDM;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = sp.MaTH;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = sp.MaNV;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.SmallInt).Value = sp.SoLuongTon;
            cmd.Parameters.Add("@NgayThem", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cmd.Parameters.Add("@NgaySua", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
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
                                                Where MaSP = @oldMaSP ");
            cmd.Parameters.Add("@oldMaSP", SqlDbType.VarChar, 5).Value = maSP;
            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = sp.TenSP;
            cmd.Parameters.Add("@Size", SqlDbType.NVarChar, 100).Value = sp.Size;
            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = sp.MaDM;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = sp.MaTH;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = sp.MaNV;
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.SmallInt).Value = sp.SoLuongTon;
            cmd.Parameters.Add("@NgaySua", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 255).Value = (object)sp.HinhAnh ?? DBNull.Value;
            cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = sp.Gia;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static bool XoaSanPham(string maSP)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"Delete From SanPham Where MaSP = @MaSP");

            cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 5).Value = maSP;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

        public static DataTable LocSanPham(string maDM, string maTH, DateTime? tuNgay, DateTime? denNgay)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@" SELECT * FROM SanPham
                                        WHERE (@MaDM IS NULL OR MaDM = @MaDM)
                                          AND (@MaTH IS NULL OR MaTH = @MaTH)
                                          AND (@tuNgay IS NULL OR NgayThem >= @tuNgay)
                                          AND (@denNgay IS NULL OR NgayThem <= @denNgay)");

            cmd.Parameters.Add("@MaDM", SqlDbType.VarChar, 5).Value = (object)maDM ?? DBNull.Value;
            cmd.Parameters.Add("@MaTH", SqlDbType.VarChar, 5).Value = (object)maTH ?? DBNull.Value;
            cmd.Parameters.Add("@tuNgay", SqlDbType.DateTime).Value = (object)tuNgay ?? DBNull.Value;
            cmd.Parameters.Add("@denNgay", SqlDbType.DateTime).Value = (object)denNgay ?? DBNull.Value;

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        }
    }


    

}
