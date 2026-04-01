using DAO.ThongKe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS.ThongKe
{
    public class ThongKe_BUS
    {
        public static DataTable DoanhThuVaSoLuongSanPham()
        {
            return ThongKe_DAO.DoanhThuVaSoLuongSanPham();
        }

        public static DataTable DonHangTheoTrangThai(int trangThai)
        {
            return ThongKe_DAO.LayDonHangTheoTrangThai(trangThai);
        }
    }
}
