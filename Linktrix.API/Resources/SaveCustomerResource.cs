using System;
using System.ComponentModel.DataAnnotations;

namespace Linktrix.API.Resources
{
    public class SaveCustomerResource
    {
        [Required]
        [MaxLength(30)]
        public string CustomerName { get; set; }
        public DateTime Birthdate { get; set; }
        [Required]
        [MaxLength(25)]
        public string ContactEmail { get; set; }
        public long MobileNumber { get; set; }
    }
}
