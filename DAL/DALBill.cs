using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void CreateBill( int orderDetailID, DateTime paymentDate, string paymentStatus)
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
            var targetDate = date.Date;
            return CafeEntities.Instance.Bills
                .Where(b => b.PaymentDate.HasValue &&
                            b.PaymentDate.Value.Year == targetDate.Year &&
                            b.PaymentDate.Value.Month == targetDate.Month &&
                            b.PaymentDate.Value.Day == targetDate.Day &&
                            b.PaymentStatus == "Đã thanh toán")
                .ToList();
        }

        public List<Bill> GetIncomeByMonth(int month, int year)
        {
            return CafeEntities.Instance.Bills
                .Where(b => b.PaymentDate.HasValue &&
                            b.PaymentDate.Value.Month == month &&
                            b.PaymentDate.Value.Year == year &&
                            b.PaymentStatus == "Đã thanh toán")
                .ToList();
        }

        public List<Bill> GetIncomeByYear(int year)
        {
            return CafeEntities.Instance.Bills
                .Where(b => b.PaymentDate.HasValue &&
                            b.PaymentDate.Value.Year == year &&
                            b.PaymentStatus == "Đã thanh toán")
                .ToList();
        }
        

    }
}
