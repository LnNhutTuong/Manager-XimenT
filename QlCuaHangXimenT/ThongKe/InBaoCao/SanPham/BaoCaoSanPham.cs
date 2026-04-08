using BUS.QuanLySanPham;
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

namespace QlCuaHangXimenT.ThongKe.InBaoCao
{
    public partial class BaoCaoSanPham : Form
    {
        public BaoCaoSanPham()
        {
            InitializeComponent();
        }

        private void LayDuLieu()
        {
            try
            {
                DataTable dsSanPham = SanPham_BUS.DanhSachSanPham();

                if (dsSanPham != null && dsSanPham.Rows.Count > 0)
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("DataSetSanPham", dsSanPham);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCaoSanPham_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }
    }
}
