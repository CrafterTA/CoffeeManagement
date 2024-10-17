using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductIngredientDTO
    {
        public int ProductIngredientID { get; set; }
        public int ProductID { get; set; }
        public int IngredientID { get; set; }
        public decimal Quantity { get; set; }
    }
}