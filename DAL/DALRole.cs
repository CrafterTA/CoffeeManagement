using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALRole
    {
        private static DALRole _instance;
        public static DALRole Instance
        {
            get
            {
                if (_instance == null) _instance = new DALRole();
                return _instance;
            }
            set => _instance = value;
        }

        public List<Role> GetAllRoles()
        {
            return CafeEntities.Instance.Roles.ToList();
        }
        public Role GetRoleByID(string roleID)
        {
            return CafeEntities.Instance.Roles.Find(roleID);
        }
        public bool AddRole(string roleID, string roleName)
        {
            try
            {
                var obj = new Role();
                obj.RoleID = roleID;
                obj.RoleName = roleName;
                CafeEntities.Instance.Roles.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateRole(Role roles)
        {
            try
            {
                var obj = GetRoleByID(roles.RoleID);
                if (obj != null)
                {
                    obj.RoleName = roles.RoleName;
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
        public bool DeleteRole(string ID)
        {
            try
            {
                var obj = GetRoleByID(ID);
                if (obj != null)
                {
                    CafeEntities.Instance.Roles.Remove(obj);
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
        public List<Role> SearchRole(string keyword)
        {
            keyword = keyword.ToLower().Trim();
            return CafeEntities.Instance.Roles
                .Where(c => c.RoleID.ToLower().Contains(keyword)
                         || c.RoleName.ToLower().Contains(keyword))
                .ToList();
        }
            
    }
}
