using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DALBill
    {
        private static DALBill _instance;
        public static DALBill Instance
        {
            get
            {
                if (_instance == null) _instance = new DALBill();
                return _instance;

            }
            set => _instance = value;
        }
        public List<Bill> GetAllBills()
        {
            return CafeEntities.Instance.Bills.ToList();
        }
        public Bill GetBillByID(string billID)
        {
            return CafeEntities.Instance.Bills.Find(billID);
        }
        public void CreateBill(int orderDetailID, DateTime paymentDate, string paymentStatus)
        {
            var orderDetail = CafeEntities.Instance.OrderDetails.Find(orderDetailID);
            if (orderDetail == null)
            {
                throw new Exception($"OrderDetailID {orderDetailID} không tồn tại trong bảng OrderDetail.");
            }

            decimal totalMoney = (decimal)(orderDetail.Quantity * (orderDetail.ProductSize.Product.Price + orderDetail.ProductSize.Size.SizePrice));
            var bill = new Bill()
            {
                OrderDetailID = orderDetailID,
                PaymentDate = paymentDate,
                PaymentStatus = paymentStatus,
                Total = totalMoney
            };
            CafeEntities.Instance.Bills.Add(bill);
            CafeEntities.Instance.SaveChanges();
        }

        public List<Bill> GetIncomeByDate(DateTime date)
        {
            date = DateTime.Now.Date;
            var bills = CafeEntities.Instance.Bills
                .Where(b => b.PaymentDate.HasValue &&
                            b.PaymentDate.Value.Year == date.Year &&
                            b.PaymentDate.Value.Month == date.Month &&
                            b.PaymentDate.Value.Day == date.Day &&
                            b.PaymentStatus == "Đã thanh toán")
                .ToList();
            return bills;
        }
        public decimal TotalIncomeToday()
        {
            var today = DateTime.Now.Date;
            var bills = GetIncomeByDate(today);
            return bills.Sum(b => b.Total);
        }
        
        public decimal TotalIncomeThisMonth()
        {
            var today = DateTime.Now;
            var totalIncome = CafeEntities.Instance.Bills
                .Where(b => b.PaymentDate.HasValue &&
                            b.PaymentDate.Value.Year == today.Year &&
                            b.PaymentDate.Value.Month == today.Month &&
                            b.PaymentStatus == "Đã thanh toán")
                .Sum(b => b.Total);
            return totalIncome;
        }



    }
}
