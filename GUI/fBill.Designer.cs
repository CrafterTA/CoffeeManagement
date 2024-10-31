namespace GUI
{
    partial class fBill
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
            this.lstBill = new System.Windows.Forms.ListView();
            this.lblTableName = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.lblTotal = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
            this.SuspendLayout();
            // 
            // lstBill
            // 
            this.lstBill.HideSelection = false;
            this.lstBill.Location = new System.Drawing.Point(86, 189);
            this.lstBill.Name = "lstBill";
            this.lstBill.Size = new System.Drawing.Size(1031, 493);
            this.lstBill.TabIndex = 0;
            this.lstBill.UseCompatibleStateImageBehavior = false;
            // 
            // lblTableName
            // 
            this.lblTableName.BackColor = System.Drawing.Color.Transparent;
            this.lblTableName.Location = new System.Drawing.Point(224, 133);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(90, 18);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "lblTableName";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Location = new System.Drawing.Point(446, 133);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 18);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "lblTableName";
            // 
            // fBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 723);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lstBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fBill";
            this.Text = "fBill";
            this.Load += new System.EventHandler(this.fBill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstBill;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel lblTableName;
        private Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel lblTotal;
    }
}