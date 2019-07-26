using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsync(Customer customer);
        Task<Customer> FindByIdAsync(long id);
        Task<Customer> FindCustomer(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
