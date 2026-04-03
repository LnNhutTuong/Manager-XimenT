using BUS;
using BUS.QuanLyDonHang;
using BUS.QuanLyKhachHang;
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
            string trangThai = (cboTrangThai.SelectedIndex <= 0) ? null : (cboTrangThai.SelectedIndex -1) .ToString();
            string tuKhoa = string.IsNullOrEmpty(txtTimKiem.Text) ? null : txtTimKiem.Text;
            DataTable dsDonHang = DonHang_BUS.TimKiemDonHang(tuKhoa, trangThai);

            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.DataSource = dsDonHang;

            //dgvDonHang.Columns["MaKH"].Visible = false;
            //dgvDonHang.Columns["MaNV"].Visible = false;

            lblSoLuong.Text = dgvDonHang.Rows.Count.ToString();

            cboTrangThai.SelectedIndex = 0;
        }

        public UC_DonHang()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void dgvDonHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            dgvDonHang.Columns["NgayTao"].DefaultCellStyle.Format = "dd-MM-yyyy";

            dgvDonHang.Columns["MaDH"].DisplayIndex = 0;
            dgvDonHang.Columns["TenKH"].DisplayIndex = 1;
            dgvDonHang.Columns["TongTien"].DisplayIndex = 2;
            dgvDonHang.Columns["NgayTao"].DisplayIndex = 3;
            dgvDonHang.Columns["TrangThai"].DisplayIndex = 4;
            dgvDonHang.Columns["XemChiTiet"].DisplayIndex = 5;

            if (dgvDonHang.Columns[e.ColumnIndex].Name == "TongTien" && e.Value != null)
            {
                e.Value = string.Format("{0:N0} VNĐ", e.Value);
                e.FormattingApplied = true;
            }

            if (dgvDonHang.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                int trangThai = Convert.ToInt32(e.Value);

                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];

                switch (trangThai)
                {
                    case 0:
                        e.Value = "Chưa giao";
                        e.CellStyle.BackColor = Color.SkyBlue;
                        e.CellStyle.ForeColor = Color.Black;

                        e.CellStyle.SelectionBackColor = Color.SkyBlue;
                        e.CellStyle.SelectionForeColor = Color.Black;

                        break;
                    case 1:
                        e.Value = "Đang giao";
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;

                        e.CellStyle.SelectionBackColor = Color.Gold;
                        e.CellStyle.SelectionForeColor = Color.Black;

                        break;
                    case 2:
                        e.Value = "Giao thành công";
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;

                        e.CellStyle.SelectionBackColor = Color.Green;
                        e.CellStyle.SelectionForeColor = Color.White;

                        break;
                    case 3:
                        e.Value = "Đã hủy";
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;

                        e.CellStyle.SelectionBackColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.White;

                        break;
                }

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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void cboTrangThai_SelectedValueChanged(object sender, EventArgs e)
        {
            LayDuLieu();

        }
    }
}
