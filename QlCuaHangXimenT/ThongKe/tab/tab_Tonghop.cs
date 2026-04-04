using BUS.ThongKe;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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

        public void LayDuLieuTren(DateTime tuNgay, DateTime denNgay)
        {
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;

            #region 2 cục đầu
            DataTable ThongKeFull = ThongKe_BUS.ThongKeTheoKhoangThoiGian(tuNgay, denNgay);
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

            #region cục 3 từ trái qua
            DataTable DonHangThanhCong = ThongKe_BUS.TongSoDonHangTheoThoiGian(2, tuNgay, denNgay); 
            if (DonHangThanhCong != null && DonHangThanhCong.Rows.Count > 0)
            {
                lblThanhCong.Text = DonHangThanhCong.Rows[0]["SoDonHang"].ToString() + " đơn";
            }
            else { lblThanhCong.Text = "0 đơn"; }
            #endregion

            #region thống kê đơn đỏ
            DataTable DonHangThatBai = ThongKe_BUS.TongSoDonHangTheoThoiGian(3, tuNgay, denNgay); 
            if (DonHangThatBai != null && DonHangThatBai.Rows.Count > 0)
            {
                lblBiHuy.Text = DonHangThatBai.Rows[0]["SoDonHang"].ToString() + " đơn";
            }
            else { lblBiHuy.Text = "0 đơn"; }
            #endregion
        }

        public void LayDuLieuDuoi()
        {
            #region trái
            DataTable ThongKeFull = ThongKe_BUS.ThongKeDoanhThuFull();

            chartDoanhThu.Series[0].Points.Clear();

            for(int i = 1; i<= 4; i++)
            {
                string thangHienTai = "Quý " + i + "/" + DateTime.Now.Year;
                double doanhThu = 0;

                foreach (DataRow row in ThongKeFull.Rows)
                {
                    if (row["Quy"].ToString() == thangHienTai)
                    {
                        doanhThu = Convert.ToDouble(row["DoanhThu"]);
                        break;
                    }
                }

                chartDoanhThu.Series[0].Points.AddXY(thangHienTai, doanhThu);
            }
            #endregion

            #region phải
            DataTable DonXanh = ThongKe_BUS.LayDonHangFull(2);
            DataTable DonDo = ThongKe_BUS.LayDonHangFull(3);

            int donXanh = 0;
            int donDo = 0;
            chartDonHang.Series[0].Points.Clear();

            foreach(DataRow rowXanh in DonXanh.Rows)
            {
                if (DonXanh.Rows.Count > 0)
                {
                    donXanh = Convert.ToInt32(rowXanh["SoLuong"]);
                }

                int indexThanhCong = chartDonHang.Series[0].Points.AddXY("Thành công", donXanh);
                chartDonHang.Series[0].Label = "#PERCENT{P0}";
                chartDonHang.Series[0].Points[indexThanhCong].Color = Color.Black;
                chartDonHang.Series[0].Points[indexThanhCong].LabelForeColor = Color.White;
                chartDonHang.Series[0].Points[indexThanhCong].LegendText= "Thành công";

            }


            foreach (DataRow rowDo in DonDo.Rows)
            {
                if (DonDo.Rows.Count > 0)
                {
                    donDo = Convert.ToInt32(rowDo["SoLuong"]);
                }

                int indexBiHuy = chartDonHang.Series[0].Points.AddXY("Bị hủy", donDo);
                chartDonHang.Series[0].Label = "#PERCENT{P0}";
                chartDonHang.Series[0].Points[indexBiHuy].Color = Color.White;
                chartDonHang.Series[0].Points[indexBiHuy].LabelForeColor = Color.Black;
                chartDonHang.Series[0].Points[indexBiHuy].BorderColor = Color.Black;
                chartDonHang.Series[0].Points[indexBiHuy].LegendText = "Bị hủy";


            }
            #endregion
        }

    }
}
