using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralManagementMicroservice.DTO
{
    public class CollateralLoanRealEstateDto
    {
        public int CollateralId { get; set; }
        public int LoanId { get; set; }
        public DateTime PledgedDate { get; set; }
        public string AddressOfProperty { get; set; }
        public double RatePerSqFt { get; set; }
        public int AreaInSqFt { get; set; }
        public decimal DepriciationRate { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
