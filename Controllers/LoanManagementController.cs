using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CollateralManagementMicroservice.DTO;
using LoanMangementMicroService.BusinessLogic;
using LoanMangementMicroService.Constants;
using LoanMangementMicroService.DBHandler;
using LoanMangementMicroService.DTO;
using LoanMangementMicroService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanMangementMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    
    public class LoanManagementController : ControllerBase
    {
        public readonly ILoanDetailsServices _loanDetails;
        public static readonly log4net.ILog   _log4net = log4net.LogManager.GetLogger(typeof(LoanManagementController));
        public LoanManagementController(ILoanDetailsServices loanDetails)
        {
            _loanDetails = loanDetails;

        }

        [Route(LoanManagementControllerConstant.loanDetails)]
        [HttpGet]
        public  ActionResult<LoanDetailDto> GetLoanDetails([FromQuery] int loanId)
        {
            try
            {
                if (loanId > 0)
                {
                    _log4net.Info("Get Loan details is Accesed  " + loanId);
                    return Ok(_loanDetails.GetLoanDetails(loanId));
                }
                else
                {
                    _log4net.Info("Invalid value is entered " + loanId);
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in GetLoanDetails" + e.Message);
                return BadRequest(e.Message);
            }
            
          
        }



        [Route(LoanManagementControllerConstant.cashDeposite)]
        [HttpPost]
        public  ActionResult SaveCollaterals([FromBody] CollateralLoanCashDepositDto _cashDeposit)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _log4net.Info("saved the collaterals of CashDeposite");
                    return Ok(_loanDetails.SaveCollaterals(_cashDeposit));
                }
                else
                {
                    _log4net.Info("invalid inputs are given");
                    return NoContent();
                }

            }
            catch (Exception exception)
            {
                _log4net.Info("Error Occured.Exception Message: " + exception.Message);
                return BadRequest(exception.Message);
            }

           

        }


        [Route(LoanManagementControllerConstant.realEstate)]
        [HttpPost]
        public ActionResult SaveCollaterals([FromBody] CollateralLoanRealEstateDto _realEstate)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _log4net.Info("saved the collaterals of RealEstate");
                    return Ok(_loanDetails.SaveCollaterals(_realEstate));
                }
                else
                {
                    _log4net.Info("invalid inputs are given");
                    return NoContent();
                }

            }
            catch (Exception exception)
            {
                _log4net.Info("Error Occured.Exception Message: " + exception.Message);
                return BadRequest(exception.Message);
            }

        }

    }
}
