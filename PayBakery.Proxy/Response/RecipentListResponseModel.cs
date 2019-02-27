using PayBakery.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Response
{
  public  class RecipentListResponseModel
    {
       public string status { get; set; }

        public string message { get; set; }

        public List<RecipentListData> data { get; set; }

        public RecipentListMeta meta { get; set; }


    }
}
