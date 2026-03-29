using DAO;
using DAO.QuanLyDonHang;
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
    }
}
