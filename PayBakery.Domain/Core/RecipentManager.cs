using PayBakery.Domain.Core.Interfaces;
using PayBakery.Domain.Response;
using PayBakery.Proxy;
using PayBakery.Proxy.Request;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Domain.Core
{
    public class RecipentManager : IRecipent
    {

        private RecipentClient _recipentClient;

        public RecipentManager(RecipentClient recipentClient)
        {
            _recipentClient = recipentClient;

        }

        public async Task<ServiceResponse<NewRecipientResponseModel>> AddRecipient(CreateRecipientRequestModel model)
        {
            ServiceResponse<NewRecipientResponseModel> serviceResponse = new ServiceResponse<NewRecipientResponseModel>();
            try
            {
                var result = await _recipentClient.PostNewRecipient(model);
                serviceResponse.Result = result;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                return serviceResponse;

            }
        }

        public async Task<ServiceResponse<RecipentListResponseModel>> GetAllRecipents()
        {

            ServiceResponse<RecipentListResponseModel> serviceResponse = new ServiceResponse<RecipentListResponseModel>();
            try
            {

                var result = await _recipentClient.GetAllRecipents();
                serviceResponse.Result = result;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                return serviceResponse;

            }
        }
    }
}
