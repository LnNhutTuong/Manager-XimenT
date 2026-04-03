using BUS.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.ThongKe.tab
{
    public partial class tab_SanPham : Form
    {
        public tab_SanPham()
        {
            InitializeComponent();
        }

        private void tab_SanPham_Load(object sender, EventArgs e)
        {
            DataTable tongSoSanPham = ThongKe_BUS.TongSoSanPham();
            DataRow rowTongSoSP = tongSoSanPham.Rows[0];
            lblTongSoSanPham.Text = rowTongSoSP["TongSoLuong"].ToString() + " sản phẩm";

            DataTable ThongKe = ThongKe_BUS.DoanhThuVaSoLuongSanPham();
            DataRow row = ThongKe.Rows[0];
            var sanPhamDaban = row["SoLuongSanPhamBanRa"] == DBNull.Value ? 0 : row["SoLuongSanPhamBanRa"];
            lblSanPhamDaBan.Text = sanPhamDaban.ToString() + " sản phẩm";

            DataTable tongSoDanhMuc = ThongKe_BUS.TongSoDanhMuc();
            DataRow rowDanhMuc = tongSoDanhMuc.Rows[0];
            lblTongSoDanhMuc.Text = rowDanhMuc["TongSoDanhMuc"].ToString() + " danh mục";

            DataTable tongSoThuongHieu = ThongKe_BUS.TongSoThuongHieu();
            DataRow rowThuongHieu = tongSoThuongHieu.Rows[0];
            lblTongSoThuongHieu.Text = rowThuongHieu["TongSoThuongHieu"].ToString() + " thương hiệu";

            this.reportViewer1.RefreshReport();
        }
    }
}
