using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProviderOrderDTO
    {
        public int ProviderOrderID { get; set; }
        public int ProviderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
