using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QlCuaHangXimenT.QuanLiNhanVien.Popup;

namespace QlCuaHangXimenT.NhanVien
{
    public partial class UC_NhanVien : UserControl
    {
    

        private void LayDuLieu()
        {
            dgvNhanVien.DataSource = NhanVien_BUS.DanhSachNhanVien();

            dgvNhanVien.Columns["Ten_dang_nhap"].Visible = false;
            dgvNhanVien.Columns["Mat_khau"].Visible = false;
            dgvNhanVien.Columns["MaCV"].Visible = false;
            dgvNhanVien.Columns["HinhAnh"].Visible = false;
           
            lblSoLuong.Text = dgvNhanVien.Rows.Count.ToString();
        }


        public UC_NhanVien()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNV them = new ThemNV();
            if (them.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();

            nv.MaNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
           
            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa NV: " + nv.MaNV + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = NhanVien_BUS.XoaNhanVien(nv);

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

        private void dgvNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string maNV = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                string mkCu = dgvNhanVien.CurrentRow.Cells["Mat_khau"].Value.ToString();

                string message;
                var nv = NhanVien_BUS.TimNhanVienTheoMa(maNV, out message);

                if (nv == null)
                {
                    MessageBox.Show(message);
                    return;
                }

                ChiTietNV ct = new ChiTietNV(maNV, nv, mkCu);
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
                dgvNhanVien.DataSource = NhanVien_BUS.TimKiemNhanvien(tuKhoa);

            }
        }
    }
}
