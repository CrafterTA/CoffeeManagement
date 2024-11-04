using BUS;
using DevExpress.XtraCharts;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class fIncomeRp : Form
    {
        public fIncomeRp()
        {
            InitializeComponent();
        }

        private void fIncomeRp_Load(object sender, EventArgs e)
        {
            DisplayTotalIncome();
            DisplayIncome();
        }

        private void dtpIncome_ValueChanged(object sender, EventArgs e)
        {
            DisplayIncome();
        }

        private void DisplayTotalIncome()
        {
            var dayIncome = BillService.Instance.TotalIncomeToday();
            lblDay.Text = $"Tổng doanh thu hôm nay: {dayIncome} VND";
        }

        private void DisplayIncome()
        {
            try
            {
                var totalIncomeToday = BillService.Instance.TotalIncomeToday();
                var totalIncomeThisMonth = BillService.Instance.TotalIncomeThisMonth();

                lblDay.Text = $"Tổng doanh thu hôm nay: {totalIncomeToday} VND";
                lblMonth.Text = $"Tổng doanh thu tháng này: {totalIncomeThisMonth} VND";

                Series seriesToday = new Series("Doanh số hôm nay", ViewType.Bar);
                seriesToday.Points.Add(new SeriesPoint(DateTime.Now.Date, totalIncomeToday));

                Series seriesThisMonth = new Series("Doanh số tháng này", ViewType.Bar);
                seriesThisMonth.Points.Add(new SeriesPoint(DateTime.Now.Date, totalIncomeThisMonth));

                chartIncome.Series.Clear();
                chartIncome.Series.Add(seriesToday);
                chartIncome.Series.Add(seriesThisMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fPresentation fPresentation = new fPresentation();
            fPresentation.ShowDialog();
        }
    }
}