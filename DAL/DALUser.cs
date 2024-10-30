
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
        public User GetUserByUsername(string username)
        {
            return CafeEntities.Instance.Users.Find(username);
        }
        public bool AddUser(string username, string password, string fullName, string phone, string cccd, string roleID)
        {
            try
            {
                var obj = new User();
                obj.UserName = username;
                obj.Userpassword = password;
                obj.FullName = fullName;
                obj.Phone = phone;
                obj.IdentityCard = cccd;
                obj.RoleID = roleID;
                CafeEntities.Instance.Users.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                var obj = GetUserByUsername(user.UserName);
                if (obj != null)
                {
                    obj.Userpassword = user.Userpassword;
                    obj.FullName = user.FullName;
                    obj.Phone = user.Phone;
                    obj.IdentityCard = user.IdentityCard;
                    obj.RoleID = user.RoleID;
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
        public bool DeleteUser(string username)
        {
            try
            {
                var obj = GetUserByUsername(username);
                if (obj != null)
                {
                    CafeEntities.Instance.Users.Remove(obj);
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
        public List<User> SearchUser(string keyword)
        {
            keyword = keyword.ToLower().Trim();
            return CafeEntities.Instance.Users.Where(x => x.UserName.Contains(keyword) || x.FullName.Contains(keyword) || x.Phone.Contains(keyword) || x.IdentityCard.Contains(keyword)).ToList();
        }

    }
    
}
