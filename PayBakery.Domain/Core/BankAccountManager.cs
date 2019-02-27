using PayBakery.Domain.Core.Interfaces;
using PayBakery.Domain.Response;
using PayBakery.Proxy;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Domain.Core
{
    public class BankAccountManager : IBankAccount
    {

        private BankAccountClient _bankAccountClient;

        public BankAccountManager(BankAccountClient bankAccountClient)
        {
            _bankAccountClient = bankAccountClient;

        }

        public async Task<ServiceResponse<BankListResponseModel>> GetAllBanks()
        {
            ServiceResponse<BankListResponseModel> serviceResponse = new ServiceResponse<BankListResponseModel>();
            try
            {

                var result = await _bankAccountClient.GetBanks();
                serviceResponse.Result = result;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<BalanceResponseModel>> GetPaystackBalance()
        {

            ServiceResponse<BalanceResponseModel> serviceResponse = new ServiceResponse<BalanceResponseModel>();
            try
            {

                var result = await _bankAccountClient.GetBalance();
                serviceResponse.Result = result;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                return serviceResponse;

            }
        }

        public async Task<ServiceResponse<AccountDetailsResponseModel>> ResolveBankAccount(string acctname, string bnkcode)
        {

            ServiceResponse<AccountDetailsResponseModel> serviceResponse = new ServiceResponse<AccountDetailsResponseModel>();
            try
            {
                var result = await _bankAccountClient.ResolveAccount(acctname, bnkcode);
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
