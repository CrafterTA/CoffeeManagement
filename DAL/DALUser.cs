
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUser
    {
        private static DALUser _instance;
      

        public static DALUser Instance
        {
            get
            {
                if (_instance == null) _instance = new DALUser();
                return _instance;

            }
            set => _instance = value;
        }
        public List<User> GetAllUsers()
        {
            return CafeEntities.Instance.Users.ToList();
        }
        
        
    }
    
}
