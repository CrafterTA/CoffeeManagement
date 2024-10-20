using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoleDTO
    {
        public RoleDTO(string id, string name)
        {
            RoleID = id;
            RoleName = name;
        }
        private string RoleID;
        private string RoleName;
        public string roleID
        {
            get => RoleID;
            set => RoleID = value;
        }
        public string roleName
        {
            get => RoleName;
            set => RoleName = value;
        }
    }
}
