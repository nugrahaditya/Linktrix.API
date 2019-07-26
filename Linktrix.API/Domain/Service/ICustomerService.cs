using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<CustomerResponse> GetCustomerByIdAsync(long customerId);
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(long customerId, Customer customer);
        Task<CustomerResponse> DeleteAsync(long customerId);
    }
}
