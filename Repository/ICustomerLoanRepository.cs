using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollateralManagementMicroservice.DTO;
using LoanMangementMicroService.DTO;
using LoanMangementMicroService.Models;

namespace LoanMangementMicroService.Repository
{
    public interface ICustomerLoanRepository
    {
        public LoanDetailDto GetLoanDetails(int LoanId);
        public string SaveCollaterals(CollateralLoanCashDepositDto collateralLoanCashDeposit);
        string SaveCollaterals(CollateralLoanRealEstateDto collateralLoanRealEstate);
    }
}
