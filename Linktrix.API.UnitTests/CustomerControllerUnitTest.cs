using AutoMapper;
using Linktrix.API.Controllers;
using Linktrix.API.Mapping;
using Linktrix.API.Persistence.Repositories;
using Linktrix.API.Services;
using Linktrix.API.UnitTests.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Linktrix.API.UnitTests
{
    public class CustomerControllerUnitTest
    {
        [Fact]
        public async Task TestGetAllCustomerAsync()
        {
            var dbContext = DbContextMocker.GetAppDbContext(nameof(TestGetAllCustomerAsync));
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new CustomerService(customerRepository);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResourceProfile());
            });
            var mapper = config.CreateMapper();
            var controller = new CustomersController(customerService, mapper);

            var response = await controller.GetAllAsync();

            dbContext.Dispose();

            //Assert.False(value == null);
        }
    }
}
