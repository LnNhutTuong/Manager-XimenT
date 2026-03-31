using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.QuanLyDonHang
{
    public  class CtDonHang_DTO
    {
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien => SoLuong * DonGia;

    }
}
