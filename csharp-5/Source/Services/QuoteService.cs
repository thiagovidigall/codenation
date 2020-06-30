using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var quotesFilter = _context.Quotes.Where(x => x.Actor != null).ToList();
            if (quotesFilter.Count == 0)
                return null;
            
            return quotesFilter[_randomService.RandomInteger(_context.Quotes.Count())];
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotesFilter = _context.Quotes.Where(x => (x.Actor ?? "").ToLower().Contains(actor.ToLower())).ToList();

            if (quotesFilter.Count == 0)
                return null;
            
            var randomId = _randomService.RandomInteger(quotesFilter.Count());
            return quotesFilter[randomId];
        }
    }
}