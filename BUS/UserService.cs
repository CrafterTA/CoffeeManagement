using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserService
    {
        private readonly DALUser _context;
        public UserService()
        {
            _context = new DALUser();
        }
        public List<User> GetAllUsers()
        {
            return _context.GetAllUsers();
        }
        
    }    
}
