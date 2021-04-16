using System;
using System.Collections.Generic;

namespace ApplicationCore.Resources
{
    public class AddInvoiceResource
    {
        public DateTime CreatedDate { get; set; }
        public Boolean ConfirmationStatus { get; set; }
        public decimal TotalCost { get; set; }
        public int CreatedStaffId { get; set; }
        public int AgentId { get; set; }
        public int WarehouseId { get; set; }
        public List<AddInvoiceProductResource> Products { get; set; }
    }
}
