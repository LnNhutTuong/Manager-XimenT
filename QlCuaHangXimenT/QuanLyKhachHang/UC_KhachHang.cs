using BUS;
using BUS;
using BUS.QuanLyKhachHang;
using DTO;
using DTO.QuanLyKhachHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace QlCuaHangXimenT.KhachHang
{
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
            //LoadDataTest(chartTopKH);
            LayDuLieu();
            BieuDoKhachHang();
            OnOff(false);
        }

        public void OnOff(bool value)
        {
            txtMaKhachHang.Enabled = !value;

            btnThemMoi.Enabled = !value;
            btnCapNhat.Enabled = value;
            btnXoaBo.Enabled = value;
        }

        public void LayDuLieu()
        {
            dgvKhachHang.DataSource = KhachHang_BUS.DanhSachKhachHang();
            lblTongSoKhachHang.Text = dgvKhachHang.Rows.Count.ToString();
        }

        public void BieuDoKhachHang()
        {
            chartTopKH.Series.Clear();

            Series s = new Series("Khách hàng");

            s.ChartType = SeriesChartType.Bar;
            s.Color = Color.Black;
            s["PixelPointWidth"] = "20";

            var area = chartTopKH.ChartAreas[0];

            double maxTotal = 0;

            DataTable top3 = KhachHang_BUS.Top3KhachHang();

            foreach (DataRow row in top3.Rows)
            {
                string tenKH = row["TenKH"].ToString();
                double tongTien = Convert.ToDouble(row["TongTien"]);

                if (tongTien > maxTotal) maxTotal = tongTien;

                int index = s.Points.AddXY(tenKH, tongTien);

                s.Points[index].Label = $"{tenKH}\n{tongTien:N0} VNĐ";

                s.Points[index]["BarLabelStyle"] = "OutSide";

                s.Points[index].Font = new Font("Arial", 9, FontStyle.Bold);

            }

            if (maxTotal > 0)
            {
                area.AxisY.Maximum = maxTotal * 1.3;
                area.AxisY.LabelStyle.Enabled = false; 
            }

            area.AxisX.Interval = 1;

            chartTopKH.Series.Add(s);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

            txtMaKhachHang.Text = row.Cells["MaKH"].Value.ToString();
            txtTenKhachHang.Text = row.Cells["TenKH"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["Dien_Thoai"].Value.ToString();
            txtDiaChi.Text = row.Cells["Dia_Chi"].Value.ToString();

            OnOff(true);

        }

        string maKH;
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            KhachHang_DTO kh = new KhachHang_DTO();

            kh.MaKH = txtMaKhachHang.Text.ToUpper();
            kh.TenKH = txtTenKhachHang.Text;
            kh.SoDienThoai = txtSoDienThoai.Text;
            kh.DiaChi = txtDiaChi.Text;

            string message;

            bool kq = KhachHang_BUS.ThemKhachHang(kh, out message);

            if (kq)
            {
                MessageBox.Show("Thêm thành công!");
                LayDuLieu();
                btnTaiLai_Click(sender,e);
            }
            else
            {
                MessageBox.Show(message);
            }


        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();

            OnOff(false);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            KhachHang_DTO kh = new KhachHang_DTO();
            
            kh.TenKH = txtTenKhachHang.Text;
            kh.SoDienThoai = txtSoDienThoai.Text;
            kh.DiaChi = txtDiaChi.Text;

            string message;

            bool kq = KhachHang_BUS.SuaKhachHang(kh, txtMaKhachHang.Text , out message);

            if (kq)
            {
                MessageBox.Show("Sửa thành công!");
                LayDuLieu();
                btnTaiLai_Click(sender, e);

            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Bạn có muốn xóa NV: " + txtMaKhachHang.Text + " không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                bool kq = KhachHang_BUS.XoaKhachHang(txtMaKhachHang.Text);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công");
                    txtMaKhachHang.Clear();
                    txtTenKhachHang.Clear();
                    txtSoDienThoai.Clear();
                    txtDiaChi.Clear();
                    OnOff(false);
                    LayDuLieu();                    
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LayDuLieu();
            }
            else 
            {
                dgvKhachHang.DataSource = KhachHang_BUS.TimKiemKh(tuKhoa);
            }
        }
    }
}
