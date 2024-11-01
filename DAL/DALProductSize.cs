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
        public List<ProductSize> GetProductSizeByID(int productSizeID)
        {
            return CafeEntities.Instance.ProductSizes.Where(p => p.ProductSizeID == productSizeID).ToList();
        }
        public ProductSize CreateProductSize(string productID, string sizeName)
        {
            
            var size = CafeEntities.Instance.Sizes.FirstOrDefault(s => s.SizeName == sizeName);
            if (size == null)
            {
                
                size = new Size { SizeName = sizeName };
                CafeEntities.Instance.Sizes.Add(size);
                CafeEntities.Instance.SaveChanges();
            }

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
