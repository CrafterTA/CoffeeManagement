using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fDisplayTableS : Form
    {
        public fDisplayTableS()
        {
            InitializeComponent();
        }

        private void fDisplayTableS_Load(object sender, EventArgs e)
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


            var selectedTable = TableService.Instance.GetTableByName(tableName);


            var order = OrderService.Instance.CreateOrder(selectedTable.TableID);

            // Truyền dữ liệu
            fDisplayProductS displayProductForm = new fDisplayProductS
            {
                SelectedTable = selectedTable,
                OrderID = order.OrderID
            };
            displayProductForm.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fPresentationS fPresentation = new fPresentationS();
            fPresentation.ShowDialog();
        }
    }
}
