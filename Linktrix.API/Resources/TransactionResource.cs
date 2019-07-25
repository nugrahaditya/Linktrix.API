using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linktrix.API.Resources
{
    public class TransactionResource
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDatetime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}
