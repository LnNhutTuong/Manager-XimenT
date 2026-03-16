using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QlCuaHangXimenT.NhanVien;

namespace QlCuaHangXimenT
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnQuanLiNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien nv = new UC_NhanVien();
            nv.Dock = DockStyle.Fill;
            content.Controls.Add(nv);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
