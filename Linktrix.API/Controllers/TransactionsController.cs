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
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService service, IMapper mapper)
        {
            this._transactionService = service;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionResource>), 200)]
        public async Task<IEnumerable<TransactionResource>> ListAsync()
        {
            var transactions = await _transactionService.ListAsync();
            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionResource>>(transactions);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTransactionResource resource)
        {
            var transaction = _mapper.Map<SaveTransactionResource, Transaction>(resource);
            var result = await _transactionService.SaveAsync(transaction);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);
            return Ok(transactionResource);
        }

        [HttpPut("{transactionId}")]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int transactionId, [FromBody] SaveTransactionResource resource)
        {
            var transaction = _mapper.Map<SaveTransactionResource, Transaction>(resource);
            var result = await _transactionService.UpdateAsync(transactionId, transaction);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);
            return Ok(transactionResource);
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(typeof(TransactionResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int transactionId)
        {
            var result = await _transactionService.DeleteAsync(transactionId);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);
            return Ok(transactionResource);
        }
    }
}