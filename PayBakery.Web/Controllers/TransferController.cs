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
    public class TransferController : Controller
    {
        private ITransfer _transfer;
        private IBankAccount _bankAccount;
        private IRecipent _recipient;

        public TransferController(ITransfer transfer, IBankAccount bankAccount, IRecipent recipent)
        {
            _transfer = transfer;
            _bankAccount = bankAccount;
            _recipient = recipent;
        }
        public IActionResult Index()
        {

           
            
            var result1 = _transfer.GetAllTransfers();
            var transfer = result1.Result.Result.data.ToList();

            if (TempData["notification"] != null)
             {
                var message = (string)TempData["notification"];
                var notify = (NotificationType)TempData["notifytype"];
                Alert(message, notify);
            }

            return View(transfer);
        }


        public IActionResult InitiateTransfer(SendMoneyViewModel sendMoneyViewModel)
        {

            var initiatetransfer = new InitiateTransferRequestModel
            {
                reason = sendMoneyViewModel.reason,
                source = "balance",
                amount = sendMoneyViewModel.amount,
                recipient = sendMoneyViewModel.recipientcode,
                currency = "NGN"

            };

            var result1 = _transfer.InitiateTransfer(initiatetransfer);
            var message = result1.Result.Result.message;
            if (result1.Result.Result.status == "true")
            {
                TempData["notification"] = "Transfer Initiated Successfully";
                TempData["notifytype"] = NotificationType.success;
            }
            else
            {
                TempData["notification"] = message;
                TempData["notifytype"] = NotificationType.error;

            }

            
            return RedirectToAction("Index");
        }





        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }


    }
}