using BUS.ThongKe;
using QlCuaHangXimenT.QuanLySanPham.SanPham.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QlCuaHangXimenT.ThongKe.tab
{
    public partial class tab_SanPham : Form
    {
        DateTime tuNgay;
        DateTime denNgay;

        public tab_SanPham(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        public void LayDuLieuTren(DateTime tuNgay, DateTime denNgay)
        {
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;

            #region cục đầu
            DataTable TongSoSanPham = ThongKe_BUS.TongSoSanPham();
            if (TongSoSanPham != null && TongSoSanPham.Rows.Count > 0)
            {
                DataRow rowFull = TongSoSanPham.Rows[0];
                var sanPhamFull = rowFull["TongSoLuong"] == DBNull.Value ? 0 : rowFull["TongSoLuong"];

                lblTongSoSanPham.Text = sanPhamFull.ToString() + " sản phẩm";
            }

            #endregion

            #region cục 2 tuwf trasi qua
            DataTable TongSoSanPhamDaBanTheoThoiGian = ThongKe_BUS.TongSoSanPhamDaBanTheoThoiGian(tuNgay, denNgay);
            if (TongSoSanPhamDaBanTheoThoiGian != null && TongSoSanPhamDaBanTheoThoiGian.Rows.Count > 0)
            {
                DataRow rowBan = TongSoSanPhamDaBanTheoThoiGian.Rows[0];
                var TongSoDaBan = rowBan["TongSoLuong"] == DBNull.Value ? 0 : rowBan["TongSoLuong"];

                lblSanPhamDaBan.Text = TongSoDaBan.ToString() + " sản phẩm";
            }

            #endregion

            #region cục 3 từ trái qua
            DataTable TongDanhMuc = ThongKe_BUS.TongSoDanhMuc();
            if (TongDanhMuc != null && TongDanhMuc.Rows.Count > 0)
            {
                DataRow rowDM = TongDanhMuc.Rows[0];
                var DanhMuc = rowDM["TongSoLuong"] == DBNull.Value ? 0 : rowDM["TongSoLuong"];

                lblTongSoDanhMuc.Text = DanhMuc.ToString() + " danh mục";
            }
            #endregion

            #region cục 4 ừ trái qua
            DataTable TongThuongHieu = ThongKe_BUS.TongSoThuongHieu();
            if (TongThuongHieu != null && TongThuongHieu.Rows.Count > 0)
            {
                DataRow rowTH = TongThuongHieu.Rows[0];
                var ThuongHieu = rowTH["TongSoLuong"] == DBNull.Value ? 0 : rowTH["TongSoLuong"];

                lblTongSoThuongHieu.Text = ThuongHieu.ToString() + " danh mục";
            }
            #endregion
        }

        public void LayDuLieuDuoi()
        {
            #region trái
            DataTable Top5SanPham = ThongKe_BUS.Top5SanPham();

            chartSanPham.Series[0].Points.Clear();

            for (int i = 0; i < Top5SanPham.Rows.Count; i++)
            {

                DataRow row = Top5SanPham.Rows[i];

                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                int pIndex = chartSanPham.Series[0].Points.AddXY(tenSP, soLuong);
                DataPoint p = chartSanPham.Series[0].Points[pIndex];
                
                if (i % 2 == 0)
                {
                    p.Color = Color.Black;
                    p.LabelForeColor = Color.Black;

                }
                else
                {
                    p.Color = Color.White;
                    p.LabelForeColor = Color.Black;
                    p.BorderColor = Color.Black; 
                    p.BorderWidth = 1;
                }

                p.Label = tenSP + " (" + soLuong + ")";

                p.LegendText = tenSP;
            }
            #endregion

            #region Phải trên
            DataTable Top3DanhMuc = ThongKe_BUS.Top3DanhMuc();           

            chartDanhMuc.Series[0].Points.Clear();

            for (int i = 0; i < Top3DanhMuc.Rows.Count; i++)
            {
                DataRow row = Top3DanhMuc.Rows[i];
                int pIndex = chartDanhMuc.Series[0].Points.AddXY(row["TenDM"].ToString(), row["SoLuong"]);
                DataPoint p = chartDanhMuc.Series[0].Points[pIndex];

                if (i == 0) p.Color = Color.Black;
                else if (i == 1) p.Color = Color.Gray;
                else
                {
                    p.Color = Color.White;
                    p.BorderColor = Color.Black;
                    p.BorderWidth = 1;
                }

                p.Label = "#PERCENT{P0}";
                p.LegendText = row["TenDM"].ToString();
            }
            #endregion

            #region phải dưới
            DataTable Top3ThuongHieu = ThongKe_BUS.Top3ThuongHieu();

            chartThuongHieu.Series[0].Points.Clear();

            for (int i = 0; i < Top3ThuongHieu.Rows.Count; i++)
            {
                DataRow row = Top3ThuongHieu.Rows[i];
                string tenTH = row["TenTH"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);

                int pIndex = chartThuongHieu.Series[0].Points.AddXY(tenTH, soLuong);
                DataPoint p = chartThuongHieu.Series[0].Points[pIndex];

                if (i == 0) 
                {
                    p.Color = Color.Black;
                    p.LabelForeColor = Color.Black; 
                }
                else if (i == 1) 
                {
                    p.Color = Color.Gray;
                    p.LabelForeColor = Color.Black;
                }
                else 
                {
                    p.Color = Color.White;
                    p.BorderColor = Color.Black;
                    p.BorderWidth = 1;
                    p.LabelForeColor = Color.Black;
                }

                p.AxisLabel = tenTH;
            }
            #endregion

        }
    }


}



