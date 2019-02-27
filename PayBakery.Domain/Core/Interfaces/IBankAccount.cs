using PayBakery.Domain.Response;
using PayBakery.Proxy.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayBakery.Domain.Core.Interfaces
{
   public interface IBankAccount
    {
        Task<ServiceResponse<BalanceResponseModel>> GetPaystackBalance();

        Task<ServiceResponse<AccountDetailsResponseModel>> ResolveBankAccount(string accnumber, string bnk_code);

        Task<ServiceResponse<BankListResponseModel>> GetAllBanks();


    }
}
