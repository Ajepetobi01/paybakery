using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
    public class TransferListData
    {
        public double integration { get; set; }

        public TransferListrecipent recipient { get; set; }

        public string domain { get; set; }

        public double amount { get; set; }

        public string currency { get; set; }

        public string source { get; set; }

        public string source_details { get; set; }

        public string reason { get; set; }

        public string status { get; set; }

        public string transfer_code { get; set; }

        public double   id { get; set; }

        public string createdAt { get; set; }

        public string  updatedAt { get; set; }


    }
}
