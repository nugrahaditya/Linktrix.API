using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Persistence.Repositories
{
    public class CustomerTransactionRepository : BaseRepository, ICustomerTransactionRepository
    {
        public CustomerTransactionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<CustomerTransaction>> ListAsync()
        {
            return await _context.CustomerTransactions.AsNoTracking().ToListAsync();
        }
    }
}
