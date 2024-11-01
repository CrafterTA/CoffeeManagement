using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderService
    {
        private static OrderService _instance;
        public static OrderService Instance
        {
            get
            {
                if (_instance == null) _instance = new OrderService();
                return _instance;
            }
            private set => _instance = value;
        }
        public List<Order> GetAllOrders()
        {
            return DAL.DALOrder.Instance.GetAllOrders();
        }
        public Order GetOrderByID(int orderID)
        {
            return DAL.DALOrder.Instance.GetOrderByID(orderID);
        }
        public Order CreateOrder(string tableId)
        {
            return DAL.DALOrder.Instance.CreateOrder(tableId);
        }
    }
}
