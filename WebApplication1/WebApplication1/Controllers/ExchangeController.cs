using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    public class ExchangeController : ApiController
    {

        private ExchangeRepo repo;

        public ExchangeController()
        {
            repo = new ExchangeRepo();
        }

        public ExchageResult[] Get()
        {
            return repo.GetExchageResults();
        }

        public bool Post(ExchangePetition petition)
        {
            return repo.AddExchangePetition(petition);
        }

        public bool Delete(int id)
        {
            return false;
        }

        public bool Put(int id, ExchangePetition petition)
        {
            return false;
        }


    }
}
