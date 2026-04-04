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

        public static DataTable TongSoSanPham()
        {
            return ThongKe_DAO.TongSoSanPham();
        }

        public static DataTable TongSoSanPhamDaBanTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            return ThongKe_DAO.TongSoSanPhamDaBanTheoThoiGian(tuNgay, denNgay);
        }

        public static DataTable TongSoThuongHieu()
        {
            return ThongKe_DAO.TongSoThuongHieu();
        }

        public static DataTable TongSoDanhMuc()
        {
            return ThongKe_DAO.TongSoDanhMuc();
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

        public static DataTable Top5SanPham( )
        {
            return ThongKe_DAO.Top5SanPham();
        }

        public static DataTable Top3DanhMuc()
        {
            return ThongKe_DAO.Top3DanhMuc();
        }

        public static DataTable Top3ThuongHieu()
        {
            return ThongKe_DAO.Top3ThuongHieu();
        }

        #endregion






    }
}
