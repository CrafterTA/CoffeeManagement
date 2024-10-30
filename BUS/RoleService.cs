using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class RoleService
    {
        private static RoleService _instance;
        public static RoleService Instance
        {
            get
            {
                if (_instance == null) _instance = new RoleService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Role> GetAllRoles()
        {
            return DALRole.Instance.GetAllRoles();
        }
        public Role GetRoleByID(string roleID)
        {
            return DALRole.Instance.GetRoleByID(roleID);
        }
        public bool AddRole(string roleID, string roleName)
        {
            return DALRole.Instance.AddRole(roleID, roleName);
        }
        public bool UpdateRole(Role roles)
        {
            return DALRole.Instance.UpdateRole(roles);
        }
        public bool DeleteRole(string ID)
        {
            return DALRole.Instance.DeleteRole(ID);
        }
        public List<Role> SearchRole(string keyword)
        {
            return DALRole.Instance.SearchRole(keyword);
        }
    }
}
