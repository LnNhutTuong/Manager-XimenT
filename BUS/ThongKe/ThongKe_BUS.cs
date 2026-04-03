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

        public static DataTable TongSoSanPham()
        {
            return ThongKe_DAO.TongSoSanPham();
        }

        public static DataTable TongSoDanhMuc()
        {
            return ThongKe_DAO.TongSoDanhMuc();
        }

        public static DataTable TongSoThuongHieu()
        {
            return ThongKe_DAO.TongSoThuongHieu();
        }

        public static DataTable TongTienNhapHang()
        {
            return ThongKe_DAO.TongSoTienNhapSP();
        }

        public static DataTable LoiNhuan()
        {
            return ThongKe_DAO.LoiNhuan();
        }

        public static DataTable DoanhThuTungThang()
        {
            return ThongKe_DAO.DoanThuTungThang();
        }

        public static DataTable SoSanPhamBanTheoThang()
        {
            return ThongKe_DAO.SoSanPhamBanTheoThang();
        }
    }
}
