namespace GUI
{
    partial class FTESTPRODUCT
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
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flpProducts
            // 
            this.flpProducts.Location = new System.Drawing.Point(34, 45);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(984, 549);
            this.flpProducts.TabIndex = 0;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(34, 12);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCategories.TabIndex = 1;
            
            // 
            // FTESTPRODUCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 647);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.flpProducts);
            this.Name = "FTESTPRODUCT";
            this.Text = "FTESTPRODUCT";
           
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.ComboBox comboBoxCategories;
    }
}