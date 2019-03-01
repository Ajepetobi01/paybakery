
using Microsoft.Extensions.Configuration;
using PayBakery.Proxy.Request;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Proxy
{
    public class RecipentClient
    {

        private HttpRequestClient _requestClient;
        private readonly IConfiguration _configuration;
        public RecipentClient(HttpRequestClient requestClient, IConfiguration configuration)
        {
            _requestClient = requestClient;
            _configuration = configuration;
        }


        //This methods list all recipents added to the account on paystack
        public async Task<RecipentListResponseModel> GetAllRecipents()
        {

            string url = $"{_configuration["PaystackEndPoints:baseUrl"]}" + $"{_configuration["PaystackEndPoints:ListTransferRecipents"]}";
            var result = await _requestClient.GetRequestAsync<RecipentListResponseModel>(url);
            return result;
        }


        //add new recipient to recipient list
        public async Task<NewRecipientResponseModel> PostNewRecipient(CreateRecipientRequestModel createrecipient)
        {
            string url = $"{_configuration["PaystackEndPoints:baseUrl"]}" + $"{_configuration["PaystackEndPoints:CreateTransferRecipents"]}";
            var result = await _requestClient.PostRequestAsync<CreateRecipientRequestModel, NewRecipientResponseModel>(url, createrecipient);
            return result;
        }
    }
}
