using System;
using System.Collections.Generic;

namespace ApplicationCore.Resources
{
    public class GetInvoiceResource
    {
        //To avoid null reference exception 
        //initialize custom types in constructor
        public GetInvoiceResource()
        {
            CreatedStaff = new StaffMemberResource();
            CounterAgent = new CounterAgentResource();
            Warehouse = new WarehouseResource();
            Products = new List<GetInvoiceProductResource>();
        }
        public int InvoiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool ConfirmationStatus { get; set; }
        public decimal TotalCost { get; set; }
        public StaffMemberResource CreatedStaff { get; set; }
        public CounterAgentResource CounterAgent { get; set; }
        public WarehouseResource Warehouse { get; set; }
        public List<GetInvoiceProductResource> Products { get; set; }

    }
}