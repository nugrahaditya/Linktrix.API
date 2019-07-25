using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
    }
}
