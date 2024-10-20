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
    }
}
