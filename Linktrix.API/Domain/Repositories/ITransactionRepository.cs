using Linktrix.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> ListAsync();
        Task AddAsync(Transaction transaction);
        Task<Transaction> FindByIdAsync(int id);
        void Update(Transaction transaction);
        void Remove(Transaction transaction);
    }
}
