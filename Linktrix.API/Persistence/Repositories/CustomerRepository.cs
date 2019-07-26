using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _context.Customers.Include(x => x.CustomerTransactions)
                .AsNoTracking().ToListAsync();
        }
        
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task<Customer> FindCustomer(Customer customer)
        {
            if (customer.CustomerId != 0 && !string.IsNullOrEmpty(customer.ContactEmail))
                return await _context.Customers.Include(x => x.CustomerTransactions)
                    .FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId && x.ContactEmail == customer.ContactEmail);
            else if (customer.CustomerId == 0 && !string.IsNullOrEmpty(customer.ContactEmail))
                return await _context.Customers.Include(x => x.CustomerTransactions)
                    .FirstOrDefaultAsync(x => x.ContactEmail == customer.ContactEmail);
            else if (customer.CustomerId != 0 && string.IsNullOrEmpty(customer.ContactEmail))
                return await _context.Customers.Include(x => x.CustomerTransactions)
                    .FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);

            return null;
        }

        public async Task<Customer> FindByIdAsync(long id)
        {
            return await _context.Customers.Include(x => x.CustomerTransactions)
                .FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
        }
    }
}
