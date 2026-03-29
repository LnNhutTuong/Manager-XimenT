using DTO;
using DTO.QuanLyDonHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            SqlCommand cmd = new SqlCommand(@" Select dh.*, Sum(ct.Thanh_tien) as Tongtien
                                                from DonHang as dh
                                                Join CtDonHang as ct On ct.MaDH = dh.MaDH
                                                group by dh.MaDH, dh.MaKH, dh.MaNV, dh.NgayTao");

            DataTable table = dp.TruyVanLayDuLieu(cmd);

            return table;
        } 

        public static bool ThemDonHang(DonHang_DTO dh)
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand(@"INSERT INTO DonHang (MaDH, MaKH, MaNV, NgayTao)
                                             VALUES (@MaDH, @MaKH, @MaNV, @NgayTao)");

            cmd.Parameters.Add("@MaDH", SqlDbType.VarChar, 5).Value = dh.MaDH;
            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 5).Value = dh.MaKH;
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 5).Value = dh.MaNV;
            cmd.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = DateTime.Now;

            int kq = dp.TruyVanKhongLayDuLieu(cmd);

            return kq > 0;
        }

    }
}
