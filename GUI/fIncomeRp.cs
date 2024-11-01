using BUS;
using DAL;
using DevExpress.XtraCharts;
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
    public partial class fIncomeRp : Form
    {
        public fIncomeRp()
        {
            InitializeComponent();
        }
        

        
        

        public void UpdateChart()
        {
            int year = DateTime.Now.Year;
            var sales = BillService.Instance.GetIncomeByYear(year);
            DisplaySales(sales, "Doanh so theo nam");
        }

        /*private void DisplaySales(List<Bill> income)
        {
            chartIncome.Series.Clear();
            Series series = new Series("Doanh số", ViewType.Bar);

            decimal totalAmount = 0;
            foreach (var inCome in income)
            {
                var orderDetail = inCome.OrderDetail;
                var productSize = orderDetail.ProductSize;
                var product = productSize.Product;
                var size = productSize.Size;

                decimal? itemTotal = orderDetail.Quantity * (product.Price + size.SizePrice);
                series.Points.Add(new SeriesPoint(inCome.PaymentDate, itemTotal));
                totalAmount += itemTotal ?? 0;
            }

            chartIncome.Series.Add(series);
            lblIncome.Text = $"Tổng doanh số: {totalAmount} VND";
        } */
        private void DisplaySales(List<Bill> income, string seriesName)
        {
            Series series = new Series(seriesName, ViewType.Bar);

            decimal totalAmount = 0;
            foreach (var inCome in income)
            {
                decimal itemTotal = BillService.Instance.Total(inCome);
                series.Points.Add(new SeriesPoint(inCome.PaymentDate, itemTotal));
                totalAmount += itemTotal;
            }

            chartIncome.Series.Add(series);
            lblIncome.Text = $"Tổng doanh số: {totalAmount} VND";
        }


        private void btnIncomeDay_Click(object sender, EventArgs e)
        {
            DateTime date = dtpIncome.Value.Date;
            var sales = BillService.Instance.GetIncomeByDate(date);
            DisplaySales(sales, "Doanh so theo ngay");
        }

        private void btnIncomeMonth_Click(object sender, EventArgs e)
        {
            int month = dtpIncome.Value.Month;
            int year = dtpIncome.Value.Year;
            var sales = BillService.Instance.GetIncomeByMonth(month, year);
            DisplaySales(sales, "Doanh so theo thang");
        }

        private void btnIncomeYear_Click(object sender, EventArgs e)
        {
            int year = dtpIncome.Value.Year;
            var sales = BillService.Instance.GetIncomeByYear(year);
            DisplaySales(sales, "Doanh so theo nam");
        }

        private void fIncomeRp_Load(object sender, EventArgs e)
        {
            DisplayTotalIncome();
        }
        private void DisplayTotalIncome()
        {
            DateTime today = DateTime.Now.Date;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            var dailyIncome = BillService.Instance.GetIncomeByDate(today).Sum(b => BillService.Instance.Total(b));
            var monthlyIncome = BillService.Instance.GetIncomeByMonth(month, year).Sum(b => BillService.Instance.Total(b));
            var yearlyIncome = BillService.Instance.GetIncomeByYear(year).Sum(b => BillService.Instance.Total(b));

            lblDay.Text = $"Tổng doanh thu hôm nay: {dailyIncome} VND";
            lblMonth.Text = $"Doanh thu tháng này: {monthlyIncome} VND";
            lblYear.Text = $"Doanh thu năm nay: {yearlyIncome} VND";
        }

    }
}
