using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProduct
    {
        private static DALProduct _instance;
        public static DALProduct Instance
        {
            get
            {
                if (_instance == null) _instance = new DALProduct();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Product> GetAllProducts()
        {
            return CafeEntities.Instance.Products.ToList();
        }
        public Product GetProductByID(string productID)
        {
            return CafeEntities.Instance.Products.Find(productID);
        }
        public bool AddProduct(string productID, string productName, string categoryID,decimal price, string description, byte[] image)
        {
            try
            {
                Product product = new Product()
                {
                    ProductID = productID,
                    ProductName = productName,
                    CategoryID = categoryID,
                    Price = price,
                    Description = description,
                    Images = image
                };
                CafeEntities.Instance.Products.Add(product);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        public bool UpdateProduct(Product product)
        {
            try
            {
                var itu = CafeEntities.Instance.Products.Find(product.ProductID);
                if (itu == null)
                {
                    
                    return false;
                }
                itu.ProductName = product.ProductName;
                itu.CategoryID = product.CategoryID;
                itu.Price = product.Price;
                itu.Description = product.Description;
                itu.Images = product.Images;
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(string productID)
        {
            try
            {
                var product = CafeEntities.Instance.Products.Find(productID);
                CafeEntities.Instance.Products.Remove(product);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Product> SearchProduct(string keyword)
        {
            keyword = keyword.ToLower().Trim();
            return CafeEntities.Instance.Products
                .Where(c => c.ProductID.ToLower().Contains(keyword)
                         || c.ProductName.ToLower().Contains(keyword)
                         || c.Price.ToString().Contains(keyword))
                .ToList();
        }
        public List<Product> GetProductByCategory(string categoryID)
        {
            return CafeEntities.Instance.Products
                .Where(c => c.CategoryID == categoryID)
                .ToList();
        }
        public void CreateProductSize(string productID, string sizeName)
        {
            DALProductSize.Instance.CreateProductSize(productID, sizeName);
        }
        public void CreateOrderDetail(int orderID, int productSizeID, int quantity)
        {
            DALOrderDetail.Instance.CreateOrderDetail(orderID, productSizeID, quantity);
        }
        public void CreateBill( int orderDetailID, DateTime paymentDate, string paymentStatus)
        {
            DALBill.Instance.CreateBill( orderDetailID, paymentDate, paymentStatus);
        }
        public List<Size> GetAllSizes()
        {
            return DALSize.Instance.GetAllSizes();
        }
    }
}
