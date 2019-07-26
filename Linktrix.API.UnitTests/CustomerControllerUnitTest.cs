using AutoMapper;
using Linktrix.API.Controllers;
using Linktrix.API.Mapping;
using Linktrix.API.Persistence.Contexts;
using Linktrix.API.Persistence.Repositories;
using Linktrix.API.Resources;
using Linktrix.API.Services;
using Linktrix.API.UnitTests.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Linktrix.API.UnitTests
{
    public class CustomerControllerUnitTest
    {
        public CustomersController ArrangeController(AppDbContext dbContext)
        {
            var customerRepository = new CustomerRepository(dbContext);
            var unitOfWork = new UnitOfWork(dbContext);
            var customerService = new CustomerService(customerRepository, unitOfWork);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResourceProfile());
            });
            var mapper = config.CreateMapper();

            return new CustomersController(customerService, mapper);
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            //ARRANGE
            var dbContext = DbContextMocker.GetAppDbContext(nameof(TestGetCustomerByIdAsync));
            var controller = ArrangeController(dbContext);

            //ACT
            var response = await controller.GetAllAsync() as List<CustomerResource>;

            dbContext.Dispose();

            //ASSERT
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public async Task TestGetCustomerByIdAsync()
        {
            //ARRANGE
            var dbContext = DbContextMocker.GetAppDbContext(nameof(TestGetCustomerByIdAsync));
            var controller = ArrangeController(dbContext);

            //ACT
            var response1 = await controller.GetCustomerByIdAsync(123456) as ObjectResult;
            var response2 = await controller.GetCustomerByIdAsync(1) as ObjectResult;

            dbContext.Dispose();

            //ASSERT
            var value = response1.Value as CustomerResource;
            Assert.Equal(200, response1.StatusCode);
            Assert.Equal(123456, value.CustomerId);
            Assert.Equal(400, response2.StatusCode);
        }

        [Fact]
        public async Task TestDeleteAsync()
        {
            //ARRANGE
            var dbContext = DbContextMocker.GetAppDbContext(nameof(TestDeleteAsync));
            var controller = ArrangeController(dbContext);

            //ACT
            var response = await controller.DeleteAsync(123457);
            var allCustomer = await controller.GetAllAsync() as List<CustomerResource>;

            dbContext.Dispose();

            //ASSERT
            Assert.Equal(2, allCustomer.Count);
        }
    }
}
