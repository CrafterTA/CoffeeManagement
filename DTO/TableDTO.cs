using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableDTO
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int AreaID { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }
    }
}
