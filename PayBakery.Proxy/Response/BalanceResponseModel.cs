using PayBakery.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Response
{
    public class BalanceResponseModel
    {
        public string status { get; set; }

        public string message { get; set; }

        public List<BalanceData> data { get; set; }
    }
}
