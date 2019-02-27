using System;
using System.Collections.Generic;
using System.Text;

namespace PayBakery.Proxy.Model
{
   public class TransferListMeta
    {

        public int total { get; set; }

        public int skipped { get; set; }

        public int perPage { get; set; }

        public int page { get; set; }

        public int pageCount { get; set; }

    }
}
