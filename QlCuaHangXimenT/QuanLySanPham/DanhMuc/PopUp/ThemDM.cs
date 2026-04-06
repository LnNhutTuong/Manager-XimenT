using BUS;
using BUS.QuanLySanPham;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlCuaHangXimenT.QuanLySanPham.DanhMuc.PopUp
{
    public partial class ThemDM : Form
    {
        public ThemDM()
        {
            InitializeComponent();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();

            dm.MaDM = txtMaDanhMuc.Text.ToUpper().Trim();
            dm.TenDM = txtTenDanhMuc.Text;

            string message = "";

            bool kq = DanhMuc_BUS.ThemDanhMuc(dm, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();
        }
    }
}
