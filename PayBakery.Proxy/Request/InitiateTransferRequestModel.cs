using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Request
{
    public class InitiateTransferRequestModel
    {
        public string source { get; set; }

        public int amount { get; set; }

        public string currency { get; set; }

        public string reason { get; set; }

        public string recipient { get; set; }
    }
}
