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
    public partial class tab_Tonghop : Form
    {
        public tab_Tonghop()
        {
            InitializeComponent();
        }

        void LayDuLieu()
        {
            DataTable doanhThu12Thang = ThongKe_BUS.DoanhThuTungThang();

        }

        private void tab_Tonghop_Load(object sender, EventArgs e)
        {
            DataTable ThongKe = ThongKe_BUS.DoanhThuVaSoLuongSanPham();

            DataRow row = ThongKe.Rows[0];

            var doanhThu = row["TongTien"] == DBNull.Value ? 0 : row["TongTien"];

            var soSanPhamDaBan = row["SoLuongSanPhamBanRa"] == DBNull.Value ? 0 : row["SoLuongSanPhamBanRa"];

            lblDoanhThu.Text = Convert.ToInt32(doanhThu).ToString("N0") + " VNĐ";
            lblSanPhamDaBan.Text = soSanPhamDaBan.ToString() + " sản phẩm";

            DataTable DonHangThanhCong = ThongKe_BUS.DonHangTheoTrangThai(2);
            DataRow rowThanhCong = DonHangThanhCong.Rows[0];
            lblThanhCong.Text = rowThanhCong["SoDonHang"].ToString() + " đơn";

            DataTable DonHangThatBai = ThongKe_BUS.DonHangTheoTrangThai(3);
            DataRow rowThatBai = DonHangThatBai.Rows[0];
            lblBiHuy.Text = rowThatBai["SoDonHang"].ToString() + " đơn";




            this.reportViewer1.RefreshReport();
        }
    }
}
