using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.QuanLySanPham
{
    internal class SanPham_DTO
    {
        string MaSP { get; set; }
        string TenSP { get; set; }
        string Size {  get; set; }
        string MaDM { get; set; }
        string MaTH { get; set; }
        string MaNV { get; set; }
        int SoLuongTon { get; set; }
        DateTime NgayThem { get; set; }
        DateTime NgayXoa { get; set; }
        string HinhAnh  { get; set; }
        int Gia { get; set; }
    }
}
