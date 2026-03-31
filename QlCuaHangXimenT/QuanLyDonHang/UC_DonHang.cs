using BUS;
using BUS.QuanLyDonHang;
using BUS.QuanLySanPham;
using DTO.QuanLyDonHang;
using QlCuaHangXimenT.QuanLyDonHang.PopUp;
using QlCuaHangXimenT.QuanLySanPham.DanhMuc.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLyDonHang
{
    public partial class UC_DonHang : UserControl
    {
        private void LayDuLieu()
        {
            dgvDonHang.DataSource = DonHang_BUS.DanhSachDonHang();

            dgvDonHang.Columns["MaKH"].Visible = false;
            dgvDonHang.Columns["MaNV"].Visible = false;
            dgvDonHang.Columns["NgayTao"].Visible = false;

        }

        public UC_DonHang()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void dgvDonHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDonHang.Columns[e.ColumnIndex].Name == "Tongtien" && e.Value != null)
            {
                e.Value = string.Format("{0:N0} VNĐ", e.Value);
                e.FormattingApplied = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemDH them = new ThemDH();
            if(them.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <0)
            {
                return;
            }

            if (dgvDonHang.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string maDH = dgvDonHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString().Trim();
                var dh = DonHang_BUS.DonHangTheoMa(maDH);
                var ctdh = DonHang_BUS.ChiTietDonHangTheoMa(maDH);
                ChiTietDH ct = new ChiTietDH(maDH, dh, ctdh);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
            }
        }
    }
}
