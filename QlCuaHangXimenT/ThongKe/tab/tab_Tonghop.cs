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
        DateTime tuNgay;
        DateTime denNgay;
        public tab_Tonghop(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();

            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        public void LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;

            #region thống kê theo ngay
            DataTable ThongKeFull = ThongKe_BUS.ThongKeFull();
            if (ThongKeFull != null && ThongKeFull.Rows.Count > 0)
            {
                DataRow row = ThongKeFull.Rows[0];
                var doanhThu = row["DoanhThu"] == DBNull.Value ? 0 : row["DoanhThu"];
                var soSanPhamDaBan = row["SoLuong"] == DBNull.Value ? 0 : row["SoLuong"];

                lblDoanhThu.Text = Convert.ToDecimal(doanhThu).ToString("N0") + " VNĐ";
                lblSanPhamDaBan.Text = soSanPhamDaBan.ToString() + " sản phẩm";
            }
            else
            {
                lblDoanhThu.Text = "0 VNĐ";
                lblSanPhamDaBan.Text = "0 sản phẩm";
            }
            #endregion


            //#region thống kê theo ngay
            //DataTable ThongKeTheoNgay = ThongKe_BUS.ThongKeTheoKhoangThoiGian(tuNgay, denNgay);
            //if (ThongKeTheoNgay != null && ThongKeTheoNgay.Rows.Count > 0)
            //{
            //    DataRow row = ThongKeTheoNgay.Rows[0];
            //    var doanhThu = row["DoanhThu"] == DBNull.Value ? 0 : row["DoanhThu"];
            //    var soSanPhamDaBan = row["SoLuong"] == DBNull.Value ? 0 : row["SoLuong"];

            //    lblDoanhThu.Text = Convert.ToDecimal(doanhThu).ToString("N0") + " VNĐ";
            //    lblSanPhamDaBan.Text = soSanPhamDaBan.ToString() + " sản phẩm";
            //}
            //else
            //{
            //    lblDoanhThu.Text = "0 VNĐ";
            //    lblSanPhamDaBan.Text = "0 sản phẩm";
            //}
            //#endregion

            #region thống kê đơn xanh
            DataTable DonHangThanhCong = ThongKe_BUS.DonHangTheoTrangThai(2); 
            if (DonHangThanhCong != null && DonHangThanhCong.Rows.Count > 0)
            {
                lblThanhCong.Text = DonHangThanhCong.Rows[0]["SoDonHang"].ToString() + " đơn";
            }
            else { lblThanhCong.Text = "0 đơn"; }
            #endregion

            #region thống kê đơn đỏ
            DataTable DonHangThatBai = ThongKe_BUS.DonHangTheoTrangThai(3); 
            if (DonHangThatBai != null && DonHangThatBai.Rows.Count > 0)
            {
                lblBiHuy.Text = DonHangThatBai.Rows[0]["SoDonHang"].ToString() + " đơn";
            }
            else { lblBiHuy.Text = "0 đơn"; }
            #endregion
            // this.reportViewer1.RefreshReport(); 
        }


    }
}
