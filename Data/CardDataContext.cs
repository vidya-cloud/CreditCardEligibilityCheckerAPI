using CreditCardEligibilityCheckerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreditCardEligibilityCheckerAPI.Data
{
    /// <summary>
    /// Database context for the application
    /// </summary>
    public class CardDataContext : DbContext
    {
        /// <summary>
        /// Constructor for Data Context
        /// </summary>
        /// <param name="options"></param>
        public CardDataContext(DbContextOptions<CardDataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Table CreditCardType
        /// </summary>
        public DbSet<CreditCardType> CreditCardType { get; set; }

        /// <summary>
        /// Audit table
        /// </summary>
        public DbSet<Audit> CreditCardAudit { get; set; }

        /// <summary>
        /// OnModelCreating is required for initial seeding of data to database
        /// to work with data in parents tables 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding data in to Credit Crad Type table
            modelBuilder.Entity<CreditCardType>().HasData(
                new CreditCardType
                {
                    CardId = "BAR",
                    Name = "Barclays",
                    APR = 33.90F,
                    PromotionalMessage = "0.25% cashback on all your spend.No fees abroad – you’ll be able to withdraw cash from an ATM or buy your souvenirs without any charges and benefit from Visa’s competitive exchange rate"
                },
                new CreditCardType
                {
                    CardId = "VAN",
                    Name = "Vanquis",
                    APR = 39.90F,
                    PromotionalMessage = "Great for credit building. Opening credit limit of £150 - £1,000.Increase your credit limit after the fifth statement,subject to eligibility.Manage your spending online or via the Vanquis app.Quick and easy eligibility check that won’t affect your credit score"
                }
            );

            //Seeding data in to Audit table
            modelBuilder.Entity<Audit>().HasData(
               new Audit
               {
                   CardId = "BAR",
                   AuditId = 1,
                   FirstName = "Jone",
                   LastName = "Boll",
                   DOB = "01-01-2010",
                   AnnualIncome = 30000,
                   CreatedDateTime = DateTime.UtcNow
               }
           ); ;
        }
    }
}
