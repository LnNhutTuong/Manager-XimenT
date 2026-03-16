using System;
    using BUS;
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

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien nv = new UC_NhanVien();
            lblViTri.Text = "Quản lí Nhân Viên";
            content.Controls.Add(nv);

            
        }
    }
}
