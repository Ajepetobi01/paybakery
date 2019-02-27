using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
   public class RecipentListData
    {
        public string integration { get; set; }
        public string domain { get; set; }

        public string type { get; set; }

        public string currency { get; set; }

        public string name { get; set; }

        public RecipentListdetails details { get; set; }

        public RecipentListmetadata metadata { get; set; }

        public string recipient_code { get; set; }

        public bool active { get; set; }

        public double id { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }

    }
}
