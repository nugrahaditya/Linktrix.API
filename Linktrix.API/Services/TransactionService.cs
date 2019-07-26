using Linktrix.API.Domain.Models;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Domain.Service;
using Linktrix.API.Domain.Service.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linktrix.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository repository, IUnitOfWork unitOfWork)
        {
            this._transactionRepository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _transactionRepository.ListAsync();
        }

        public async Task<TransactionResponse> GetTransactionById(int transactionId)
        {
            var existingTransaction = await _transactionRepository.FindByIdAsync(transactionId);

            if (existingTransaction == null)
                return new TransactionResponse("Transaction not found.");

            return new TransactionResponse(existingTransaction);
        }

        public async Task<TransactionResponse> SaveAsync(Transaction transaction)
        {
            try
            {
                await _transactionRepository.AddAsync(transaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }

        public async Task<TransactionResponse> UpdateAsync(int transactionId, Transaction transaction)
        {
            var existingTransaction = await _transactionRepository.FindByIdAsync(transactionId);

            if (existingTransaction == null)
                return new TransactionResponse("Transaction not found.");

            existingTransaction.TransactionDatetime = transaction.TransactionDatetime;
            existingTransaction.CustomerId = transaction.CustomerId;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.CurrencyCode = transaction.CurrencyCode;
            existingTransaction.Status = transaction.Status;

            try
            {
                _transactionRepository.Update(existingTransaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(existingTransaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when updating the transaction: {ex.Message}");
            }
        }

        public async Task<TransactionResponse> DeleteAsync(int transactionId)
        {
            var existingTransaction = await _transactionRepository.FindByIdAsync(transactionId);

            if (existingTransaction == null)
                return new TransactionResponse("Transaction not found.");

            try
            {
                _transactionRepository.Remove(existingTransaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(existingTransaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when updating the transaction: {ex.Message}");
            }
        }
    }
}
