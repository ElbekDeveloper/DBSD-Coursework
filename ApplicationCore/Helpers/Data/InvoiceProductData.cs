using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Helpers.Data
{
    public class InvoiceProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CalculatedPrice { get; set; }
        public decimal Profit { get; set; }
    }
}
