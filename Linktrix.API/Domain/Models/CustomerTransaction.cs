using System;

namespace Linktrix.API.Domain.Models
{
    public class CustomerTransaction
    {
        public int TransactionId { get; set; }
        public long CustomerId { get; set; }
        public DateTime TransactionDatetime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
