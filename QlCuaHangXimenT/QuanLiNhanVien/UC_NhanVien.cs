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
        }


        public UC_NhanVien()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them them = new Them();
            if (them.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                string maNV = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                Console.WriteLine(maNV);
                string message;
                var nv = NhanVien_BUS.TimNhanVienTheoMa(maNV, out message);

                if (nv == null)
                {
                    MessageBox.Show(message);
                    return;
                }

                ChiTietNV ct = new ChiTietNV(maNV, nv);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtTimKiem.Text;
            string message;
            var nv = NhanVien_BUS.TimNhanVienTheoMa(maNV, out message);

            if (nv == null)
            {
                MessageBox.Show(message);
                return;
            }

            ChiTietNV ct = new ChiTietNV(maNV, nv);
            if (ct.ShowDialog() == DialogResult.OK)
            {
                LayDuLieu();
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Enter)
            {
                string maNV = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Nhập mã để tìm kiếm");
                    return; 
                }
             
                string message;
                var nv = NhanVien_BUS.TimNhanVienTheoMa(maNV, out message);

                if (nv == null) 
                {
                    MessageBox.Show(message);
                    return; 
                }


                ChiTietNV ct = new ChiTietNV(maNV, nv);
                if (ct.ShowDialog() == DialogResult.OK)
                {
                    LayDuLieu();
                }
            }
        }
    }
}
