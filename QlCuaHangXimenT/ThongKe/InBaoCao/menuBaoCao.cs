using QlCuaHangXimenT.ThongKe.InBaoCao.DonHang;
using QlCuaHangXimenT.ThongKe.InBaoCao.SanPham;
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
    public partial class menuBaoCao : Form
    {
        public menuBaoCao()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["BaoCaoSanPham"] == null)
            {
                BaoCaoSanPham bcsp = new BaoCaoSanPham();
                bcsp.Show();
            }       

        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["BaoCaoDonHang"] == null)
            {
                BaoCaoDonHang bcdh = new BaoCaoDonHang();
                bcdh.Show();
            }

           
        }
    }
}
