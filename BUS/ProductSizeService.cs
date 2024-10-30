using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductSizeService
    {
        private static ProductSizeService _instance;
        public static ProductSizeService Instance
        {
            get
            {
                if (_instance == null) _instance = new ProductSizeService();
                return _instance;
            }
            set => _instance = value;
        }
        public ProductSize GetProductSizeByID(string productSizeID)
        {
            return DALProductSize.Instance.GetProductSizeByID(productSizeID);
        }
        public List<ProductSize> Information()
        {
            return DALProductSize.Instance.Information();
        }
        public ProductSize CreateProductSize(string productID, string sizeName)
        {
            return DALProductSize.Instance.CreateProductSize(productID, sizeName);
        }
        public bool UpdateProductSize(int productSizeID, string productId, string sizeName)
        {
            return DALProductSize.Instance.UpdateProductSize(productSizeID, productId, sizeName);
        }
        public bool DeleteProductSize(int productSizeID)
        {
            return DALProductSize.Instance.DeleteProductSize(productSizeID);
        }


    }
}
