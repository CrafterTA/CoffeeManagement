using BUS;
using DAL;
using DevExpress.Utils.DirectXPaint;

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
    public partial class fAddUser : Form
    {
        
        public fAddUser()
        {
            InitializeComponent();
            
        }
        private void fAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvCRUD);
                var listRole = RoleService.Instance.GetAllRoles();
                var listUsers = UserService.Instance.GetAllUsers();
                FillRolesComboBox(listRole);
                BindGrid(listUsers);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<User> listUsers)
        {
            dgvCRUD.Rows.Clear();
            foreach (var users in listUsers)
            {
                int index = dgvCRUD.Rows.Add();
                dgvCRUD.Rows[index].Cells[0].Value = users.UserName;
                dgvCRUD.Rows[index].Cells[1].Value = users.Userpassword;
                dgvCRUD.Rows[index].Cells[2].Value = users.FullName;
                dgvCRUD.Rows[index].Cells[3].Value = users.Phone;
                dgvCRUD.Rows[index].Cells[4].Value = users.IdentityCard;
                dgvCRUD.Rows[index].Cells[5].Value = users.RoleID;

            }
        }

        private void FillRolesComboBox(List<Role> listRole)
        {
            cmbRole.DataSource = listRole;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
        }

        private void setGridViewStyle(DataGridView dgvCRUD)
        {
            dgvCRUD.BorderStyle = BorderStyle.None;
            dgvCRUD.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvCRUD.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCRUD.BackgroundColor = Color.White;
            dgvCRUD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadUser()
        {
            var users = UserService.Instance.GetAllUsers();
            dgvCRUD.DataSource = users;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullname = txtFullname.Text;
            string phone = txtPhone.Text;
            string cccd = txtIC.Text;
            string roleID = ((Role)cmbRole.SelectedItem).RoleID.ToString();
            if (UserService.Instance.AddUser(username, password, fullname, phone, cccd, roleID))
            {
                MessageBox.Show("Thêm người dùng thành công");
                BindGrid(UserService.Instance.GetAllUsers());
            }
            else
            {
                MessageBox.Show("Thêm người dùng thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserService.Instance.UpdateUser(new User
            {
                UserName = txtUsername.Text,
                Userpassword = txtPassword.Text,
                FullName = txtFullname.Text,
                Phone = txtPhone.Text,
                IdentityCard = txtIC.Text,
                RoleID = ((Role)cmbRole.SelectedItem).RoleID.ToString()
            });
            BindGrid(UserService.Instance.GetAllUsers());

        }

        private void dgvCRUD_SelectionChanged(object sender, EventArgs e)
        {
            /*if (dgvCRUD.SelectedRows.Count > 0)
            {
                txtUsername.Text = dgvCRUD.SelectedRows[0].Cells["Tên người dùng"].Value.ToString();
                txtPassword.Text = dgvCRUD.SelectedRows[0].Cells["Mật khẩu"].Value.ToString();
                txtFullname.Text = dgvCRUD.SelectedRows[0].Cells["Họ tên"].Value.ToString();
                txtPhone.Text = dgvCRUD.SelectedRows[0].Cells["Số điện thoại"].Value.ToString();
                txtIC.Text = dgvCRUD.SelectedRows[0].Cells["CCCD"].Value.ToString();
                cmbRole.Text = dgvCRUD.SelectedRows[0].Cells["Vai trò"].Value.ToString();
            } */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            if (UserService.Instance.DeleteUser(username))
            {
                MessageBox.Show("Xóa người dùng thành công");
                BindGrid(UserService.Instance.GetAllUsers());
            }
            else
            {
                MessageBox.Show("Xóa người dùng thất bại");
            }

        }
    }

    
}
