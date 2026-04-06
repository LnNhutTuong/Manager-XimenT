using BUS;
using BUS.QuanLySanPham;
using DTO;
using DTO.QuanLySanPham;
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
    public partial class ThemTH : Form
    {
        public ThemTH()
        {
            InitializeComponent();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            ThuongHieu_DTO th = new ThuongHieu_DTO();

            th.MaTH = txtMaThuongHieu.Text.ToUpper().Trim();
            th.TenTH = txtTenThuongHieu.Text;

            string message = "";

            bool kq = ThuongHieu_BUS.ThemThuongHieu(th, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaThuongHieu.Clear();
            txtTenThuongHieu.Clear();
        }
    }
}
