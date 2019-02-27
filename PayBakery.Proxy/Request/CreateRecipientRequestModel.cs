using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Request
{
   public class CreateRecipientRequestModel
    {

        public string type { get; set; }

        public string name { get; set; }

        public string account_number { get; set; }

        public string bank_code { get; set; }

        public string currency { get; set; }

        public CreateRecipientMetadata metadata { get; set; }

    }

    public class CreateRecipientMetadata
    {
        public string job { get; set; }

    }
}
