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
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        }
    }
}