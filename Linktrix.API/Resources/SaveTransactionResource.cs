using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linktrix.API.Resources
{
    public class SaveTransactionResource
    {
        [Required]
        [MaxLength(10)]
        public long CustomerId { get; set; }
        [Required]
        public DateTime TransactionDatetime { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
