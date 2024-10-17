using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrdersDTO
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
