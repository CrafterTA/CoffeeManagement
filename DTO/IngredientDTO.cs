using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IngredientDTO
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Stock { get; set; }
    }
}
