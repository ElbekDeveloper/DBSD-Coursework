namespace Domain.Models
{
    public class Manufacturer : BaseEntity
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
