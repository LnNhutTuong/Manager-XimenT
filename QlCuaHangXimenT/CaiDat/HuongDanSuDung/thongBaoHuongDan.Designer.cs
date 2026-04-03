namespace QlCuaHangXimenT.CaiDat.HuongDanSuDung
{
    partial class thongBaoHuongDan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAnHuongDan = new System.Windows.Forms.CheckBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnDiDen = new Guna.UI2.WinForms.Guna2Button();
            this.btnToiBietTuot = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xem hướng dẫn sử dụng trong phần Cài đặt.\r\n";
            // 
            // chkAnHuongDan
            // 
            this.chkAnHuongDan.AutoSize = true;
            this.chkAnHuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnHuongDan.Location = new System.Drawing.Point(132, 88);
            this.chkAnHuongDan.Name = "chkAnHuongDan";
            this.chkAnHuongDan.Size = new System.Drawing.Size(193, 24);
            this.chkAnHuongDan.TabIndex = 1;
            this.chkAnHuongDan.Text = "Không hiện cho lần sau";
            this.chkAnHuongDan.UseVisualStyleBackColor = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnDiDen
            // 
            this.btnDiDen.BorderColor = System.Drawing.Color.White;
            this.btnDiDen.BorderThickness = 1;
            this.btnDiDen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDiDen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDiDen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDiDen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDiDen.FillColor = System.Drawing.Color.Black;
            this.btnDiDen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiDen.ForeColor = System.Drawing.Color.White;
            this.btnDiDen.Location = new System.Drawing.Point(167, 43);
            this.btnDiDen.Name = "btnDiDen";
            this.btnDiDen.Size = new System.Drawing.Size(136, 39);
            this.btnDiDen.TabIndex = 9;
            this.btnDiDen.Text = "Đi đến";
            this.btnDiDen.Click += new System.EventHandler(this.btnDiDen_Click);
            // 
            // btnToiBietTuot
            // 
            this.btnToiBietTuot.BorderThickness = 1;
            this.btnToiBietTuot.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToiBietTuot.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToiBietTuot.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToiBietTuot.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToiBietTuot.FillColor = System.Drawing.Color.White;
            this.btnToiBietTuot.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToiBietTuot.ForeColor = System.Drawing.Color.Black;
            this.btnToiBietTuot.Location = new System.Drawing.Point(25, 43);
            this.btnToiBietTuot.Name = "btnToiBietTuot";
            this.btnToiBietTuot.Size = new System.Drawing.Size(136, 39);
            this.btnToiBietTuot.TabIndex = 10;
            this.btnToiBietTuot.Text = "Tôi biết tuốt!";
            this.btnToiBietTuot.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // thongBaoHuongDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(329, 113);
            this.Controls.Add(this.btnToiBietTuot);
            this.Controls.Add(this.btnDiDen);
            this.Controls.Add(this.chkAnHuongDan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "thongBaoHuongDan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "thongBaoHuongDan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAnHuongDan;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnToiBietTuot;
        private Guna.UI2.WinForms.Guna2Button btnDiDen;
    }
}