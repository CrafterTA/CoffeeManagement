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
    public partial class FTESTPRODUCT : Form
    {
        List<Category> categories = new List<Category>();
        List<Product> products = new List<Product>();
        public FTESTPRODUCT()
        {
            InitializeComponent();
        }

        private void FTESTPRODUCT_Load(object sender, EventArgs e)
        {
            products = ProductService.Instance.GetAllProducts();
            categories = CategoryService.Instance.GetAllCategories();

            
            foreach (var category in categories)
            {
                comboBoxCategories.Items.Add(category.CategoryName);
            }

            // Hiển thị toàn bộ sản phẩm lần đầu
            DisplayProducts(products);
        }

        // File path
        string baseImagePath = @"D:\Project\Images\";

        private void DisplayProducts(List<Product> productList)
        {
            flpProducts.Controls.Clear();

            foreach (var product in productList)
            {
                Panel productPanel = new Panel
                {
                    Size = new System.Drawing.Size(200, 150),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblProductName = new Label
                {
                    Text = product.ProductName,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };

                PictureBox pbProductImage = new PictureBox();

                //Ket noi File path voi Images
                string fullImagePath = System.IO.Path.Combine(baseImagePath, product.Images);

                if (System.IO.File.Exists(fullImagePath))
                {
                    pbProductImage.ImageLocation = fullImagePath;
                }
                else
                {
                    MessageBox.Show($"Ảnh không tồn tại: {fullImagePath}");
                }

                pbProductImage.Size = new System.Drawing.Size(100, 100);
                pbProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbProductImage.Location = new Point(10, 30);

                productPanel.Controls.Add(lblProductName);
                productPanel.Controls.Add(pbProductImage);

                flpProducts.Controls.Add(productPanel);
            }
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoryID = categories[comboBoxCategories.SelectedIndex].CategoryID;
            var filteredProducts = products.Where(p => p.CategoryID == selectedCategoryID).ToList();

            // Cập nhật danh sách sản phẩm hiển thị
            DisplayProducts(filteredProducts);
        }
    }
}
