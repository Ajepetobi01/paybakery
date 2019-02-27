using PayBakery.Proxy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBakery.Web.Models
{
    public class HomeStatisticsViewModel
    {
        public BalanceData Balance { get; set; }

        public int TransactionCount { get; set; }

        public int RecipentCount { get; set; }
    }
}
