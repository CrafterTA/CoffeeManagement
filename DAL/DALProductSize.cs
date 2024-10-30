using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProductSize
    {
        private static DALProductSize instance;
        public static DALProductSize Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALProductSize();
                return instance;
            }
            private set => instance = value;
        }
        public List<ProductSize> Information()
        {
            return CafeEntities.Instance.ProductSizes.ToList();
        }
        public ProductSize GetProductSizeByID(string productSizeID)
        {
            return CafeEntities.Instance.ProductSizes.Find(productSizeID);
        }
        public ProductSize CreateProductSize(string productID, string sizeName)
        {
            var productSize = new ProductSize()
            {
                ProductID = productID,
                SizeName = sizeName
            };
            CafeEntities.Instance.ProductSizes.Add(productSize);
            CafeEntities.Instance.SaveChanges();
            return productSize;
        }
        public bool UpdateProductSize(int productSizeID, string productId, string sizeName)
        {
            var productSize = CafeEntities.Instance.ProductSizes.Find(productSizeID);
            if (productSize == null)
                return false;

            productSize.ProductID = productId;
            productSize.SizeName = sizeName;

            CafeEntities.Instance.SaveChanges();
            return true;
        }

        public bool DeleteProductSize(int productSizeID)
        {
            var productSize = CafeEntities.Instance.ProductSizes.Find(productSizeID);
            if (productSize == null)
                return false;

            CafeEntities.Instance.ProductSizes.Remove(productSize);
            CafeEntities.Instance.SaveChanges();
            return true;
        }
    }
}
