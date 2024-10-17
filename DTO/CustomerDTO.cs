using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int PromotionID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
