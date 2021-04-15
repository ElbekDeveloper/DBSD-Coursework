using System;

namespace ApplicationCore.Resources
{
    public class AddProductResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ManufacturerId { get; set; }
        public int MeasurementUnitId { get; set; }
        public int QuantityAtWarehouse { get; set; }
    }
}
