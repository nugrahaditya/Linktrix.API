using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task<Transaction> FindByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public void Remove(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }
    }
}
