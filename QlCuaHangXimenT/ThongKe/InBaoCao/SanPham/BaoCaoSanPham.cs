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

namespace QlCuaHangXimenT.ThongKe.InBaoCao.SanPham
{
    public partial class BaoCaoSanPham : Form
    {
        public BaoCaoSanPham()
        {
            InitializeComponent();
        }

        public void LoadDuLieuReport()
        {
            DataTable DsSanPham = SanPham_BUS.DanhSachSanPham();

            try
            {
                ReportDataSource rds = new ReportDataSource("DataSetSanPham", DsSanPham);
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("DataSetSanPham", dsSanPham);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        private void BaoCaoSanPham_Load(object sender, EventArgs e)
        {
            LoadDuLieuReport();
        }
    }
}
