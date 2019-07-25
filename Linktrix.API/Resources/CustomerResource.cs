using System;
using System.Collections.Generic;

namespace Linktrix.API.Resources
{
    public class CustomerResource
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ContactEmail { get; set; }
        public long MobileNumber { get; set; }
        public IList<CustomerTransactionResource> CustomerTransactions { get; set; }
    }
}
