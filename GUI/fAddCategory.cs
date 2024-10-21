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
    public partial class fAddCategory : Form
    {
        public fAddCategory()
        {
            InitializeComponent();
        }

        private void fAddCategory_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvCRUD);
                var listCategory = CategoryService.Instance.GetAllCategories();
                BindGrid(listCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Category> listCategory)
        {
            dgvCRUD.Rows.Clear();
            foreach (var item in listCategory)
            {
                int index = dgvCRUD.Rows.Add();
                dgvCRUD.Rows[index].Cells[0].Value = item.CategoryID;
                dgvCRUD.Rows[index].Cells[1].Value = item.CategoryName;
                dgvCRUD.Rows[index].Cells[2].Value = item.Description;
            }
        }

        private void setGridViewStyle(DataGridView dgvCRUD)
        {
            dgvCRUD.BorderStyle = BorderStyle.None;
            dgvCRUD.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvCRUD.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCRUD.BackgroundColor = Color.White;
            dgvCRUD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string categoryID = txtCategoryID.Text;
            string categoryName = txtCategoryName.Text;
            string description = txtDescription.Text;
            if (CategoryService.Instance.AddCategory(categoryID, categoryName, description))
            {
                MessageBox.Show("Thêm danh mục thành công");
                List<Category> categoryList;
                categoryList = CategoryService.Instance.GetAllCategories();
                BindGrid(categoryList);
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CategoryService.Instance.UpdateCategory(new Category
            {
                CategoryID = txtCategoryID.Text,
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            });
            BindGrid(CategoryService.Instance.GetAllCategories());

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var categoryID = txtCategoryID.Text;
            if (CategoryService.Instance.DeleteCategory(categoryID))
            {
                MessageBox.Show("Xóa danh mục thành công");
                List<Category> categoryList;
                categoryList = CategoryService.Instance.GetAllCategories();
                BindGrid(categoryList);
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại");
            }
        }
    }
}
