using BUS;
using BUS.QuanLyDonHang;
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


    }
}
