using BUS;
using DTO;
using DTO.QuanLySanPham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLySanPham.SanPham
{
    public partial class short_SanPham : UserControl
    {
        public short_SanPham()
        {
            InitializeComponent();
        }

        public void SetData(string maSP, string tenSP, int giaTien)
        {
            lblMaSanPham.Text = maSP;
            lblTenSanPham.Text = tenSP;
            lblGiaTien.Text = giaTien.ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string maSP = lblMaSanPham.Text;
            ChiTietSP ctsp = new ChiTietSP(maSP);

            ctsp.Show();
        }
    }


}
