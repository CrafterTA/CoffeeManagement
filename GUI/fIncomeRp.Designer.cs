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
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.chartIncome = new DevExpress.XtraCharts.ChartControl();
            this.siticoneControlBox2 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
            this.siticoneControlBox1 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
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
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(909, 634);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(44, 16);
            this.lblIncome.TabIndex = 3;
            this.lblIncome.Text = "label1";
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
            this.lblMonth.Location = new System.Drawing.Point(434, 634);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(44, 16);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "label1";
            // 
            // chartIncome
            // 
            this.chartIncome.Location = new System.Drawing.Point(150, 104);
            this.chartIncome.Name = "chartIncome";
            this.chartIncome.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartIncome.Size = new System.Drawing.Size(828, 369);
            this.chartIncome.TabIndex = 4;
            // 
            // siticoneControlBox2
            // 
            this.siticoneControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox2.ControlBoxType = Siticone.Desktop.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox2.FillColor = System.Drawing.Color.White;
            this.siticoneControlBox2.IconColor = System.Drawing.Color.Black;
            this.siticoneControlBox2.Location = new System.Drawing.Point(1064, -4);
            this.siticoneControlBox2.Name = "siticoneControlBox2";
            this.siticoneControlBox2.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox2.TabIndex = 6;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.FillColor = System.Drawing.Color.Red;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(1106, -4);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 5;
            // 
            // fIncomeRp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 702);
            this.Controls.Add(this.siticoneControlBox2);
            this.Controls.Add(this.siticoneControlBox1);
            this.Controls.Add(this.chartIncome);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblIncome);
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
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private DevExpress.XtraCharts.ChartControl chartIncome;
        private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox2;
        private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox1;
    }
}