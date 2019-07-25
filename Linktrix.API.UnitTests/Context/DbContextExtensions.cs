using Linktrix.API.Domain.Models;
using Linktrix.API.Persistence.Contexts;
using System;

namespace Linktrix.API.UnitTests.Context
{
    public static class DbContextExtensions
    {
        public static void Seed(this AppDbContext dbContext)
        {
            dbContext.Customers.Add(new Customer
            {
                CustomerId = 123456,
                CustomerName = "Aditya Nugraha",
                Birthdate = new DateTime(1991, 1, 20),
                ContactEmail = "adityanugraha@gmail.com",
                MobileNumber = 6281231234
            });

            dbContext.Customers.Add(new Customer
            {
                CustomerId = 123457,
                CustomerName = "Johnny Welch",
                Birthdate = new DateTime(1980, 10, 2),
                ContactEmail = "JohnnyWelch@gmail.com",
                MobileNumber = 7272072858
            });

            dbContext.Customers.Add(new Customer
            {
                CustomerId = 123458,
                CustomerName = "Paula Taylor",
                Birthdate = new DateTime(1988, 5, 15),
                ContactEmail = "PaulaTaylor@gmail.com",
                MobileNumber = 6108144644
            });

            dbContext.Transactions.Add(new Transaction
            {
                TransactionId = 100,
                CustomerId = 123456,
                TransactionDatetime = new DateTime(2019, 1, 1),
                Amount = (decimal)500.59,
                CurrencyCode = "USD",
                Status = "Success"
            });

            dbContext.Transactions.Add(new Transaction
            {
                TransactionId = 101,
                CustomerId = 123456,
                TransactionDatetime = new DateTime(2019, 3, 10),
                Amount = (decimal)200,
                CurrencyCode = "USD",
                Status = "Failed"
            });

            dbContext.Transactions.Add(new Transaction
            {
                TransactionId = 102,
                CustomerId = 123457,
                TransactionDatetime = new DateTime(2019, 2, 14),
                Amount = (decimal)200000,
                CurrencyCode = "IDR",
                Status = "Success"
            });

            dbContext.SaveChanges();
        }
    }
}
