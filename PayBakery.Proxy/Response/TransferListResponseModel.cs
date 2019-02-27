using PayBakery.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Response
{
    public class TransferListResponseModel
    {
        public string status { get; set; }

        public string message { get; set; }

        public List<TransferListData> data { get; set; }

        public TransferListMeta meta { get; set; }
    }
}
