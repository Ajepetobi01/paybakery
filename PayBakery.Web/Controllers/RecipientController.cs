using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayBakery.Domain.Core.Interfaces;
using PayBakery.Proxy.Request;
using PayBakery.Web.Models;
using static PayBakery.Web.Enum.Notify;

namespace PayBakery.Web.Controllers
{
    public class RecipientController : Controller
    {

        private IRecipent _recipent;
        private IBankAccount _bankAccount;
        public RecipientController(IRecipent recipent, IBankAccount bankAccount)
        {
            _recipent = recipent;
            _bankAccount = bankAccount;

        }
        public IActionResult Index()
        {
            var result1 = _recipent.GetAllRecipents();
            var recipients = result1.Result.Result.data.ToList();
            var result2 = _bankAccount.GetAllBanks();
            var banks = result2.Result.Result.data.ToList();
            ViewBag.BANKS = banks;

            if (TempData["notification"] != null)
            {
                var message = (string)TempData["notification"];
                var notify = (NotificationType)TempData["notifytype"];
                Alert(message, notify);
            }


            return View(recipients);
        }


        public IActionResult AddRecipient(RecipientViewModel recipientView)
        {

            var recipientmetadata = new CreateRecipientMetadata()
            {
                job = recipientView.job
            };

            var newrecipient = new CreateRecipientRequestModel()
            {
                type = "nuban",
                name = recipientView.name,
                account_number = recipientView.account_number,
                bank_code = recipientView.bank_code,
                currency = "NGN",
                metadata = recipientmetadata

            };

            var result = _recipent.AddRecipient(newrecipient);

            var message = result.Result.Result.message;
            if (result.Result.Result.status == "true")
            {
                TempData["notification"] = "Recipient Added Successfully";
                TempData["notifytype"] = NotificationType.success;
            }
            else
            {
                TempData["notification"] = message;
                TempData["notifytype"] = NotificationType.error;

            }

            return RedirectToAction("Index");


        }
        public IActionResult SendMoney(string recipientcode, string accountnumber, string bankcode, string bankname, string name)
        {
            //Get user account name for final verification
            var result1 = _bankAccount.ResolveBankAccount(accountnumber, bankcode);
            var result2 = _bankAccount.GetPaystackBalance();

            var accountname = result1.Result.Result.data.account_name;
            var balance = result2.Result.Result.data[0].balance;

            var sendmoneyviewmodel = new SendMoneyViewModel
            {
                balance = balance,
                accountname = accountname,
                bankname = bankname,
                recipientcode = recipientcode,
                accountnumber = accountnumber,
                name = name

            };

            //pass object to the view
            return View(sendmoneyviewmodel);
        }


        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }
    }
}