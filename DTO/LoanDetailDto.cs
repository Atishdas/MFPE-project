using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMangementMicroService.DTO
{
    public class LoanDetailDto
    {
        public int LoanProductId { get; set; }
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public double LoanPrincipal { get; set; }
        public int Tenure { get; set; }
        public double Interest { get; set; }
        public double EMI { get; set; }
        public int CollateralID { get; set; }
    }
}
