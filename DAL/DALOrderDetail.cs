using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALOrderDetail
    {
        private static DALOrderDetail instance;
        public static DALOrderDetail Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALOrderDetail();
                return instance;
            }
            private set => instance = value;
        }
        public List<OrderDetail> GetAllOrderDetails()
        {
            return CafeEntities.Instance.OrderDetails.ToList();
        }
        public OrderDetail GetOrderDetailByID(int orderDetailID)
        {
            return CafeEntities.Instance.OrderDetails.Find(orderDetailID);
        }
        public void CreateOrderDetail(int productSizeID, int orderID, int quantity)
        {
            var orderDetail = new OrderDetail
            {
                ProductSizeID = productSizeID,
                OrderID = orderID,
                Quantity = quantity
            };

            CafeEntities.Instance.OrderDetails.Add(orderDetail);
            CafeEntities.Instance.SaveChanges();
        }
        public decimal GetTotalPrice(int orderID)
        {
            return (decimal)CafeEntities.Instance.OrderDetails
                .Where(od => od.OrderID == orderID)
                .Sum(od => od.Quantity * (od.ProductSize.Product.Price + od.ProductSize.Size.SizePrice));
        }
        public List<OrderDetail> GetOrderDetailsByOrderID(int orderID)
        {
            return CafeEntities.Instance.OrderDetails.Where(od => od.OrderID == orderID).ToList();
        }
    }
}
