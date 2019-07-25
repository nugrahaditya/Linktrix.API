using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
    }
}
