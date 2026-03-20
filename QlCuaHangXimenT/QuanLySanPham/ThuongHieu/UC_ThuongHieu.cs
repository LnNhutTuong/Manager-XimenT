using BUS;
using BUS.QuanLySanPham;
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
            dgvDanhMuc.DataSource = ThuongHieu_BUS.DanhSachThuongHieu();

            lblSoLuong.Text = dgvDanhMuc.Rows.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
