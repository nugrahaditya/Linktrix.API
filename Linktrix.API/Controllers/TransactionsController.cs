using AutoMapper;
using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service;
using Linktrix.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Controllers
{
    [Route("api/Transactions")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _customerTransactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService service, IMapper mapper)
        {
            this._customerTransactionService = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionResource>> ListAsync()
        {
            var customerTransactions = await _customerTransactionService.ListAsync();
            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionResource>>(customerTransactions);
        }
    }
}