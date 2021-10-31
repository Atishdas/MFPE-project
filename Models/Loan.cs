using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangementMicroService.Models
{
    [Table("Loans")]
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoanProductId { get; set; }
        public string LoanProduct { get; set; }
        public double MaxLoanEligible { get; set; }
        public double Interest { get; set; }
        public int Tenure { get; set; }
        public string TypeOfCollateral { get; set; }
    }
}
