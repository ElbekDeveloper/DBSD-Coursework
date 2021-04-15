using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Resources
{
    public class GetProductResource
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ManufacturerResource Manufacturer { get; set; }
        public string  MeasurementUnit { get; set; }
        public int QuantityAtWarehouse { get; set; }

    }
}
