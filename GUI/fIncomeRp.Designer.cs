namespace GUI
{
    partial class fIncomeRp
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
            this.dtpIncome = new Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker();
            this.btnIncomeDay = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnIncomeMonth = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnIncomeYear = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.lblIncome = new System.Windows.Forms.Label();
            this.chartIncome = new DevExpress.XtraCharts.ChartControl();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpIncome
            // 
            this.dtpIncome.Checked = true;
            this.dtpIncome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpIncome.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpIncome.Location = new System.Drawing.Point(150, 5);
            this.dtpIncome.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpIncome.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpIncome.Name = "dtpIncome";
            this.dtpIncome.Size = new System.Drawing.Size(263, 36);
            this.dtpIncome.TabIndex = 0;
            this.dtpIncome.Value = new System.DateTime(2024, 11, 2, 1, 36, 33, 590);
            // 
            // btnIncomeDay
            // 
            this.btnIncomeDay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeDay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIncomeDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIncomeDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIncomeDay.ForeColor = System.Drawing.Color.White;
            this.btnIncomeDay.Location = new System.Drawing.Point(215, 624);
            this.btnIncomeDay.Name = "btnIncomeDay";
            this.btnIncomeDay.Size = new System.Drawing.Size(180, 45);
            this.btnIncomeDay.TabIndex = 2;
            this.btnIncomeDay.Text = "Doanh thu theo ngày";
            this.btnIncomeDay.Click += new System.EventHandler(this.btnIncomeDay_Click);
            // 
            // btnIncomeMonth
            // 
            this.btnIncomeMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIncomeMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIncomeMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIncomeMonth.ForeColor = System.Drawing.Color.White;
            this.btnIncomeMonth.Location = new System.Drawing.Point(740, 624);
            this.btnIncomeMonth.Name = "btnIncomeMonth";
            this.btnIncomeMonth.Size = new System.Drawing.Size(180, 45);
            this.btnIncomeMonth.TabIndex = 2;
            this.btnIncomeMonth.Text = "Doanh thu theo tháng";
            this.btnIncomeMonth.Click += new System.EventHandler(this.btnIncomeMonth_Click);
            // 
            // btnIncomeYear
            // 
            this.btnIncomeYear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeYear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIncomeYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIncomeYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIncomeYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIncomeYear.ForeColor = System.Drawing.Color.White;
            this.btnIncomeYear.Location = new System.Drawing.Point(474, 624);
            this.btnIncomeYear.Name = "btnIncomeYear";
            this.btnIncomeYear.Size = new System.Drawing.Size(180, 45);
            this.btnIncomeYear.TabIndex = 2;
            this.btnIncomeYear.Text = "Doanh thu theo năm";
            this.btnIncomeYear.Click += new System.EventHandler(this.btnIncomeYear_Click);
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(982, 25);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(44, 16);
            this.lblIncome.TabIndex = 3;
            this.lblIncome.Text = "label1";
            // 
            // chartIncome
            // 
            this.chartIncome.Location = new System.Drawing.Point(141, 81);
            this.chartIncome.Name = "chartIncome";
            this.chartIncome.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartIncome.Size = new System.Drawing.Size(929, 511);
            this.chartIncome.TabIndex = 4;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(147, 62);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(44, 16);
            this.lblDay.TabIndex = 3;
            this.lblDay.Text = "label1";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(718, 51);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(44, 16);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "label1";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(462, 9);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(44, 16);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "label1";
            // 
            // fIncomeRp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 702);
            this.Controls.Add(this.chartIncome);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.btnIncomeYear);
            this.Controls.Add(this.btnIncomeMonth);
            this.Controls.Add(this.btnIncomeDay);
            this.Controls.Add(this.dtpIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fIncomeRp";
            this.Text = "fIncomeRp";
            this.Load += new System.EventHandler(this.fIncomeRp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartIncome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneDateTimePicker dtpIncome;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnIncomeDay;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnIncomeMonth;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnIncomeYear;
        private System.Windows.Forms.Label lblIncome;
        private DevExpress.XtraCharts.ChartControl chartIncome;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
    }
}