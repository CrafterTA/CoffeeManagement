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
        public Size GetSizeByName(string sizeName)
        {
            return DALSize.Instance.GetSizeByID(sizeName);
        }
        public bool AddSize(string sizeName, decimal sizePrice)
        {
            return DALSize.Instance.AddSize( sizeName, sizePrice);
        }
        public bool UpdateSize(Size sizes)
        {
            return DALSize.Instance.UpdateSize(sizes);
        }
        public bool DeleteSize(string sizeID)
        {
            return DALSize.Instance.DeleteSize(sizeID);
        }
        public List<Size> SearchSize(string search)
        {
            return DALSize.Instance.SearchSize(search);
        }
        
    }
}
