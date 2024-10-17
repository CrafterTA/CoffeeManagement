using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public int BillID { get; set; }
        public int OrderDetailID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
