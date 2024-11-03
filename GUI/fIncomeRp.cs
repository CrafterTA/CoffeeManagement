using BUS;
using DAL;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTime today = DateTime.Now.Date;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            var dailyIncome = BillService.Instance.GetIncomeByDate(today).Sum(b => b.Total);
            var monthlyIncome = BillService.Instance.GetIncomeByMonth(month, year).Sum(b => b.Total);
            var yearlyIncome = BillService.Instance.GetIncomeByYear(year).Sum(b => b.Total);

            lblDay.Text = $"Tổng doanh thu hôm nay: {dailyIncome} VND";
            lblMonth.Text = $"Doanh thu tháng này: {monthlyIncome} VND";
            lblYear.Text = $"Doanh thu năm nay: {yearlyIncome} VND";
        }

        private void DisplayIncome()
        {
            DateTime chooseday = dtpIncome.Value.Date;
            int month = chooseday.Month;
            int year = chooseday.Year;
            var incometoday = BillService.Instance.GetIncomeByDate(chooseday);
            var monthlyincome = BillService.Instance.GetIncomeByMonth(month, year);
            var yearlyincome = BillService.Instance.GetIncomeByYear(year);
            chartIncome.Series.Clear();
            DisplaySales(incometoday, "Doanh số hôm nay");
            DisplaySales(monthlyincome, "Doanh số tháng này");
            DisplaySales(yearlyincome, "Doanh số năm nay");
        }

        private void DisplaySales(List<Bill> income, string seriesName)
        {
            Series series = new Series(seriesName, ViewType.Bar);

            decimal totalAmount = 0;
            foreach (var inCome in income)
            {
                series.Points.Add(new SeriesPoint(inCome.PaymentDate, inCome.Total));
                totalAmount += inCome.Total;
            }

            chartIncome.Series.Add(series);
            lblIncome.Text = $"Tổng doanh số: {totalAmount} VND";
        } 
    }
}