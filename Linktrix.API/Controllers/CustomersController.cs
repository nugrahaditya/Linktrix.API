using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService service)
        {
            this._customerService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerService.ListAsync();
        }
    }
}