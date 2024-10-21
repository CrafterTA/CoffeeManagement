using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SizeService
    {
        private static SizeService instance;
        public static SizeService Instance
        {
            get
            {
                if (instance == null)
                    instance = new SizeService();
                return instance;
            }
            private set => instance = value;
        }
        public List<Size> GetAllSizes()
        {
            return DALSize.Instance.GetAllSizes();
        }
        public Size GetSizeByID(string sizeID)
        {
            return DALSize.Instance.GetSizeByID(sizeID);
        }
        public bool AddSize(string sizeID, string sizeName, decimal additionalPrice)
        {
            return DALSize.Instance.AddSize(sizeID, sizeName, additionalPrice);
        }
        public bool UpdateSize(Size sizes)
        {
            return DALSize.Instance.UpdateSize(sizes);
        }
        public bool DeleteSize(string sizeID)
        {
            return DALSize.Instance.DeleteSize(sizeID);
        }
    }
}
