using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALSize
    {
        private static DALSize instance;
        public static DALSize Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALSize();
                return instance;
            }
            private set => instance = value;
        }
        public List<Size> GetAllSizes()
        {
            return CafeEntities.Instance.Sizes.ToList();
        }
        public Size GetSizeByID(string sizeName)
        {
            return CafeEntities.Instance.Sizes.Find(sizeName);
        }
        public bool AddSize(string sizeName, decimal sizePrice)
        {
            try
            {
                var obj = new Size();
                obj.SizeName = sizeName;
                obj.SizePrice = sizePrice;
                CafeEntities.Instance.Sizes.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateSize(Size sizes)
        {
            try
            {
                var obj = GetSizeByID(sizes.SizeName);
                if (obj != null)
                {
                    obj.SizePrice = sizes.SizePrice;
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
        public bool DeleteSize(string sizeName)
        {
            try
            {
                var obj = GetSizeByID(sizeName);
                if (obj != null)
                {
                    CafeEntities.Instance.Sizes.Remove(obj);
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
        public List<Size> SearchSize(string sizeName)
        {
            return CafeEntities.Instance.Sizes.Where(x => x.SizeName.Contains(sizeName) || x.SizePrice.ToString().Contains(sizeName)).ToList();
        }

    }
}
