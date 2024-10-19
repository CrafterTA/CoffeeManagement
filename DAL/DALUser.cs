using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUser
    {
        private static DALUser instance;
        public static DALUser Instance
        {
            get
            {
                if (instance == null) instance = new DALUser();
                return instance;
            }
            set => instance = value;
        }
        public bool AddUser(int userID, string userName, string password, string fullName, string role)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    User user = new User()
                    {
                        UserID = userID,
                        UserName = userName,
                        Userpassword = password,
                        FullName = fullName,
                        Role = role
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.ToString());
                    return false;
                }
            }
        }

    }
    public User GetUserByID(int userID)
    {
        using (var db = new AppDbContext())
        {
            return db.Users.Find(userID);
        }
    }
}
