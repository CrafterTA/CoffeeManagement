using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProviderOrderDetailDTO
    {
        public int ProviderOrderDetailID { get; set; }
        public int ProviderOrderID { get; set; }
        public int IngredientID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
