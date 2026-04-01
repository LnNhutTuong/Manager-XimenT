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
    }
}
