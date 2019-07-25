using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Service
{
    public interface ICustomerTransactionService
    {
        Task<IEnumerable<CustomerTransaction>> ListAsync();
    }
}
