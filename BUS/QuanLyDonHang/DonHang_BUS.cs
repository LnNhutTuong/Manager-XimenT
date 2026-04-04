using DAO;
using DAO.QuanLyDonHang;
using DTO.QuanLyDonHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUS.QuanLyDonHang
{
    public class DonHang_BUS
    {
        public static DataTable DanhSachDonHang()
        {
            return DonHang_DAO.DanhSachDonHang();
        }

        public static bool KiemTraMaDH(string maDH)
        {
            List<string> dsMaDH = DonHang_DAO.DanhSachMaDH();
            return dsMaDH.Contains(maDH.ToUpper());
        }

        public static bool ThemDonHang(DonHang_DTO dh, List<CtDonHang_DTO> ctdh, out string message)
        {
            message = "";

            if (string.IsNullOrEmpty(dh.MaDH))
            {
                message = "Mã đơn hàng không được để trống";
                return false;
            }

            if (dh.MaDH.Length != 5){
                message = "Mã đơn hàng phải có đủ 5 ký tự";
                return false;
            }

            if (KiemTraMaDH(dh.MaDH))
            {
                message = "Mã này đã tồn tại";
                return false;
            }

            if (ctdh == null || ctdh.Count == 0)
            {
                message = "Vui lòng thêm sản phẩm vào giỏ hàng!";
                return false;
            }

            return DonHang_DAO.ThemDonHang( dh, ctdh);
        }

        public static DataTable DonHangTheoMa(string maDH)
        {
            return DonHang_DAO.DonHangTheoMa(maDH); 
        }

        public static DataTable ChiTietDonHangTheoMa(string maDH)
        {
            return DonHang_DAO.ChiTietDonHangTheoMa(maDH);
        }

        public static bool SuaDonHang(DonHang_DTO dh, List<CtDonHang_DTO> ctdh, string maDH,out string message)
        {
            message = "";

            if (ctdh == null || ctdh.Count == 0)
            {
                message = "Vui lòng thêm sản phẩm vào giỏ hàng!";
                return false;
            }

            return DonHang_DAO.SuaDonHang(dh, ctdh, maDH);
        }

        public static DataTable TimKiemDonHang(string tuKhoa, string trangThai)
        {
            return DonHang_DAO.TimKiemDonHang(tuKhoa, trangThai);
        }

         
    }
}
