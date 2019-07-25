using AutoMapper;
using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service;
using Linktrix.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Controllers
{
    [Route("api/CustomerTransactions")]
    [ApiController]
    public class CustomerTransactionsController : Controller
    {
        private readonly ICustomerTransactionService _customerTransactionService;
        private readonly IMapper _mapper;

        public CustomerTransactionsController(ICustomerTransactionService service, IMapper mapper)
        {
            this._customerTransactionService = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerTransactionResource>> ListAsync()
        {
            var customerTransactions = await _customerTransactionService.ListAsync();
            return _mapper.Map<IEnumerable<CustomerTransaction>, IEnumerable<CustomerTransactionResource>>(customerTransactions);
        }
    }
}