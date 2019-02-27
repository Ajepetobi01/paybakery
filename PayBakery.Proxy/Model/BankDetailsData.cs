using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
   public class BankDetailsData
    {

        public string name { get; set; }

        public string  slug { get; set; }

        public string code { get; set; }

        public string longcode { get; set; }

        public string gateway { get; set; }

        public string pay_with_bank { get; set; }

        public bool active { get; set; }

        public string currency { get; set; }

        public string type { get; set; }
    }
}
