using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollateralManagementMicroservice.DTO;
using LoanMangementMicroService.DTO;
using LoanMangementMicroService.Models;
using LoanMangementMicroService.Repository;

namespace LoanMangementMicroService.BusinessLogic
{
    public class LoanDetailsServices:ILoanDetailsServices
    {
        public readonly ICustomerLoanRepository _customerLoanRepository;
        public LoanDetailsServices(ICustomerLoanRepository customerLoanDetails)
        {

            _customerLoanRepository = customerLoanDetails;
        }
        public LoanDetailDto GetLoanDetails(int loanId)
        {
            return _customerLoanRepository.GetLoanDetails(loanId);
           
        }
        public string SaveCollaterals(CollateralLoanCashDepositDto collateralCashDeposit)
        {
            return _customerLoanRepository.SaveCollaterals(collateralCashDeposit);
        }

        public string SaveCollaterals(CollateralLoanRealEstateDto collateralRealEstate)
        {
            return _customerLoanRepository.SaveCollaterals(collateralRealEstate);
        }
    }
}

