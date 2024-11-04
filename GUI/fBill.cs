using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL;
using VietQRHelper;

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


            this.Close();
            var displayTableForm = Application.OpenForms.OfType<fDisplayTable>().FirstOrDefault();
            if (displayTableForm != null)
            {
                displayTableForm.Show();
            }
            else
            {
                fDisplayTable newDisplayTableForm = new fDisplayTable();
                newDisplayTableForm.Show();
            }

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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fPresentation fPresentation = new fPresentation();
            fPresentation.ShowDialog();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            var qrPay = QRPay.InitVietQR(bankBin: BankApp.BanksObject[BankKey.MBBANK].bin,
                bankNumber: "0886927460"
                );
            var content = qrPay.Build();
            var imageQR = QRCodeHelper.TaoVietQRCodeImage(content);
            pbBank.Image = imageQR;
        }
    }
}