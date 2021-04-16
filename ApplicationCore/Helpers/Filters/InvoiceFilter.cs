using System;
using System.Collections.Generic;

namespace ApplicationCore.Helpers.Filters {
  public class InvoiceFilter {
    public DateTime? DateStart {
      get;
      set;
    }
    public DateTime? DateEnd {
      get;
      set;
    }
    public bool ? AgentIsCustomer {
      get;
      set;
    }
    public bool ? AgentIsSeller {
      get;
      set;
    }
    public decimal? MinPrice {
      get;
      set;
    }
    public decimal? MaxPrice {
      get;
      set;
    }
    public string StaffName {
      get;
      set;
    }
    public string ProductName {
      get;
      set;
    }
    // public List<string> SortBy { get; set; }
  }
}
