using QlCuaHangXimenT.ThongKe.InBaoCao;
using QlCuaHangXimenT.ThongKe.tab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.ThongKe
{
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe( )
        {
            InitializeComponent();
        }

        tab_Tonghop th;
        tab_SanPham sp;

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            #region tab Tổng hợp
            th = new tab_Tonghop(tuNgay, denNgay);
            th.TopLevel = false; // luwu ys
            th.Dock = DockStyle.Fill;
            tabTongHop.Controls.Add(th);
            th.Show();

            th.LayDuLieuTren(tuNgay, denNgay);
            th.LayDuLieuDuoi();
            #endregion

            #region tab Sản phẩm
            sp = new tab_SanPham(tuNgay, denNgay);
            sp.TopLevel = false; // luwu ys
            sp.Dock = DockStyle.Fill;
            tabSanPham.Controls.Add(sp);
            sp.Show();

            sp.LayDuLieuTren(tuNgay, denNgay);
            sp.LayDuLieuDuoi();
            #endregion

        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

            if(dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn kết thúc!");
                dtpTuNgay.Value = dtpDenNgay.Value;
                return;
            }

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            th.LayDuLieuTren(tuNgay, denNgay);

            sp.LayDuLieuTren(tuNgay, denNgay);


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(tcThongKe.SelectedTab == tabSanPham)
            {
                BaoCaoSanPham sp = new BaoCaoSanPham();
                sp.Show();
            }
            else if(tcThongKe.SelectedTab == tabTongHop)
            {
                BaoCaoTongHop th = new BaoCaoTongHop();
                th.Show();
            }
        }
    }
}
