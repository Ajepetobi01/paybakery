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
    public class TransferManager : ITransfer
    {
        private TransferClient _transferClient;

        public TransferManager(TransferClient transferClient)
        {
            _transferClient = transferClient;
        }
        public async Task<ServiceResponse<TransferListResponseModel>> GetAllTransfers()
        {
            ServiceResponse<TransferListResponseModel> serviceResponse = new ServiceResponse<TransferListResponseModel>();
            try
            {

                var result = await _transferClient.GetAllTransfers();
                serviceResponse.Result = result;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                return serviceResponse;

            }


        }

        public async Task<ServiceResponse<InitiateTransferResponseModel>> InitiateTransfer(InitiateTransferRequestModel initiateTransferRequest)
        {
            ServiceResponse<InitiateTransferResponseModel> serviceResponse = new ServiceResponse<InitiateTransferResponseModel>();
            try
            {
                var result = await _transferClient.InitiateTransfer(initiateTransferRequest);
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
