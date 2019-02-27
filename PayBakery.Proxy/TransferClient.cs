
using Microsoft.Extensions.Configuration;
using PayBakery.Proxy.Model;
using PayBakery.Proxy.Request;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Proxy
{
   public class TransferClient
    {
        private HttpRequestClient _requestClient;
        private readonly IConfiguration _configuration;

        public TransferClient(HttpRequestClient requestClient, IConfiguration configuration)
        {

            _requestClient = requestClient;
            _configuration = configuration;
        }

        //This method returns all transactions from the paystack account
        public async Task<TransferListResponseModel> GetAllTransfers()
        {
            string url = $"{_configuration["PaystackEndPoints:ListTransfer"]}";
            var result = await _requestClient.GetRequestAsync<TransferListResponseModel>(url);
            return result;

        }

        //This method is used to initiate transfer from paystack endpoint
        public async Task<InitiateTransferResponseModel> InitiateTransfer(InitiateTransferRequestModel initiateTransferRequest )
        {

            string url = $"{_configuration["PaystackEndPoints:InitiateTransfer"]}";
            var result = await _requestClient.PostRequestAsync<InitiateTransferRequestModel, InitiateTransferResponseModel>(url, initiateTransferRequest);
            return result;
        }
    }
}
