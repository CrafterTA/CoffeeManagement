﻿using DAL;
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
        public bool AddProduct(string productID, string productName, string categoryID, decimal price, string description, byte[] image)
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
        public List<Product> SearchProduct(string search)
        {
            return DALProduct.Instance.SearchProduct(search);
        }
        public List<Product> GetProductByCategory(string categoryID)
        {
            return DALProduct.Instance.GetProductByCategory(categoryID);
        }
        public void CreateProductSize(string productID, string sizeName)
        {
            DALProductSize.Instance.CreateProductSize(productID, sizeName);
        }
        public void CreateOrderDetail(int productSizeID, int orderID, int quantity)
        {
            DALOrderDetail.Instance.CreateOrderDetail(productSizeID, orderID, quantity);
        }
        public void CreateBill(int orderDetailID, DateTime paymentDate, string paymentStatus)
        {
            DALBill.Instance.CreateBill(orderDetailID, paymentDate,paymentStatus);
        }
        public List<Size> GetAllSizes()
        {
            return DALSize.Instance.GetAllSizes();
        }

       /* public List<ProductSize> GetProductById(int productSizeID)
        {
            return DALProductSize.Instance.GetProductById(productSizeID);
        }*/
    }
}
