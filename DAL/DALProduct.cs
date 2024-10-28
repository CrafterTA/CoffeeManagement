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
        public bool AddProduct(string productID, string productName, string categoryID, string sizeID,decimal price, string description, string image)
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

        public bool AddProduct(string productID, string productName, string categoryID, decimal price, string description, string image)
        {
            throw new NotImplementedException();
        }
    }
}
