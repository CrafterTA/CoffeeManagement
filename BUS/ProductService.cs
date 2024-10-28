using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductService
    {
        private static ProductService _instance;
        public static ProductService Instance
        {
            get
            {
                if (_instance == null) _instance = new ProductService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Product> GetAllProducts()
        {
            return DALProduct.Instance.GetAllProducts();
        }
        public Product GetProductByID(string productID)
        {
            return DALProduct.Instance.GetProductByID(productID);
        }
        public bool AddProduct(string productID, string productName, string categoryID, decimal price, string description, string image)
        {
            return DALProduct.Instance.AddProduct(productID, productName, categoryID,price, description, image);
        }
        public bool UpdateProduct(Product product)
        {
            return DALProduct.Instance.UpdateProduct(product);
        }
        public bool DeleteProduct(string productID)
        {
            return DALProduct.Instance.DeleteProduct(productID);
        }
    }
}
