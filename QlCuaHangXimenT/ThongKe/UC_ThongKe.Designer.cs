namespace QlCuaHangXimenT.ThongKe
{
    partial class UC_ThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tcThongKe = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabTongHop = new System.Windows.Forms.TabPage();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.guna2Panel5.SuspendLayout();
            this.tcThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 50);
            this.label1.TabIndex = 158;
            this.label1.Text = "Thống kê";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(53, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 16);
            this.label2.TabIndex = 159;
            this.label2.Text = "Thống kê và báo cáo doanh thu";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(244, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 23);
            this.label8.TabIndex = 182;
            this.label8.Text = "Ngày kết thúc";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(7, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 23);
            this.label7.TabIndex = 181;
            this.label7.Text = "Ngày bắt đầu:";
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.CustomFormat = "dd-MM-yyyy";
            this.dtpKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(248, 35);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(200, 27);
            this.dtpKetThuc.TabIndex = 184;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "dd-MM-yyyy";
            this.dtpBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(11, 35);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(200, 27);
            this.dtpBatDau.TabIndex = 183;
            this.dtpBatDau.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel5.BorderRadius = 15;
            this.guna2Panel5.BorderThickness = 1;
            this.guna2Panel5.Controls.Add(this.label8);
            this.guna2Panel5.Controls.Add(this.label7);
            this.guna2Panel5.Controls.Add(this.dtpKetThuc);
            this.guna2Panel5.Controls.Add(this.dtpBatDau);
            this.guna2Panel5.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.Location = new System.Drawing.Point(799, 30);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(455, 75);
            this.guna2Panel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(795, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 185;
            this.label3.Text = "Lọc dữ liệu:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Black;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1116, 111);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(138, 38);
            this.guna2Button1.TabIndex = 186;
            this.guna2Button1.Text = "Xuất báo cáo";
            // 
            // tcThongKe
            // 
            this.tcThongKe.Controls.Add(this.tabTongHop);
            this.tcThongKe.Controls.Add(this.tabSanPham);
            this.tcThongKe.Controls.Add(this.tabDoanhThu);
            this.tcThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcThongKe.ItemSize = new System.Drawing.Size(180, 50);
            this.tcThongKe.Location = new System.Drawing.Point(0, 155);
            this.tcThongKe.Name = "tcThongKe";
            this.tcThongKe.SelectedIndex = 0;
            this.tcThongKe.Size = new System.Drawing.Size(1311, 628);
            this.tcThongKe.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonHoverState.InnerColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonIdleState.FillColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcThongKe.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tcThongKe.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcThongKe.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonSelectedState.InnerColor = System.Drawing.Color.Black;
            this.tcThongKe.TabButtonSize = new System.Drawing.Size(180, 50);
            this.tcThongKe.TabIndex = 189;
            this.tcThongKe.TabMenuBackColor = System.Drawing.Color.Black;
            this.tcThongKe.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabTongHop
            // 
            this.tabTongHop.ForeColor = System.Drawing.Color.White;
            this.tabTongHop.Location = new System.Drawing.Point(4, 54);
            this.tabTongHop.Name = "tabTongHop";
            this.tabTongHop.Padding = new System.Windows.Forms.Padding(3);
            this.tabTongHop.Size = new System.Drawing.Size(1303, 570);
            this.tabTongHop.TabIndex = 0;
            this.tabTongHop.Text = "Tổng hợp";
            this.tabTongHop.UseVisualStyleBackColor = true;
            // 
            // tabSanPham
            // 
            this.tabSanPham.Location = new System.Drawing.Point(4, 54);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tabSanPham.Size = new System.Drawing.Size(1303, 570);
            this.tabSanPham.TabIndex = 1;
            this.tabSanPham.Text = "Thông kế Sản phẩm";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 54);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(1303, 570);
            this.tabDoanhThu.TabIndex = 2;
            this.tabDoanhThu.Text = "Thống kê Doanh thu";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // UC_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcThongKe);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel5);
            this.Name = "UC_ThongKe";
            this.Size = new System.Drawing.Size(1311, 783);
            this.Load += new System.EventHandler(this.UC_ThongKe_Load);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.tcThongKe.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TabControl tcThongKe;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.TabPage tabTongHop;
        private System.Windows.Forms.TabPage tabDoanhThu;
    }
}
