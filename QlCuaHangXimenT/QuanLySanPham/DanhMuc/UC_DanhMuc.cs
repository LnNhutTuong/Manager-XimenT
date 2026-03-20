using BUS;
using BUS.QuanLySanPham;
using DTO;
using QlCuaHangXimenT.QuanLiNhanVien.Popup;
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

namespace QlCuaHangXimenT.QuanLiSanPham
{
    public partial class UC_DanhMuc : UserControl
    {
        private void LayDuLieu()
        {
            dgvDanhMuc.DataSource = DanhMuc_BUS.DanhSachDanhMuc();

            lblSoLuong.Text = dgvDanhMuc.Rows.Count.ToString();
        }

        public UC_DanhMuc()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemDM them = new ThemDM();
            if (them.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();

            dm.MaDM = dgvDanhMuc.CurrentRow.Cells["MaDM"].Value.ToString();

            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa DM: " + dm.MaDM + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = DanhMuc_BUS.XoaDanhMuc(dm);

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

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDanhMuc.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string maDM = dgvDanhMuc.Rows[e.RowIndex].Cells["MaDM"].Value.ToString().Trim();
                Console.WriteLine(maDM);
                string message;
                var dm = DanhMuc_BUS.TimDanhMucTheoMa(maDM, out message);
                Console.WriteLine(dm);

                if (dm == null)
                {
                    MessageBox.Show(message);
                    return;
                }

                ChiTietDM ct = new ChiTietDM(maDM, dm);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string maDM = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(maDM))
                {
                    MessageBox.Show("Nhập mã để tìm!");
                }

                string message;
                var dm = DanhMuc_BUS.TimDanhMucTheoMa(maDM, out message);

                if (dm == null)
                {
                    MessageBox.Show(message);
                    return;
                }


                ChiTietDM ct = new ChiTietDM(maDM, dm);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDM = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(maDM))
            {
                MessageBox.Show("Nhập mã để tìm!");
            }

            string message;
            var dm = DanhMuc_BUS.TimDanhMucTheoMa(maDM, out message);

            if (dm == null)
            {
                MessageBox.Show(message);
                return;
            }


            ChiTietDM ct = new ChiTietDM(maDM, dm);
            if (ct.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }
    }
}
