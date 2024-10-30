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
using System.Xml.Linq;

namespace GUI
{
    public partial class fCRUD : Form
    {
        public fCRUD()
        {
            InitializeComponent();
        }
        //Category
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
        private void dgvCRUD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvCRUD.Rows[e.RowIndex];
                txtCategoryID.Text = selectedRow.Cells[0].Value?.ToString();
                txtCategoryName.Text = selectedRow.Cells[1].Value?.ToString();
                txtDescription.Text = selectedRow.Cells[2].Value?.ToString();

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();
            List<Category> category = CategoryService.Instance.SearchCategory(search);
            BindGrid(category);
        }

        private void fCRUD_Load(object sender, EventArgs e)
        {
            try
            {
                var listCategory = CategoryService.Instance.GetAllCategories();
                BindGrid(listCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listProduct = ProductService.Instance.GetAllProducts();
                var listCategory = CategoryService.Instance.GetAllCategories();
                BindGridProduct(listProduct);
                FillCmbCategory(listCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listSize = SizeService.Instance.GetAllSizes();
                BindGridSize(listSize);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listRole = RoleService.Instance.GetAllRoles();
                BindGridRole(listRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listUser = UserService.Instance.GetAllUsers();
                var listRole = RoleService.Instance.GetAllRoles();
                FillCmbRole(listRole);
                BindGridUser(listUser);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listArea = AreaService.Instance.GetAllAreas();

                BindGridArea(listArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var listTable = TableService.Instance.GetAllTables();
                var listArea = AreaService.Instance.GetAllAreas();
                BindGridTable(listTable);
                FillCmbArea(listArea);
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
        //Product
        private void FillCmbCategory(List<Category> listCategory)
        {
            cmbCategory.DataSource = listCategory;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return b;
        }
        private void btnInsertP_Click(object sender, EventArgs e)
        {
            byte[] avatarData = pbImage.Image != null ? ImageToByteArray(pbImage.Image) : null;
            string productID = txtProductID.Text;
            string productName = txtProductName.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string categoryID = ((Category)cmbCategory.SelectedItem).CategoryID;
            string description = txtDescriptionP.Text;
            byte[] image = avatarData;

            if (ProductService.Instance.AddProduct(productID, productName, categoryID, price, description, image))
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                List<Product> productList = ProductService.Instance.GetAllProducts();
                BindGridProduct(productList);
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại");
            }
        }
        private void BindGridProduct(List<Product> listProduct)
        {
            dgvProduct.Rows.Clear();
            foreach (var item in listProduct)
            {
                int index = dgvProduct.Rows.Add();
                dgvProduct.Rows[index].Cells[0].Value = item.ProductID;
                dgvProduct.Rows[index].Cells[1].Value = item.ProductName;
                dgvProduct.Rows[index].Cells[2].Value = item.Price;
                dgvProduct.Rows[index].Cells[3].Value = item.CategoryID;
                dgvProduct.Rows[index].Cells[4].Value = item.Description;
                if (item.Images != null)
                {
                    var image = ByteArrayToImage(item.Images);
                    dgvProduct.Rows[index].Cells[5].Value = ResizeImage(image, 50, 50);
                }
                else
                {
                    dgvProduct.Rows[index].Cells[5].Value = null;
                }
            }
            ResetControlP();
        }

        private void ResetControlP()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtDescriptionP.Clear();
            pbImage.Image = null;
            cmbCategory.SelectedIndex = -1;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnUpdateP_Click(object sender, EventArgs e)
        {
            ProductService.Instance.UpdateProduct(new Product
            {
                ProductID = txtProductID.Text,
                ProductName = txtProductName.Text,
                Price = decimal.Parse(txtPrice.Text),
                CategoryID = ((Category)cmbCategory.SelectedItem).CategoryName,
                Description = txtDescriptionP.Text,
                Images = pbImage.Image != null ? ImageToByteArray(pbImage.Image) : null
            });

            BindGridProduct(ProductService.Instance.GetAllProducts());
            ResetControlP();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                var selectedRow = dgvProduct.Rows[e.RowIndex];

                
                txtProductID.Text = selectedRow.Cells[0].Value?.ToString();
                txtProductName.Text = selectedRow.Cells[1].Value?.ToString();
                txtPrice.Text = selectedRow.Cells[2].Value?.ToString();
                cmbCategory.SelectedValue = selectedRow.Cells[3].Value; 

                
                txtDescriptionP.Text = selectedRow.Cells[4].Value?.ToString();

                
                if (selectedRow.Cells[5].Value is byte[] imageBytes)
                {
                    pbImage.Image = ByteArrayToImage(imageBytes);
                }
                else
                {
                    pbImage.Image = null;
                }
            }
        }

        private void txtSearchP_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchP.Text.Trim().ToLower();
            List<Product> product = ProductService.Instance.SearchProduct(search);
            BindGridProduct(product);
        }

        private void btnDeleteP_Click(object sender, EventArgs e)
        {
            try
            {
                var productID = txtProductID.Text;
                if (ProductService.Instance.DeleteProduct(productID))
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    List<Product> productList = ProductService.Instance.GetAllProducts();
                    BindGridProduct(productList);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Size
        private void BindGridSize(List<DAL.Size> listSize)
        {
            dgvSize.Rows.Clear();
            foreach (var item in listSize)
            {
                int index = dgvSize.Rows.Add();
                dgvSize.Rows[index].Cells[0].Value = item.SizeName;
                dgvSize.Rows[index].Cells[1].Value = item.SizePrice;
            }
        }

        private void btnInsertS_Click(object sender, EventArgs e)
        {
            string sizeName = txtSizeName.Text;
            decimal sizePrice = decimal.Parse(txtSizePrice.Text);
            if (SizeService.Instance.AddSize(sizeName, sizePrice))
            {
                MessageBox.Show("Thêm size thành công");
                List<DAL.Size> sizeList = SizeService.Instance.GetAllSizes();
                BindGridSize(sizeList);
                ResetControlS();
            }
            else
            {
                MessageBox.Show("Thêm size thất bại");
            }
        }

        private void ResetControlS()
        {
            txtSizeName.Clear();
            txtSizePrice.Clear();
        }

        private void btnUpdateS_Click(object sender, EventArgs e)
        {
            SizeService.Instance.UpdateSize(new DAL.Size
            {
                SizeName = txtSizeName.Text,
                SizePrice = decimal.Parse(txtSizePrice.Text)
            });

            BindGridSize(SizeService.Instance.GetAllSizes());
            ResetControlS();
        }

        private void btnDeleteS_Click(object sender, EventArgs e)
        {
            try
            {
                var sizeName = txtSizeName.Text;
                if (SizeService.Instance.DeleteSize(sizeName))
                {
                    MessageBox.Show("Xóa size thành công");
                    List<DAL.Size> sizeList = SizeService.Instance.GetAllSizes();
                    BindGridSize(sizeList);
                    ResetControlS();
                }
                else
                {
                    MessageBox.Show("Xóa size thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchS_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchS.Text.Trim().ToLower();
            List<DAL.Size> size = SizeService.Instance.SearchSize(search);
            BindGridSize(size);
        }

        private void dgvSize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvSize.Rows[e.RowIndex];
                txtSizeName.Text = selectedRow.Cells[0].Value?.ToString();
                txtSizePrice.Text = selectedRow.Cells[1].Value?.ToString();
            }
        }
        //Role
        private void BindGridRole(List<Role> listRole)
        {
            dgvRole.Rows.Clear();
            foreach (var item in listRole)
            {
                int index = dgvRole.Rows.Add();
                dgvRole.Rows[index].Cells[0].Value = item.RoleID;
                dgvRole.Rows[index].Cells[1].Value = item.RoleName;
            }
        }
        private void ResetControlR()
        {
            txtRoleID.Clear();
            txtRoleName.Clear();
        }

        private void btnInsertR_Click(object sender, EventArgs e)
        {
            string roleID = txtRoleID.Text;
            string roleName = txtRoleName.Text;
            if (RoleService.Instance.AddRole(roleID, roleName))
            {
                MessageBox.Show("Thêm vai trò thành công");
                List<Role> roleList = RoleService.Instance.GetAllRoles();
                BindGridRole(roleList);
                ResetControlR();
            }
            else
            {
                MessageBox.Show("Thêm vai trò thất bại");
            }
        }

        private void btnUpdateR_Click(object sender, EventArgs e)
        {
            RoleService.Instance.UpdateRole(new Role
            {
                RoleID = txtRoleID.Text,
                RoleName = txtRoleName.Text
            });

            BindGridRole(RoleService.Instance.GetAllRoles());
            ResetControlR();
        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            try
            {
                var roleID = txtRoleID.Text;
                if (RoleService.Instance.DeleteRole(roleID))
                {
                    MessageBox.Show("Xóa vai trò thành công");
                    List<Role> roleList = RoleService.Instance.GetAllRoles();
                    BindGridRole(roleList);
                    ResetControlR();
                }
                else
                {
                    MessageBox.Show("Xóa vai trò thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvRole.Rows[e.RowIndex];
                txtRoleID.Text = selectedRow.Cells[0].Value?.ToString();
                txtRoleName.Text = selectedRow.Cells[1].Value?.ToString();
            }
        }

        private void txtSearchR_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchR.Text.Trim().ToLower();
            List<Role> role = RoleService.Instance.SearchRole(search);
            BindGridRole(role);
        }
        //User
        private void BindGridUser(List<User> listUser)
        {
            dgvUser.Rows.Clear();
            foreach (var item in listUser)
            {
                int index = dgvUser.Rows.Add();
                dgvUser.Rows[index].Cells[0].Value = item.UserName;
                dgvUser.Rows[index].Cells[1].Value = item.Userpassword;
                dgvUser.Rows[index].Cells[2].Value = item.FullName;
                dgvUser.Rows[index].Cells[3].Value = item.Phone;
                dgvUser.Rows[index].Cells[4].Value = item.IdentityCard;
                dgvUser.Rows[index].Cells[5].Value = item.RoleID;
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvUser.Rows[e.RowIndex];
                txtUserName.Text = selectedRow.Cells[0].Value?.ToString();
                txtPassword.Text = selectedRow.Cells[1].Value?.ToString();
                txtFullName.Text = selectedRow.Cells[2].Value?.ToString();
                txtPhone.Text = selectedRow.Cells[3].Value?.ToString();
                txtCCCD.Text = selectedRow.Cells[4].Value?.ToString();
                txtRoleID.Text = selectedRow.Cells[5].Value?.ToString();
            }
        }
        private void ResetControlU()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtCCCD.Clear();
            txtRoleID.Clear();
        }

        private void btnInsertU_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string phone = txtPhone.Text;
            string cccd = txtCCCD.Text;
            
            string roleID = ((Role)cmbRole.SelectedItem).RoleID;
            if (UserService.Instance.AddUser(username, password, fullName, phone, cccd, roleID))
            {
                MessageBox.Show("Thêm người dùng thành công");
                List<User> userList = UserService.Instance.GetAllUsers();
                BindGridUser(userList);
                ResetControlU();
            }
            else
            {
                MessageBox.Show("Thêm người dùng thất bại");
            }
        }

        private void btnUpdateU_Click(object sender, EventArgs e)
        {
            UserService.Instance.UpdateUser(new User
            {
                UserName = txtUserName.Text,
                Userpassword = txtPassword.Text,
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                IdentityCard = txtCCCD.Text,
                RoleID = txtRoleID.Text
            });

            BindGridUser(UserService.Instance.GetAllUsers());
            ResetControlU();
        }

        private void btnDeleteU_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtUserName.Text;
                if (UserService.Instance.DeleteUser(username))
                {
                    MessageBox.Show("Xóa người dùng thành công");
                    List<User> userList = UserService.Instance.GetAllUsers();
                    BindGridUser(userList);
                    ResetControlU();
                }
                else
                {
                    MessageBox.Show("Xóa người dùng thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillCmbRole(List<Role> listRole)
        {
            cmbRole.DataSource = listRole;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
        }

        private void txtSearchU_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchU.Text.Trim().ToLower();
            List<User> user = UserService.Instance.SearchUser(search);
            BindGridUser(user);
        }






        //Area
        private void BindGridArea(List<Area> listArea)
        {
            dgvArea.Rows.Clear();
            foreach (var item in listArea)
            {
                int index = dgvArea.Rows.Add();
                dgvArea.Rows[index].Cells[0].Value = item.AreaID;
                dgvArea.Rows[index].Cells[1].Value = item.AreaName;
            }
        }
        private void ResetControlA()
        {
            txtAreaID.Clear();
            txtAreaName.Clear();
        }
        private void btnInsertA_Click(object sender, EventArgs e)
        {
            string areaID = txtAreaID.Text;
            string areaName = txtAreaName.Text;
            if (AreaService.Instance.AddArea(areaID, areaName))
            {
                MessageBox.Show("Thêm khu vực thành công");
                List<Area> areaList = AreaService.Instance.GetAllAreas();
                BindGridArea(areaList);
                ResetControlA();
            }
            else
            {
                MessageBox.Show("Thêm khu vực thất bại");
            }
        }

        private void btnUpdateA_Click(object sender, EventArgs e)
        {
            AreaService.Instance.UpdateArea(new Area
            {
                AreaID = txtAreaID.Text,
                AreaName = txtAreaName.Text
            });

            BindGridArea(AreaService.Instance.GetAllAreas());
            ResetControlA();
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            try
            {
                var areaID = txtAreaID.Text;
                if (AreaService.Instance.DeleteArea(areaID))
                {
                    MessageBox.Show("Xóa khu vực thành công");
                    List<Area> areaList = AreaService.Instance.GetAllAreas();
                    BindGridArea(areaList);
                    ResetControlA();
                }
                else
                {
                    MessageBox.Show("Xóa khu vực thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchA_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchA.Text.Trim().ToLower();
            List<Area> area = AreaService.Instance.SearchArea(search);
            BindGridArea(area);
        }

        private void dgvArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvArea.Rows[e.RowIndex];
                txtAreaID.Text = selectedRow.Cells[0].Value?.ToString();
                txtAreaName.Text = selectedRow.Cells[1].Value?.ToString();
            }
        }

        //Table
        private void BindGridTable(List<CF_Table> listTable)
        {
            dgvTable.Rows.Clear();
            foreach (var item in listTable)
            {
                int index = dgvTable.Rows.Add();
                dgvTable.Rows[index].Cells[0].Value = item.TableID;
                dgvTable.Rows[index].Cells[1].Value = item.TableName;
                dgvTable.Rows[index].Cells[2].Value = item.AreaID;
            }
        }
        private void ResetControlT()
        {
            txtTableID.Clear();
            txtTableName.Clear();
            txtAreaID.Clear();
        }
        private void FillCmbArea(List<Area> listArea)
        {
            cmbArea.DataSource = listArea;
            cmbArea.DisplayMember = "AreaName";
            cmbArea.ValueMember = "AreaID";
        }

        private void btnInsertT_Click(object sender, EventArgs e)
        {
            string tableID = txtTableID.Text;
            string tableName = txtTableName.Text;
            string areaID = ((Area)cmbArea.SelectedItem).AreaID;
            if (TableService.Instance.AddTable(tableID, tableName, areaID))
            {
                MessageBox.Show("Thêm bàn thành công");
                List<CF_Table> tableList = TableService.Instance.GetAllTables();
                BindGridTable(tableList);
                ResetControlT();
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại");
            }
        }

        private void btnUpdateT_Click(object sender, EventArgs e)
        {
            TableService.Instance.UpdateTable(new CF_Table
            {
                TableID = txtTableID.Text,
                TableName = txtTableName.Text,
                AreaID = ((Area)cmbArea.SelectedItem).AreaID
            });

            BindGridTable(TableService.Instance.GetAllTables());
            ResetControlT();
        }

        private void btnDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                var tableID = txtTableID.Text;
                if (TableService.Instance.DeleteTable(tableID))
                {
                    MessageBox.Show("Xóa bàn thành công");
                    List<CF_Table> tableList = TableService.Instance.GetAllTables();
                    BindGridTable(tableList);
                    ResetControlT();
                }
                else
                {
                    MessageBox.Show("Xóa bàn thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchT_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchT.Text.Trim().ToLower();
            List<CF_Table> table = TableService.Instance.SearchTable(search);
            BindGridTable(table);
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvTable.Rows[e.RowIndex];
                txtTableID.Text = selectedRow.Cells[0].Value?.ToString();
                txtTableName.Text = selectedRow.Cells[1].Value?.ToString();
                cmbArea.SelectedItem = selectedRow.Cells[2].Value;
            }
        }
    }
}
