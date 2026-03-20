using BUS;
using BUS.QuanLySanPham;
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
    public partial class ChiTietSP : Form
    {
        string maSP;

        public ChiTietSP(string maSP)
        {
            InitializeComponent();
            this.maSP = maSP;
        }

        public void SetData()
        {
            string message;
            DataTable sp = SanPham_BUS.SanPhamTheoMa(maSP, out message);
            if (sp != null && sp.Rows.Count > 0)
            {
                DataRow row = sp.Rows[0];

                Console.WriteLine(row.ToString());

                lblTenSP.Text = row["TenSP"].ToString();

                lblDanhMuc.Text = row["TenDM"].ToString();
                lblThuongHieu.Text = row["TenTH"].ToString();
                lblSize.Text = row["Size"].ToString();

                decimal gia = Convert.ToInt32(row["Gia"]);
                lblGia.Text = gia.ToString("N0") + " VNĐ";

                lblMaSanPham.Text = row["MaSP"].ToString();
                lblMaNV.Text = row["MaNV"].ToString();

                DateTime ngayThem = Convert.ToDateTime(row["NgayThem"]);
                lblNgayThem.Text = ngayThem.ToString("dd-MM-yyyy");

                lblSoLuongTon.Text = row["SoLuongTon"].ToString();

                DateTime ngaySua = Convert.ToDateTime(row["NgaySua"]);
                lblNgaySua.Text = ngaySua.ToString("dd-MM-yyyy HH:mm:ss");
            }                                      
       }

        private void ChiTietSP_Load(object sender, EventArgs e)
        {
            SetData();
            Console.WriteLine(maSP);
        }
    }
}
