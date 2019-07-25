using System;

namespace Linktrix.API.Domain.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public long CustomerId { get; set; }
        public DateTime TransactionDatetime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
    }
}
