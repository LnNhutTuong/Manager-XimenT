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
    public partial class tab_DoanhThu : Form
    {
        public tab_DoanhThu()
        {
            InitializeComponent();
        }

        private void tab_ThongKe_Load(object sender, EventArgs e)
        {
            DataTable tongTienNhapSP = ThongKe_BUS.TongTienNhapHang();
            DataRow rowTienNhap = tongTienNhapSP.Rows[0];
            int tienNhap = Convert.ToInt32(rowTienNhap["GiaNhap"]);
            lblTongTienNhapHang.Text = tienNhap.ToString("N0") + " VNĐ";

            //DataTable ThongKe = ThongKe_BUS.DoanhThuVaSoLuongSanPham();
            //DataRow row = ThongKe.Rows[0];
            //var doanhThu = row["TongTien"] == DBNull.Value ? 0 : row["TongTien"];
            //lblDoanhThu.Text = Convert.ToInt32(doanhThu).ToString("N0") + " VNĐ";

            DataTable DonHangThanhCong = ThongKe_BUS.DonHangTheoTrangThai(2);
            DataRow rowThanhCong = DonHangThanhCong.Rows[0];
            lblSoLuongHoaDon.Text = rowThanhCong["SoDonHang"].ToString() + " đơn";

            DataTable LoiNhuan = ThongKe_BUS.LoiNhuan();
            DataRow rowLoiNhuan = LoiNhuan.Rows[0];
            var loiNhuan = rowLoiNhuan["LoiNhuan"] == DBNull.Value ? 0 : rowLoiNhuan["LoiNhuan"];
            lblLoiNhuan.Text = Convert.ToInt32(loiNhuan).ToString("N0") + " VNĐ";

            this.reportViewer2.RefreshReport();
        }
    }
}
