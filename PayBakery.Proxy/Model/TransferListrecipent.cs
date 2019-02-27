using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
   public  class TransferListrecipent
    {
        public string domain { get; set; }

        public string type { get; set; }

        public string currency { get; set; }

        public string name { get; set; }

        public List<TransferListdetails> details { get; set; }

        public string description { get; set; }

        public string metadata { get; set; }

        public string recipient_code { get; set; }

        public string active { get; set; }

        public string id { get; set; }

        public string integration { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }
    }
}
