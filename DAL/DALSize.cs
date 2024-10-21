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
        
    }
}
