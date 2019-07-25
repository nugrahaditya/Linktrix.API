using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linktrix.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _customerTransactionRepository;

        public TransactionService(ITransactionRepository repository)
        {
            this._customerTransactionRepository = repository;
        }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _customerTransactionRepository.ListAsync();
        }
    }
}
