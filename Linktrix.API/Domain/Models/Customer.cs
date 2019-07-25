using System;
using System.Collections.Generic;

namespace Linktrix.API.Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerTransactions = new List<CustomerTransaction>();
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ContactEmail { get; set; }
        public long MobileNumber { get; set; }

        public IList<CustomerTransaction> CustomerTransactions { get; set; }
    }
}
