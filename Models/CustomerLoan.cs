using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangementMicroService.Models
{
    public class CustomerLoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoanId { get; set; }
        [ForeignKey("Loan")]
        public int LoanProductId { get; set; }
        public Loan Loan { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double LoanPrincipal { get; set; }
        public double EMI { get; set; }
    }
}
