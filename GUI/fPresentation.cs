using BUS;
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
    public partial class fPresentation : Form
    {
        
        public fPresentation()
        {
            InitializeComponent();
        }
        
        private void fPresentation_Load(object sender, EventArgs e)
        {
            siticoneShadowForm1.SetShadowForm(this);

            Authorize();
        }

        private void Authorize()
        {
            
        }
        private void btnHome_CheckedChanged(object sender, EventArgs e)
        {
            if (btnHome.Checked) ucHomepage1.BringToFront();

        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {
            fLogin loginForm = new fLogin();
            loginForm.Show();
            this.Close();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDisplayTable fDisplayTable = new fDisplayTable();
            fDisplayTable.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            fCRUD fCRUD = new fCRUD();
            fCRUD.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            fIncomeRp fIncomeRp = new fIncomeRp();
            fIncomeRp.ShowDialog();
        }
    }
}
