using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProvideDetailDTO
    {
        public int ProvideDetailID { get; set; }
        public int ProviderID { get; set; }
        public int IngredientID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}