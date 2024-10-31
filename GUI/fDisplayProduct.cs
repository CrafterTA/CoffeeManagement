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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GUI
{
    public partial class fDisplayProduct : Form
    {
        private List<OrderDetail> cart = new List<OrderDetail>();
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
            var listSizes = ProductService.Instance.GetAllSizes(); // Lấy danh sách kích thước

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
                    TextAlign = ContentAlignment.MiddleCenter
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
            // Thêm sản phẩm và kích thước vào bảng ProductSize nếu chưa tồn tại
            ProductService.Instance.CreateProductSize(product.ProductID, sizeName);

            // Lấy ProductSizeID vừa thêm
            var productSize = DALProductSize.Instance.Information()
                .FirstOrDefault(ps => ps.ProductID == product.ProductID && ps.SizeName == sizeName);

            if (productSize != null)
            {
                // Thêm ctdh vào giỏ hàng
                var orderDetail = new OrderDetail
                {
                    ProductSizeID = productSize.ProductSizeID,
                    Quantity = quantity
                };
                cart.Add(orderDetail);
                MessageBox.Show($"Đã thêm {product.ProductName} - SL: {quantity} - Size: {sizeName} vào giỏ hàng.");
            }
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Tạo đơn hàng mới
            var order = new Order
            {
                DateCheckIn = DateTime.Now,
                Status = "Pending"
            };
            CafeEntities.Instance.Orders.Add(order);
            CafeEntities.Instance.SaveChanges();

            // Thêm chi tiết đơn hàng vào bảng OrderDetail và tạo hóa đơn
            foreach (var orderDetail in cart)
            {
                orderDetail.OrderID = order.OrderID;
                CafeEntities.Instance.OrderDetails.Add(orderDetail);
                CafeEntities.Instance.SaveChanges();

                ProductService.Instance.CreateBill(orderDetail.OrderDetailID, DateTime.Now, "Paid");
            }

            // Tính tổng tiền
            decimal totalAmount = cart.Sum(od => (od.Quantity ?? 0) * od.ProductSize.Product.Price + (od.ProductSize.Size.SizePrice ?? 0m));
            MessageBox.Show($"Tổng tiền: {totalAmount} VND");

            //Thanh toán xong thì xóa giỏ hàng
            cart.Clear();
        }
        private void PdPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Product product = panel.Tag as Product;
            ComboBox cmbSize = panel.Controls.OfType<ComboBox>().FirstOrDefault();
            string selectedSize = cmbSize?.SelectedValue?.ToString() ?? "DefaultSize";
            AddToCart(product, 1, selectedSize);
        }
        private void AddToBill(Product item, int quantity)
        {
            ProductService.Instance.CreateProductSize(item.ProductID, "DefaultSize");

            //Lấy thông tin ProductSize vừa thêm
            var productSize = DALProductSize.Instance.Information()
                .FirstOrDefault(ps => ps.ProductID == item.ProductID && ps.SizeName == "DefaultSize");

            if (productSize != null)
            {
                // Thêm ctdh vô OrderDetail
                ProductService.Instance.CreateOrderDetail(productSize.ProductSizeID, 1, quantity); // Giả sử OrderID là 1

                // Tạo hóa đơn trong bảng Bill
                var orderDetail = DALOrderDetail.Instance.GetAllOrderDetails()
                    .FirstOrDefault(od => od.ProductSizeID == productSize.ProductSizeID && od.OrderID == 1);

                if (orderDetail != null)
                {
                    ProductService.Instance.CreateBill(orderDetail.OrderDetailID, DateTime.Now, "Thanh toán");
                    MessageBox.Show($"Đã thêm {item.ProductName} - SL: {quantity} vào hóa đơn.");
                }
            }
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
