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

        #region TREEN TREEN TREEN
        
        public static DataTable ThongKeTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            return ThongKe_DAO.ThongKeTheoKhoangThoiGian(tuNgay, denNgay);
        }

        public static DataTable TongSoDonHangTheoThoiGian(int trangThai, DateTime tuNgay, DateTime denNgay)
        {
            return ThongKe_DAO.TongSoDonHangTheoThoiGian(trangThai , tuNgay, denNgay);
        }

        #endregion

        #region DUOWIS DUWOIS DUWOIS DUWOSI

        public static DataTable ThongKeDoanhThuFull()
        {
            return ThongKe_DAO.ThongKeDoanhThuFull();
        }

        public static DataTable LayDonHangFull(int trangThai)
        {
            return ThongKe_DAO.LayDonHangFull(trangThai);
        }

        #endregion


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

       

    }
}
