using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ExchageResult
    {
        public string CurrencyOr { get; set; }
        public string CurrencyDest { get; set; }
        public decimal Amount { get; set; }
        public decimal ExRate { get; set; }
    }
}