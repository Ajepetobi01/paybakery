using PayBakery.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Response
{
    public class BankListResponseModel
    {
        public string status { get; set; }

        public string message { get; set; }

        public List<BankDetailsData> data { get; set; }
    }
}
