using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Order
    {
        public int Id { get; set; }                           // Default: 0
        public DateTime Date { get; set; }                    // Default: DateTime.MinValue
        public DateTime Required { get; set; }                // Default: DateTime.MinValue
        public DateTime? Shipped { get; set; }                // Nullable - can be null
        public decimal Freight { get; set; }                  // Default: 0
        public string ShipName { get; set; }                  // Default: null
        public string ShipCity { get; set; }                  // Default: null
        public List<OrderDetails> OrderDetails { get; set; }  // Default: null
    }
}
