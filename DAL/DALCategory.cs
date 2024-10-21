using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCategory
    {
        private static DALCategory _instance;
        public static DALCategory Instance
        {
            get
            {
                if (_instance == null) _instance = new DALCategory();
                return _instance;
            }
            set => _instance = value;
        }
        public List <Category> GetAllCategories()
        {
            return CafeEntities.Instance.Categories.ToList();
        }
        public Category GetCategoryByID(string categoryID)
        {
            return CafeEntities.Instance.Categories.Find(categoryID);
        }
        public bool AddCategory(string categoryID, string categoryName,string description)
        {
            try
            {
                var obj = new Category();
                obj.CategoryID = categoryID;
                obj.CategoryName = categoryName;
                obj.Description = description;
                CafeEntities.Instance.Categories.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateCategory(Category categories)
        {
            try
            {
                var obj = GetCategoryByID(categories.CategoryID);
                if (obj != null)
                {
                    obj.CategoryName = categories.CategoryName;
                    obj.Description = categories.Description;
                    CafeEntities.Instance.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool DeleteCategory(string categoryID)
        {
            try
            {
                var obj = GetCategoryByID(categoryID);
                if (obj != null)
                {
                    CafeEntities.Instance.Categories.Remove(obj);
                    CafeEntities.Instance.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }

    }

}
