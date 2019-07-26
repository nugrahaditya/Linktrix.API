using AutoMapper;
using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service;
using Linktrix.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            this._customerService = service;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerResource>), 200)]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerResource>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetCustomerByIdAsync(long customerId)
        {
            var result = await _customerService.GetCustomerByIdAsync(customerId);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(long customerId, [FromBody] SaveCustomerResource resource)
        {
            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.UpdateAsync(customerId, customer);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }

        [HttpDelete("{customerId}")]
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(long customerId)
        {
            var result = await _customerService.DeleteAsync(customerId);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Customer);
            return Ok(customerResource);
        }
    }
}