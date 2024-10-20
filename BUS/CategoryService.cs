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
    }
}
