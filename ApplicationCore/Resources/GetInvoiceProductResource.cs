using System;

namespace ApplicationCore.Resources
{
    public class GetInvoiceProductResource
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Manufacturer { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal SoldPrice { get; set; }
        public int SoldQuantity { get; set; }

    }
}