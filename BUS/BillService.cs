using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillService
    {
        private static BillService _instance;
        public static BillService Instance
        {
            get
            {
                if (_instance == null) _instance = new BillService();
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
            DALBill.Instance.CreateBill(orderDetailID, paymentDate, paymentStatus);
        }

        public List<Bill> GetIncomeByDate(DateTime date)
        {
            return DALBill.Instance.GetIncomeByDate(date);
        }
        public decimal TotalIncomeToday()
        {
            return DALBill.Instance.TotalIncomeToday();
        }
        public decimal TotalIncomeThisMonth()
        {
            return DALBill.Instance.TotalIncomeThisMonth();
        }



    }
}
