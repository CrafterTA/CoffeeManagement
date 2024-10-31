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
            // Hiển thị thông tin bàn
            lblTableName.Text = SelectedTable.TableName;

            // Hiển thị thông tin sản phẩm trong giỏ hàng
            decimal totalAmount = 0;
            foreach (var item in Cart)
            {
                var productSize = ProductSizeService.Instance.GetProductSizeByID(item.ProductSizeID); // Convert int to string
                var product = ProductService.Instance.GetProductByID(productSize.ProductID);
                var size = SizeService.Instance.GetSizeByName(productSize.SizeName);
                decimal itemTotal = item.Quantity.Value * (product.Price + size.SizePrice.Value);
                totalAmount += itemTotal; 

                // Hiển thị chi tiết sản phẩm
                lstBill.Items.Add($"{product.ProductName} - Size: {size.SizeName} - SL: {item.Quantity} - Tổng: {itemTotal} VND");
            }

            // Hiển thị tổng tiền
            lblTotal.Text = $"Tổng tiền: {totalAmount} VND";
        }
    }
}