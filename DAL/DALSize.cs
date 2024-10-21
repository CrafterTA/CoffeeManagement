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
        public Size GetSizeByID(string sizeID)
        {
            return CafeEntities.Instance.Sizes.Find(sizeID);
        }
        public bool AddSize(string sizeID, string sizeName, decimal additionalPrice)
        {
            try
            {
                var obj = new Size();
                obj.SizeID = sizeID;
                obj.SizeName = sizeName;
                obj.AdditionalPrice = additionalPrice;
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
                var obj = GetSizeByID(sizes.SizeID);
                if (obj != null)
                {
                    obj.SizeName = sizes.SizeName;
                    obj.AdditionalPrice = sizes.AdditionalPrice;
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
        public bool DeleteSize(string sizeID)
        {
            try
            {
                var obj = GetSizeByID(sizeID);
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

    }
}
