using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ExchangePetition
    {
        public string CurrencyOr { get; set; }
        public string CurrencyDest { get; set; }
        public decimal Amount { get; set; }

    }
}