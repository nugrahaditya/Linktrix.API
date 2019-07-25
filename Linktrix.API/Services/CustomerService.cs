using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Domain.Service;
using Linktrix.API.Domain.Service.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);

                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when saving the customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(long customerId, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(customerId);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.Birthdate = customer.Birthdate;
            existingCustomer.ContactEmail = customer.ContactEmail;
            existingCustomer.MobileNumber = customer.MobileNumber;

            try
            {
                _customerRepository.Update(existingCustomer);

                return new CustomerResponse(existingCustomer);
            }
            catch(Exception ex)
            {
                return new CustomerResponse($"An error occurred when updating the customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> DeleteAsync(long customerId)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(customerId);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            try
            {
                _customerRepository.Remove(existingCustomer);

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when updating the customer: {ex.Message}");
            }
        }
    }
}
