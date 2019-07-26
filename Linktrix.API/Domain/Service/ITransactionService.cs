using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Domain.Service
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> ListAsync();
        Task<TransactionResponse> GetTransactionById(int transactionId);
        Task<TransactionResponse> SaveAsync(Transaction transaction);
        Task<TransactionResponse> UpdateAsync(int transactionId, Transaction transaction);
        Task<TransactionResponse> DeleteAsync(int transactionId);
    }
}
