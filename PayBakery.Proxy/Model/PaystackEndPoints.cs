using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
   public class PaystackEndPoints
    {
        public string Balance { get; set; }

        public string ResolveAccountNumber { get; set; }

        public string ListTransferRecipents { get; set; }

        public string CreateTransferRecipents { get; set; }

        public string UpdateTransferRecipents { get; set; }

        public string DeleteTransferRecipents { get; set; }

        public string InitiateTransfer { get; set; }

        public string ListTransfer { get; set; }

        public string InitiateBulkTransfer { get; set; }

        public string FetchTransfer { get; set; }

        public string ListBanks { get; set; }

        public string PaystackAPIKEY { get; set; }
    }
}
