using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagementMicroservice.DTO
{
    public class CollateralLoanCashDepositDto
    {
        public int CollateralId { get; set; }
        public int LoanId { get; set; }
        public DateTime PledgedDate { get; set; }
        public string BankName { get; set; }
        public double DepositAmount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime DateOfDeposit { get; set; }
        public int LockPeriod { get; set; }
    }
}
