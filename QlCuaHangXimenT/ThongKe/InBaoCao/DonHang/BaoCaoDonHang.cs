using BUS.QuanLyDonHang;
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

namespace QlCuaHangXimenT.ThongKe.InBaoCao.DonHang
{
    public partial class BaoCaoDonHang : Form
    {

        public void LayDuLieu()
        {
            DataTable DsDonHang = DonHang_BUS.DanhSachDonHang();

            try
            {
                ReportDataSource rds = new ReportDataSource("DataSetDonHang", DsDonHang);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public BaoCaoDonHang()
        {
            InitializeComponent();

        }

        private void BaoCaoDonHang_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }
    }
}
