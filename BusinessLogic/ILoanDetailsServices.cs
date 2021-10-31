using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollateralManagementMicroservice.DTO;
using LoanMangementMicroService.DTO;
using LoanMangementMicroService.Models;

namespace LoanMangementMicroService.BusinessLogic
{
    public interface ILoanDetailsServices
    {
        public LoanDetailDto GetLoanDetails(int loanId);
        public string SaveCollaterals(CollateralLoanRealEstateDto collateralRealEstate);
        public string SaveCollaterals(CollateralLoanCashDepositDto collateralCashDeposite);
    }
}
