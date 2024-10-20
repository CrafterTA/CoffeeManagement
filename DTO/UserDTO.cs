using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        [DisplayName("Tên tài khoản")]
        public string UserName { get; set; }
        [DisplayName("Mật khẩu")]
        public string Userpassword { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
