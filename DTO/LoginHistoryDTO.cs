using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginHistoryDTO
    {
        public int LoginHistoryID { get; set; }
        public int UserID { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
}