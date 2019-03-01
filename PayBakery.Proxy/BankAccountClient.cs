
using Microsoft.Extensions.Configuration;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Proxy
{
   public class BankAccountClient
    {
        private string _paystackEndPoints;
        private readonly IConfiguration _configuration;
        private readonly HttpRequestClient _requestClient;

        public BankAccountClient(HttpRequestClient httpRequestClient, IConfiguration configuration)
        {
            _configuration = configuration;
           _requestClient = httpRequestClient;
         
        }

    
        //This method gets the user paystack balance
        public async Task<BalanceResponseModel> GetBalance()
        {

            
           //pass url to get user paystack balance
            string url = $"{_configuration["PaystackEndPoints:baseUrl"]}" + $"{_configuration["PaystackEndPoints:Balance"]}"; 
            var result = await _requestClient.GetRequestAsync<BalanceResponseModel>(url);
            return result;
        }



        //This methods get the list of banks
        public async Task<BankListResponseModel> GetBanks()
        {

            string url = $"{_configuration["PaystackEndPoints:baseUrl"]}" + $"{_configuration["PaystackEndPoints:ListBanks"]}";
            var result = await _requestClient.GetRequestAsync<BankListResponseModel>(url);
            return result;

        }


        //This methods verify account number using account number and bank code
        public async Task<AccountDetailsResponseModel> ResolveAccount(string account_number, string bank_code)
        {
            var Formaturl = string.Format($"{_configuration["PaystackEndPoints:ResolveAccountNumber"]}", account_number, bank_code);

            var url = $"{_configuration["PaystackEndPoints:baseUrl"]}" + Formaturl;
            var result = await _requestClient.GetRequestAsync<AccountDetailsResponseModel>(url);
            return result;
        }

    }
}
