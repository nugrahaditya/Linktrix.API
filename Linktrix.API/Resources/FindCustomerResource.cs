using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linktrix.API.Resources
{
    public class FindCustomerResource
    {
        public long CustomerId { get; set; }
        public string ContactEmail { get; set; }
    }
}
