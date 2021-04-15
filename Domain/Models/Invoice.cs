using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Invoice:BaseEntity
    {
        //To avoid null reference exception 
        //initialize custom types in constructor
        public Invoice()
        {
            CreatedStaff = new StaffMember();
            CounterAgent = new CounterAgent();
            Warehouse = new Warehouse();
            Products = new List<InvoiceProduct>();
        }
        public int InvoiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool ConfirmationStatus { get; set; }
        public decimal TotalCost { get; set; }
        public StaffMember CreatedStaff { get; set; }
        public CounterAgent CounterAgent { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<InvoiceProduct> Products { get; set; }
    }
}
