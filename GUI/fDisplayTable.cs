using BUS;
using DAL;
using DevExpress.XtraPrinting.Shape.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fDisplayTable : Form
    {
        public fDisplayTable()
        {
            InitializeComponent();
        }

        private void fDisplayTable_Load(object sender, EventArgs e)
        {
            var listArea = AreaService.Instance.GetAllAreas();
            FillCmbArea(listArea);
        }

        private void FillCmbArea(List<Area> listArea)
        {
            cmbArea.DataSource = listArea;
            cmbArea.DisplayMember = "AreaName";
            cmbArea.ValueMember = "AreaID";
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string area = cmbArea.SelectedValue.ToString();
            LoadTableByArea(area);
        }

        private void LoadTableByArea(string area)
        {
            flpTable.Controls.Clear();
            var listTable = TableService.Instance.GetTableByArea(area);
            foreach (var item in listTable)
            {
                Button btnTable = new Button
                {
                    Width = 140,
                    Height = 100,
                    Text = item.TableName,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btnTable.Click += BtnTable_Click;
                flpTable.Controls.Add(btnTable);

            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btnTable = sender as Button;
            string tableName = btnTable.Text;

            // Lưu thông tin bàn 
            var table = TableService.Instance.GetTableByName(tableName);

            //Truyền dữ liệu của bàn
            fDisplayProduct displayProductForm = new fDisplayProduct();
            displayProductForm.SelectedTable = table;
            displayProductForm.Show();
            this.Hide();
        }
    }
}
