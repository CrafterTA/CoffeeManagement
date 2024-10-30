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

namespace GUI
{
    public partial class fDisplayProduct : Form
    {
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
            foreach (var item in listProduct)
            {
                Panel pdPanel = new Panel
                {
                    Width = 150,
                    Height = 285,
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
                    TextAlign = ContentAlignment.MiddleCenter
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
                    Text = "Chọn Mua",
                    Width = 140,
                    Height = 30,
                    BackColor = Color.OrangeRed,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                btnAddToCart.Click += (s, e) =>
                {
                    int quantity = int.Parse(lblQuantity.Text);
                    AddToBill(item, quantity);
                };
                pdPanel.Click += PdPanel_Click;
                pdPanel.Controls.Add(pbImage);
                pdPanel.Controls.Add(lblName);
                pdPanel.Controls.Add(lblPrice);
                pdPanel.Controls.Add(lblDescription);
                pdPanel.Controls.Add(lblQuantity);
                pdPanel.Controls.Add(btnIncrease);
                pdPanel.Controls.Add(btnDecrease);
                pdPanel.Controls.Add(btnAddToCart);

                pbImage.Top = 10;
                lblName.Top = pbImage.Bottom + 5;
                lblPrice.Top = lblName.Bottom + 5;
                lblDescription.Top = lblPrice.Bottom + 5;
                lblQuantity.Top = lblDescription.Bottom + 5;
                lblQuantity.Left = 55;

                btnDecrease.Top = lblDescription.Bottom + 5;
                btnDecrease.Left = 10;

                btnIncrease.Top = lblDescription.Bottom + 5;
                btnIncrease.Left = 100;
                btnAddToCart.Top = lblQuantity.Bottom + 10;
                flpProduct.Controls.Add(pdPanel);
            }
        }

        private void PdPanel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddToBill(Product item, int quantity)
        {
            // Logic thêm sản phẩm vào hóa đơn hoặc danh sách thanh toán
            // Có thể lưu thông tin sản phẩm và số lượng trong danh sách, rồi sau đó hiển thị hóa đơn
            MessageBox.Show($"Đã thêm {item.ProductName} - SL: {quantity} vào hóa đơn.");
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
    }
}
