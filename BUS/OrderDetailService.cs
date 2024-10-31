using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderDetailService
    {
        private static OrderDetailService _instance;
        public static OrderDetailService Instance
        {
            get
            {
                if (_instance == null) _instance = new OrderDetailService();
                return _instance;
            }
            set => _instance = value;
        }
        public void CreateOrderDetail(int productSizeID, int orderID, int quantity)
        {
            DALOrderDetail.Instance.CreateOrderDetail(productSizeID, orderID, quantity);
        }
        public decimal GetTotalPrice(int orderID)
        {
            return DALOrderDetail.Instance.GetTotalPrice(orderID);
        }
        public List<OrderDetail> GetCartByOrderID(int orderID)
        {
            return DALOrderDetail.Instance.GetOrderDetailsByOrderID(orderID);
        }
        public List<OrderDetail> GetAllOrderDetails()
        {
            return DALOrderDetail.Instance.GetAllOrderDetails();
        }

    }
}
