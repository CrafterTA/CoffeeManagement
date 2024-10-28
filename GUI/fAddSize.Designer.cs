namespace GUI
{
    partial class fAddSize
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtAdditionalPrice = new System.Windows.Forms.TextBox();
            this.txtSizeName = new System.Windows.Forms.TextBox();
            this.dgvCRUD = new System.Windows.Forms.DataGridView();
            this.SizeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.txtSizeID = new System.Windows.Forms.TextBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCRUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtAdditionalPrice);
            this.layoutControl1.Controls.Add(this.txtSizeName);
            this.layoutControl1.Controls.Add(this.dgvCRUD);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.txtSizeID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(807, 299, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1167, 680);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtAdditionalPrice
            // 
            this.txtAdditionalPrice.Location = new System.Drawing.Point(114, 41);
            this.txtAdditionalPrice.Name = "txtAdditionalPrice";
            this.txtAdditionalPrice.Size = new System.Drawing.Size(1041, 25);
            this.txtAdditionalPrice.TabIndex = 11;
            // 
            // txtSizeName
            // 
            this.txtSizeName.Location = new System.Drawing.Point(687, 12);
            this.txtSizeName.Name = "txtSizeName";
            this.txtSizeName.Size = new System.Drawing.Size(468, 25);
            this.txtSizeName.TabIndex = 10;
            // 
            // dgvCRUD
            // 
            this.dgvCRUD.AllowUserToAddRows = false;
            this.dgvCRUD.AllowUserToDeleteRows = false;
            this.dgvCRUD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCRUD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCRUD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SizeID,
            this.SizeName,
            this.AdditionalPrice});
            this.dgvCRUD.Location = new System.Drawing.Point(12, 101);
            this.dgvCRUD.Name = "dgvCRUD";
            this.dgvCRUD.ReadOnly = true;
            this.dgvCRUD.RowHeadersWidth = 51;
            this.dgvCRUD.RowTemplate.Height = 24;
            this.dgvCRUD.Size = new System.Drawing.Size(1143, 567);
            this.dgvCRUD.TabIndex = 9;
            // 
            // SizeID
            // 
            this.SizeID.HeaderText = "Mã kích thước";
            this.SizeID.MinimumWidth = 6;
            this.SizeID.Name = "SizeID";
            this.SizeID.ReadOnly = true;
            // 
            // SizeName
            // 
            this.SizeName.HeaderText = "Loại kích thước";
            this.SizeName.MinimumWidth = 6;
            this.SizeName.Name = "SizeName";
            this.SizeName.ReadOnly = true;
            // 
            // AdditionalPrice
            // 
            this.AdditionalPrice.HeaderText = "Giá niêm yết";
            this.AdditionalPrice.MinimumWidth = 6;
            this.AdditionalPrice.Name = "AdditionalPrice";
            this.AdditionalPrice.ReadOnly = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(437, 70);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(332, 27);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Sửa";
            
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(421, 27);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(773, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(382, 27);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            
            // 
            // txtSizeID
            // 
            this.txtSizeID.Location = new System.Drawing.Point(114, 12);
            this.txtSizeID.Name = "txtSizeID";
            this.txtSizeID.Size = new System.Drawing.Size(467, 25);
            this.txtSizeID.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1167, 680);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSizeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(573, 29);
            this.layoutControlItem1.Text = "Mã kích thước:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(90, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnAdd;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(425, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnUpdate;
            this.layoutControlItem5.Location = new System.Drawing.Point(425, 58);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(336, 31);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dgvCRUD;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 89);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1147, 571);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtSizeName;
            this.layoutControlItem7.Location = new System.Drawing.Point(573, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(574, 29);
            this.layoutControlItem7.Text = "Loại kích thước:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(90, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtAdditionalPrice;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1147, 29);
            this.layoutControlItem8.Text = "Giá niêm yết:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(90, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnDelete;
            this.layoutControlItem2.Location = new System.Drawing.Point(761, 58);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(386, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // fAddSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 680);
            this.Controls.Add(this.layoutControl1);
            this.Name = "fAddSize";
            this.Text = "fAddSize";
            this.Load += new System.EventHandler(this.fAddSize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCRUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.TextBox txtAdditionalPrice;
        private System.Windows.Forms.TextBox txtSizeName;
        private System.Windows.Forms.DataGridView dgvCRUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalPrice;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.TextBox txtSizeID;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}