using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
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

namespace QlCuaHangXimenT.QuanLySanPham.ThuongHieu
{
    public partial class UC_ThuongHieu : UserControl
    {
        public UC_ThuongHieu()
        {
            InitializeComponent();
            LayDuLieu();
        }

        public void LayDuLieu()
        {
            dgvThuongHieu.DataSource = ThuongHieu_BUS.DanhSachThuongHieu();

            lblSoLuong.Text = dgvThuongHieu.Rows.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemTH them = new ThemTH();

            if (them.ShowDialog() == DialogResult.OK) {
                LayDuLieu();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThuongHieu_DTO th = new ThuongHieu_DTO();

            th.MaTH = dgvThuongHieu.CurrentRow.Cells["MaTH"].Value.ToString();

            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa TH: " + th.MaTH + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = ThuongHieu_BUS.XoaThuongHieu(th);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công");
                    LayDuLieu();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void dgvThuongHieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThuongHieu.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string maTH = dgvThuongHieu.Rows[e.RowIndex].Cells["MaTH"].Value.ToString().Trim();
                Console.WriteLine(maTH);
                string message;
                var th = ThuongHieu_BUS.TimThuongHieuTheoMa(maTH, out message);
                Console.WriteLine(th);

                if (th == null)
                {
                    MessageBox.Show(message);
                    return;
                }

                ChiTietTH ct = new ChiTietTH(maTH, th);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LayDuLieu();
            }
            else
            {
                dgvThuongHieu.DataSource = ThuongHieu_BUS.TimKiemThuongHieu(tuKhoa);
            }
        }
    }
}
