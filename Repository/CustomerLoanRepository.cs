using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CollateralManagementMicroservice.DTO;
using LoanMangementMicroService.Controllers;
using LoanMangementMicroService.DBHandler;
using LoanMangementMicroService.DTO;
using LoanMangementMicroService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LoanMangementMicroService.Repository
{
    public class CustomerLoanRepository:ICustomerLoanRepository
    {
        public List<CustomerLoan> customerLoans;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerLoanRepository));
        readonly LoanManagementContext _context;
        public IConfiguration Configuration { get; }
        public CustomerLoanRepository(LoanManagementContext context,IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public LoanDetailDto GetLoanDetails(int loanId)
        {
            IEnumerable<LoanDetailDto> data = _context.CustomerLoans.Join(
                _context.Loans,
                customerLoan=>customerLoan.LoanProductId,
                loan=>loan.LoanProductId,
                (customerLoan, loan) => new LoanDetailDto
                {
                    LoanProductId=loan.LoanProductId,
                    LoanId=customerLoan.LoanId,
                    CustomerId=customerLoan.CustomerId,
                    LoanPrincipal=customerLoan.LoanPrincipal,
                    Tenure=loan.Tenure,
                    Interest=loan.Interest,
                    EMI=customerLoan.EMI
                }

                );
            return data.FirstOrDefault(c => c.LoanId == loanId);
        }

        public string SaveCollaterals(CollateralLoanCashDepositDto collateralLoanCashDeposit)
        {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                client.BaseAddress = new Uri(Configuration["ApiUrl:CollateralManagement"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(collateralLoanCashDeposit),Encoding.UTF8, "application/json");
                    response = client.PostAsync("CollateralManagement/saveCollateralsCashDeposit", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string stringData = response.Content.ReadAsStringAsync().Result;
                        return stringData;
                    }
                    else
                    {
                        return null;
                    }
                      
                }
        }


        public string SaveCollaterals(CollateralLoanRealEstateDto collateralLoanRealEstate)
        {
            
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri(Configuration["ApiUrl:CollateralManagement"]);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(collateralLoanRealEstate), Encoding.UTF8, "application/json");
                    response = client.PostAsync("CollateralManagement/saveCollateralsRealEstate", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string stringValue = response.Content.ReadAsStringAsync().Result;
                        return stringValue;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
