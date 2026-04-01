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
        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            #region tab Tổng hợp
            tab_Tonghop th = new tab_Tonghop();
            th.TopLevel = false; // luwu ys
            th.Dock = DockStyle.Fill;
            tabTongHop.Controls.Add(th);
            th.Show();
            #endregion

            #region tab Tổng hợp
            //tab_Tonghop th = new tab_Tonghop();
            //th.TopLevel = false; // luwu ys
            //th.Dock = DockStyle.Fill;
            //tabTongHop.Controls.Add(th);
            //th.Show();
            #endregion


        }
    }
}
