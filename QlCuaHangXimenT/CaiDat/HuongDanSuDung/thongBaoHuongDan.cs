using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.CaiDat.HuongDanSuDung
{
    public partial class thongBaoHuongDan : Form
    {
        public thongBaoHuongDan()
        {
            InitializeComponent();
        }

        void AnHuongDan()
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (chkAnHuongDan.Checked)
            {
                Properties.Settings.Default.ShowGuide = false;
                Properties.Settings.Default.Save();
            }
            this.Close();
        }

        private void btnDiDen_Click(object sender, EventArgs e)
        {
            if (chkAnHuongDan.Checked)
            {
                Properties.Settings.Default.ShowGuide = false;
                Properties.Settings.Default.Save();
            }
            this.Close();
        }
    }
}
