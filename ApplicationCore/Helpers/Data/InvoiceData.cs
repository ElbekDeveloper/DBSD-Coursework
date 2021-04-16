using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Helpers.Data
{
    public class InvoiceData
    {
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
        public int NumberOfIndividualProducts { get; set; }
    }
}
