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
    public partial class fAddSize : Form
    {
        public fAddSize()
        {
            InitializeComponent();
        }

        private void fAddSize_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvCRUD);
                var listSize = SizeService.Instance.GetAllSizes();
                BindGrid(listSize);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<DAL.Size> listSize)
        {
            dgvCRUD.Rows.Clear();
            foreach (var item in listSize)
            {
                int index = dgvCRUD.Rows.Add();
                
                dgvCRUD.Rows[index].Cells[1].Value = item.SizeName;
                dgvCRUD.Rows[index].Cells[2].Value = item.SizePrice;
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

        /*private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string sizeName = txtSizeName.Text;
            //decimal sizePrice = Convert.ToDecimal(txtSizePrice.Text);
            decimal additionalprice = Convert.ToDecimal(txtAdditionalPrice.Text);
            try
            {
                if (SizeService.Instance.AddSize( sizeName, sizePrice))
                {
                    MessageBox.Show("Thêm dữ liệu thành công");
                    BindGrid(SizeService.Instance.GetAllSizes());
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SizeService.Instance.UpdateSize(new DAL.Size
            {
                SizeID = txtSizeID.Text,
                SizeName = txtSizeName.Text,
                AdditionalPrice = Convert.ToDecimal(txtAdditionalPrice.Text)
            });
            BindGrid(SizeService.Instance.GetAllSizes());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sizeID = txtSizeID.Text;
            if (SizeService.Instance.DeleteSize(sizeID))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                BindGrid(SizeService.Instance.GetAllSizes());
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại");
            }
        }*/
    }
}
