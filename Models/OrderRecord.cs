using CsvHelper.Configuration.Attributes;

namespace CsvReadWebExample.Models
{
    public class OrderRecord
    {
        [Name("PO")]
        public string Po { get; set; }
        
        [Name("Address")]
        public string Address { get; set; }
        
        [Name("SKU")]
        public string Sku { get; set; }
        
        [Name("Quantity")]
        public int Quantity { get; set; }
    }
}