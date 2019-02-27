using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBakery.Web.Models
{
    public class SendMoneyViewModel
    {
        public double balance { get; set; }

        public string accountname { get; set; }

        public string recipientcode { get; set; }

        public string bankname { get; set; }

        public string name { get; set; }

        public string accountnumber { get; set; }

        public string reason { get; set; }

        public int amount { get; set; }
    }
}
