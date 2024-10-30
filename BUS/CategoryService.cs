using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CategoryService
    {
        private static CategoryService _instance;
        public static CategoryService Instance
        {
            get
            {
                if (_instance == null) _instance = new CategoryService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Category> GetAllCategories()
        {
            return DALCategory.Instance.GetAllCategories();
        }
        public Category GetCategoryByID(string categoryID)
        {
            return DALCategory.Instance.GetCategoryByID(categoryID);
        }
        public bool AddCategory(string categoryID, string categoryName, string description)
        {
            return DALCategory.Instance.AddCategory(categoryID, categoryName, description);
        }
        public bool UpdateCategory(Category categories)
        {
            return DALCategory.Instance.UpdateCategory(categories);
        }
        public bool DeleteCategory(string categoryID) {
            return DALCategory.Instance.DeleteCategory(categoryID);
        }
        public List<Category> SearchCategory(string keyword)
        {
            return DALCategory.Instance.SearchCategory(keyword);
        }

    }
}
