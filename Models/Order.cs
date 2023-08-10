using System.Collections.Generic;

namespace CsvReadWebExample.Models
{
    public class Line
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }
    public class Order
    {
        public string Po { get; set; }
        public string Address { get; set; }
        public List<Line> OrderLines { get; set; }
    }
}