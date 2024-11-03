using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace GUI
{
    public partial class fDisplayProduct : Form
    {
        public CF_Table SelectedTable { get; set; }
        private List<OrderDetail> cart = new List<OrderDetail>();
        public int OrderID { get; set; }
        public fDisplayProduct()
        {
            InitializeComponent();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cate = cmbCategory.SelectedValue.ToString();
            LoadProductByCategory(cate);
        }

        private void LoadProductByCategory(string cate)
        {
            flpProduct.Controls.Clear();
            var listProduct = ProductService.Instance.GetProductByCategory(cate);
            var listSizes = ProductService.Instance.GetAllSizes();

            foreach (var item in listProduct)
            {
                Panel pdPanel = new Panel
                {
                    Width = 150,
                    Height = 340,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = item
                };
                PictureBox pbImage = new PictureBox
                {
                    Width = 140,
                    Height = 100,
                    Image = Image.FromStream(new MemoryStream(item.Images)),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                Label lblName = new Label
                {
                    Text = item.ProductName,
                    AutoSize = false,
                    Width = 140,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                Label lblPrice = new Label
                {
                    Text = $"Giá: {item.Price} VND",
                    AutoSize = false,
                    Width = 140,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Green
                };
                Label lblDescription = new Label
                {
                    Text = item.Description,
                    AutoSize = false,
                    Width = 140,
                    Height = 40,
                    TextAlign = ContentAlignment.TopLeft,
                    Font = new Font("Arial", 8),
                    ForeColor = Color.Black
                };
                Label lblQuantity = new Label
                {
                    Text = "1",
                    Width = 30,
                    TextAlign = ContentAlignment.BottomCenter
                };

                ComboBox cmbSize = new ComboBox
                {
                    Width = 140,
                    DataSource = listSizes,
                    DisplayMember = "SizeName",
                    ValueMember = "SizeName"
                };

                Button btnIncrease = new Button
                {
                    Text = "+",
                    Width = 30,
                    Height = 25
                };

                Button btnDecrease = new Button
                {
                    Text = "-",
                    Width = 30,
                    Height = 25
                };
                btnIncrease.Click += (s, e) =>
                {
                    int quantity = int.Parse(lblQuantity.Text);
                    lblQuantity.Text = (++quantity).ToString();
                };
                btnDecrease.Click += (s, e) =>
                {
                    int quantity = int.Parse(lblQuantity.Text);
                    if (quantity > 1) lblQuantity.Text = (--quantity).ToString(); // Không giảm dưới 1
                };
                Button btnAddToCart = new Button
                {
                    Text = "Đặt món",
                    Width = 140,
                    Height = 30,
                    BackColor = Color.OrangeRed,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                btnAddToCart.Click += (s, e) =>
                {
                    int quantity = int.Parse(lblQuantity.Text);
                    string selectedSize = cmbSize.SelectedValue.ToString();
                    AddToCart(item, quantity, selectedSize);
                };
                pdPanel.Click += PdPanel_Click;
                pdPanel.Controls.Add(pbImage);
                pdPanel.Controls.Add(lblName);
                pdPanel.Controls.Add(lblPrice);
                pdPanel.Controls.Add(lblDescription);
                pdPanel.Controls.Add(lblQuantity);
                pdPanel.Controls.Add(cmbSize);
                pdPanel.Controls.Add(btnIncrease);
                pdPanel.Controls.Add(btnDecrease);
                pdPanel.Controls.Add(btnAddToCart);

                pbImage.Top = 10;
                lblName.Top = pbImage.Bottom + 5;
                lblPrice.Top = lblName.Bottom + 5;
                lblDescription.Top = lblPrice.Bottom + 5;
                lblQuantity.Top = lblDescription.Bottom + 5;
                lblQuantity.Left = 55;

                cmbSize.Top = lblQuantity.Bottom + 5;

                btnDecrease.Top = cmbSize.Bottom + 5;
                btnDecrease.Left = 10;

                btnIncrease.Top = cmbSize.Bottom + 5;
                btnIncrease.Left = 100;
                btnAddToCart.Top = btnIncrease.Bottom + 10;
                flpProduct.Controls.Add(pdPanel);
            }
        }

        private void AddToCart(Product product, int quantity, string sizeName)
        {
            var orderDetail = OrderDetailService.Instance.AddToCart(OrderID, product.ProductID, sizeName, quantity);

            if (orderDetail != null)
            {
                // Thêm vào giỏ hàng
                cart.Add(orderDetail);

                MessageBox.Show($"Đã thêm {product.ProductName} - SL: {quantity} - Size: {sizeName} vào giỏ hàng.");
            }
        }




        private void PdPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Product product = panel.Tag as Product;
            ComboBox cmbSize = panel.Controls.OfType<ComboBox>().FirstOrDefault();
            string selectedSize = cmbSize?.SelectedValue?.ToString() ?? "DefaultSize";
            AddToCart(product, 1, selectedSize);
        }

        private void fDisplayProduct_Load(object sender, EventArgs e)
        {
            var listCate = CategoryService.Instance.GetAllCategories();
            FillCmbCategory(listCate);
        }

        private void FillCmbCategory(List<Category> listCate)
        {
            cmbCategory.DataSource = listCate;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }

        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            // Chuyển sang form bill
            fBill billForm = new fBill();
            billForm.SelectedTable = SelectedTable;
            billForm.Cart = cart;
            billForm.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDisplayTable displayTableForm = new fDisplayTable();
            displayTableForm.ShowDialog();
        }
    }
}