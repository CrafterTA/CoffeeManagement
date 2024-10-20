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
    public partial class fAddRole : Form
    {

        public fAddRole()
        {
            InitializeComponent();
        }
        private void fAddRole_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvCRUD);
                var listRole = RoleService.Instance.GetAllRoles();
                BindGrid(listRole);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            fAddUser fAddUser = new fAddUser();
            fAddUser.ShowDialog();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string roleID = txtRoleID.Text;
            string roleName = txtRolename.Text;
            if (RoleService.Instance.AddRole(roleID, roleName))
            {
                MessageBox.Show("Thêm vai trò thành công");
                List<Role> roleList;
                roleList = RoleService.Instance.GetAllRoles();
                dgvCRUD.DataSource = roleList;
            }
            else
            {
                MessageBox.Show("Thêm vai trò thất bại");
            }

        }
        private void BindGrid(List<Role> listRole)
        {
            dgvCRUD.Rows.Clear();
            foreach (var roles in listRole)
            {
                int index = dgvCRUD.Rows.Add();
                dgvCRUD.Rows[index].Cells[0].Value = roles.RoleID;
                dgvCRUD.Rows[index].Cells[1].Value = roles.RoleName;
            }
        }
        private void dgvCRUD_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RoleService.Instance.UpdateRole(new Role
            {
                RoleID = txtRoleID.Text,
                RoleName = txtRolename.Text

            });
            BindGrid(RoleService.Instance.GetAllRoles());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var RoleID = txtRoleID.Text;
            if (RoleService.Instance.DeleteRole(RoleID))
            {
                MessageBox.Show("Xóa vai trò thành công");
                List<Role> roleList;
                roleList = RoleService.Instance.GetAllRoles();
                dgvCRUD.DataSource = roleList;
            }
            else
            {
                MessageBox.Show("Xóa vai trò thất bại");
            }

        }
    }
}
