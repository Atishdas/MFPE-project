using LoanMangementMicroService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangementMicroService.DBHandler
{
    public class LoanManagementContext:DbContext
    {
        public LoanManagementContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLoan> CustomerLoans { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
