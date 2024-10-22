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
        public bool AddProduct(string productID, string productName, string categoryID, string sizeID, string description, string image)
        {
            try
            {
                Product product = new Product()
                {
                    ProductID = productID,
                    ProductName = productName,
                    CategoryID = categoryID,
                    SizeID = sizeID,
                    Description = description,
                    Image = image
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
                itu.SizeID = product.SizeID;
                itu.Description = product.Description;
                itu.Image = product.Image;
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
    }
}
