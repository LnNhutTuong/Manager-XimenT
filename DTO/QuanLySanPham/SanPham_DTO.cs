using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.QuanLySanPham
{
    public class SanPham_DTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Size {  get; set; }
        public string MaDM { get; set; }
        public string MaTH { get; set; }
        public string MaNV { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayThem { get; set; }
        public DateTime NgaySua { get; set; }
        public string HinhAnh  { get; set; }
        public int GiaBan { get; set; }
        public int GiaNhap { get; set; }
    }
}
