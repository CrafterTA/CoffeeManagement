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
        public void GetBillByTableName(string tableName)
        {

        }
    }
}
