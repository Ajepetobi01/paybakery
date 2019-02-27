using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayBakery.Domain.Core.Interfaces;
using PayBakery.Web.Models;

namespace PayBakery.Web.Controllers
{
    public class HomeController : Controller
    {
        private IBankAccount _bankAccount;
        private IRecipent _recipent;
        private ITransfer _transfer;

        public HomeController(IBankAccount bankAccount, IRecipent recipent, ITransfer transfer)
        {
            _bankAccount = bankAccount;
            _recipent = recipent;
            _transfer = transfer;
        }

        public IActionResult Index()
        {
            HomeStatisticsViewModel hmvm = new HomeStatisticsViewModel();

            try
            {
                var result = _bankAccount.GetPaystackBalance();
                var result2 = _recipent.GetAllRecipents();
                var result3 = _transfer.GetAllTransfers();

                hmvm.Balance = result.Result.Result.data.First();
                hmvm.RecipentCount = result2.Result.Result.data.Count();
                hmvm.TransactionCount = result3.Result.Result.data.Count();


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return View(hmvm);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //This methods takes account number and bank code to verify account and returns account name as string
        public string ResolveAccount(string accnumber, string bnk_code)
        {
            string accountname = "";
          
            try
            {

               var  result = _bankAccount.ResolveBankAccount(accnumber, bnk_code);

                accountname = result.Result.Result.data.account_name;


            }
            catch(Exception ex)
            {

                throw ex;
            }

            return accountname;

        }
    }
}
