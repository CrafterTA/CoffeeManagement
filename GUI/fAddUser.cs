using BUS;
using DAL;
using DevExpress.Utils.DirectXPaint;
using DTO;
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
        private readonly UserService _context = new UserService();
        public fAddUser()
        {
            InitializeComponent();
            
        }
        private void fAddUser_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            var users = _context.GetAllUsers();
            dgvCRUD.DataSource = users;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            string fullName = txtFullname.Text;
            string phone = txtPhone.Text;
            string identitycard = txtIC.Text;
            string rolename = txtRole.Text;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           

        }

        private void dgvCRUD_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCRUD.SelectedRows.Count > 0)
            {
                txtUsername.Text = dgvCRUD.SelectedRows[0].Cells["Tên người dùng"].Value.ToString();
                txtPassword.Text = dgvCRUD.SelectedRows[0].Cells["Mật khẩu"].Value.ToString();
                txtFullname.Text = dgvCRUD.SelectedRows[0].Cells["Họ tên"].Value.ToString();
                txtPhone.Text = dgvCRUD.SelectedRows[0].Cells["Số điện thoại"].Value.ToString();
                txtIC.Text = dgvCRUD.SelectedRows[0].Cells["CCCD"].Value.ToString();
                txtRole.Text = dgvCRUD.SelectedRows[0].Cells["Vai trò"].Value.ToString();
            }
        }
    }

    
}
