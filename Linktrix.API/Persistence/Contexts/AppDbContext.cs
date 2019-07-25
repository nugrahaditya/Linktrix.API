﻿using Linktrix.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Linktrix.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().HasKey(x => x.CustomerId);
            builder.Entity<Customer>().Property(x => x.CustomerId).IsRequired().HasMaxLength(10).ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(x => x.CustomerName).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(x => x.Birthdate);
            builder.Entity<Customer>().Property(x => x.ContactEmail).IsRequired().HasMaxLength(25);
            builder.Entity<Customer>().Property(x => x.MobileNumber);
            builder.Entity<Customer>().HasMany(x => x.CustomerTransaction).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

            builder.Entity<Customer>().HasData
                (
                    new Customer
                    {
                        CustomerId = 123456,
                        CustomerName = "Aditya Nugraha",
                        Birthdate = new DateTime(1991, 1, 20),
                        ContactEmail = "adityanugraha@gmail.com",
                        MobileNumber = 6281231234
                    }, 
                    new Customer
                    {
                        CustomerId = 123457,
                        CustomerName = "Johnny Welch",
                        Birthdate = new DateTime(1980, 10, 2),
                        ContactEmail = "JohnnyWelch@gmail.com",
                        MobileNumber = 7272072858
                    },
                    new Customer
                    {
                        CustomerId = 123458,
                        CustomerName = "Paula Taylor",
                        Birthdate = new DateTime(1988, 5, 15),
                        ContactEmail = "PaulaTaylor@gmail.com",
                        MobileNumber = 6108144644
                    }
                );

            builder.Entity<CustomerTransaction>().ToTable("CustomerTransaction");
            builder.Entity<CustomerTransaction>().HasKey(x => x.TransactionId);
            builder.Entity<CustomerTransaction>().Property(x => x.TransactionId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CustomerTransaction>().Property(x => x.TransactionDatetime).IsRequired();
            builder.Entity<CustomerTransaction>().Property(x => x.Amount).IsRequired();
            builder.Entity<CustomerTransaction>().Property(x => x.CurrencyCode).IsRequired().HasMaxLength(3);
            builder.Entity<CustomerTransaction>().Property(x => x.Status).IsRequired();

            builder.Entity<CustomerTransaction>().HasData
                (
                    new CustomerTransaction
                    {
                        TransactionId = 100,
                        CustomerId = 123456,
                        TransactionDatetime = new DateTime(2019, 1, 1),
                        Amount = (decimal)500.59,
                        CurrencyCode = "USD",
                        Status = "Success"
                    },
                    new CustomerTransaction
                    {
                        TransactionId = 101,
                        CustomerId = 123456,
                        TransactionDatetime = new DateTime(2019, 3, 10),
                        Amount = (decimal)200,
                        CurrencyCode = "USD",
                        Status = "Failed"
                    },
                    new CustomerTransaction
                    {
                        TransactionId = 102,
                        CustomerId = 123457,
                        TransactionDatetime = new DateTime(2019, 2, 14),
                        Amount = (decimal)200000,
                        CurrencyCode = "IDR",
                        Status = "Success"
                    }
                );
        }
    }
}
