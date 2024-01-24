using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ExchangeRepo
    {
        private const string CacheKey = "ExchangeStore";
        private const decimal TazaDeCambioUSD_EUR = 1.10m;
        private const decimal TazaDeCambioEUR_JPY = 163m;
        private const decimal TazaDeCambioUSD_JPY = 149m;

        #region GET
        public ExchageResult[] GetExchageResults()
        {

            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (ExchageResult[])ctx.Cache[CacheKey];
            }
            else { return null; }

        }
        #endregion

        #region POST
        public bool AddExchangePetition(ExchangePetition petition)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    ExchageResult Exedpetition = ProcessPetition(petition);
                    var currentData = (ctx.Cache[CacheKey] as ExchageResult[])?.ToList() ?? new List<ExchageResult>();
                    currentData.Add(Exedpetition);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region ExchangeOperation
        public ExchageResult ProcessPetition(ExchangePetition petition) 
        { 
            decimal Result = ExchangeAmount(petition);

            ExchageResult Exedpetition = new ExchageResult();
            Exedpetition.CurrencyOr = petition.CurrencyOr;
            Exedpetition.CurrencyDest = petition.CurrencyDest;
            Exedpetition.Amount = Result;
            Exedpetition.ExRate = TazaDeCambioFinal(petition);

            return Exedpetition;
        
        
        }

        public decimal ExchangeAmount(ExchangePetition petition)
        {
            return Math.Round(petition.Amount * TazaDeCambioFinal(petition),2);
        }

        public decimal TazaDeCambioFinal(ExchangePetition petition)
        {
           if(petition.CurrencyOr == "USD" && petition.CurrencyDest == "EUR") {return Math.Round(1/TazaDeCambioUSD_EUR,2);}
           else if(petition.CurrencyOr == "EUR" && petition.CurrencyDest == "JPY"){return TazaDeCambioEUR_JPY;}
           else if(petition.CurrencyOr == "USD" && petition.CurrencyDest == "JPY"){return TazaDeCambioUSD_JPY;}
           else if(petition.CurrencyOr == "EUR" && petition.CurrencyDest == "USD"){return TazaDeCambioUSD_EUR;}
           else if(petition.CurrencyOr == "JPY" && petition.CurrencyDest == "EUR"){return Math.Round(1/TazaDeCambioEUR_JPY,2);}
           else if(petition.CurrencyOr == "JPY" && petition.CurrencyDest == "USD"){return Math.Round(1 / TazaDeCambioUSD_JPY,2);}
           else { return -1;}
        }
        #endregion
    }
}