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
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null) _instance = new UserService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<User> GetAllUsers()
        {
            return DALUser.Instance.GetAllUsers();
        }
        public User GetUserByUsername(string username)
        {
            return DALUser.Instance.GetUserByUsername(username);
        }
        public bool AddUser(string username, string password, string fullName, string phone, string cccd, string roleID)
        {
            return DALUser.Instance.AddUser(username, password, fullName, phone, cccd, roleID);
        }
        public bool UpdateUser(User user)
        {
            return DALUser.Instance.UpdateUser(user);
        }
        public bool DeleteUser(string username)
        {
            return DALUser.Instance.DeleteUser(username);
        }



    }    
}
