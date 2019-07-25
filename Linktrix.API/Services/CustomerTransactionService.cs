using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linktrix.API.Services
{
    public class CustomerTransactionService : ICustomerTransactionService
    {
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        public CustomerTransactionService(ICustomerTransactionRepository repository)
        {
            this._customerTransactionRepository = repository;
        }

        public async Task<IEnumerable<CustomerTransaction>> ListAsync()
        {
            return await _customerTransactionRepository.ListAsync();
        }
    }
}
