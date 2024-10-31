using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALOrder
    {
        private static DALOrder instance;
        public static DALOrder Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALOrder();
                return instance;
            }
            private set => instance = value;
        }
        public List<Order> GetAllOrders()
        {
            return CafeEntities.Instance.Orders.ToList();
        }
        public Order GetOrderByID(int orderID)
        {
            return CafeEntities.Instance.Orders.Find(orderID);
        }
        public Order CreateOrder(string tableId)
        {
            var order = new Order
            {
                DateCheckIn = DateTime.Now,
                Status = "Đang xử lý",
                TableID = tableId
            };
            CafeEntities.Instance.Orders.Add(order);
            CafeEntities.Instance.SaveChanges();
            return order;
        }
    }
}
