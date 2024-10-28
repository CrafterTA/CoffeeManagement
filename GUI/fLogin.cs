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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
        private void Authorization(string username)
        {
            User user = UserService.Instance.GetUserByUsername(username);
            if (user != null)
            {
                string roleID = user.RoleID;
                switch (roleID)
                {
                    case "1":
                        fDashboard fAdmin = new fDashboard();
                        this.Hide();
                        fAdmin.ShowDialog();
                        this.Show();
                        break;
                    case "2":
                        fDashboard fStaff = new fDashboard();
                        this.Hide();
                        fStaff.ShowDialog();
                        this.Show();
                        break;
                    default:
                        MessageBox.Show("Không có quyền truy cập");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            User user = UserService.Instance.GetUserByUsername(username);
            if (user != null)
            {
                if (user.Userpassword == password)
                {
                    Authorization(username);
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }
    }
}
