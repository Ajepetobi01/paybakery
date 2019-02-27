using PayBakery.Domain.Response;
using PayBakery.Proxy.Request;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Domain.Core.Interfaces
{
  public  interface ITransfer
    {
        Task<ServiceResponse<TransferListResponseModel>> GetAllTransfers();

        Task<ServiceResponse<InitiateTransferResponseModel>> InitiateTransfer(InitiateTransferRequestModel initiateTransferRequest);
    }
}
