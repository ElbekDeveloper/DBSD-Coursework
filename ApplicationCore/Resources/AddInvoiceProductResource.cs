using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Resources
{
    public class AddInvoiceProductResource
    {
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal SoldQuantity { get; set; }
    }
}
