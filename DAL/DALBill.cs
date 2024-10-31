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
        public Bill CreateBill( int orderDetailID, DateTime paymentDate, string paymentStatus)
        {
            var bill = new Bill()
            {
                
                OrderDetailID = orderDetailID,
                PaymentDate = paymentDate,
                PaymentStatus = paymentStatus
            };
            CafeEntities.Instance.Bills.Add(bill);
            CafeEntities.Instance.SaveChanges();
            return bill;
        }
        

    }
}
