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
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> GetCustomerByIdAsync(long customerId)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(customerId);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            return new CustomerResponse(existingCustomer);
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

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
                await _unitOfWork.CompleteAsync();

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
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when updating the customer: {ex.Message}");
            }
        }
    }
}
