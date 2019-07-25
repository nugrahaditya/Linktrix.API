using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Repositories
{
    public interface ICustomerTransactionRepository
    {
        Task<IEnumerable<CustomerTransaction>> ListAsync();
    }
}
