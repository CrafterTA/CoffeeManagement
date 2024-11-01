using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;

namespace GUI
{
    public partial class fBill : Form
    {
        public CF_Table SelectedTable { get; set; }
        public List<OrderDetail> Cart { get; set; }

        public fBill()
        {
            InitializeComponent();
        }

        private void fBill_Load(object sender, EventArgs e)
        {
            DisplayBill();
        }

        private void DisplayBill()
        {
            // Display tt ban
            lblTableName.Text = SelectedTable.TableName;

            // Display sp trong cart
            decimal totalAmount = 0;
            dgvBill.Rows.Clear(); 
            foreach (var item in Cart)
            {
                var productSize = ProductSizeService.Instance.GetProductSizeByID(item.ProductSizeID);
                var product = ProductService.Instance.GetProductByID(productSize.ProductID);
                var size = SizeService.Instance.GetSizeByName(productSize.SizeName);
                decimal itemTotal = item.Quantity.Value * (product.Price + size.SizePrice.Value);
                totalAmount += itemTotal;

                // Add row to DataGridView
                dgvBill.Rows.Add(product.ProductName, size.SizeName, item.Quantity, itemTotal);
            }

            lblTotal.Text = $"Tổng tiền: {totalAmount} VND";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            foreach (var item in Cart)
            {
                BillService.Instance.CreateBill(item.OrderDetailID, DateTime.Now, "Đã thanh toán");
            }

            MessageBox.Show("Thanh toán thành công!");

            // Cập nhật biểu đồ doanh số
            UpdateSalesChart();

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã bị hủy.");
            this.Close();
            var displayTableForm = Application.OpenForms.OfType<fDisplayTable>().FirstOrDefault();
            if (displayTableForm != null)
            {
                displayTableForm.Show();
            }
        }
        private void UpdateSalesChart()
        {
            // Cập nhật biểu đồ doanh số
            var salesReportForm = Application.OpenForms.OfType<fIncomeRp>().FirstOrDefault();
            if (salesReportForm != null)
            {
                salesReportForm.UpdateChart();
            }
        }
    }
}