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
    public partial class tab_DoanhThu : Form
    {
        public tab_DoanhThu()
        {
            InitializeComponent();
        }

        private void tab_ThongKe_Load(object sender, EventArgs e)
        {
         
            this.reportViewer2.RefreshReport();
        }
    }
}
