using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Currency
{
    public class Currency
    {
        public string Id { get; set; } = "";
        public string Symbol { get; set; } = "";
        public string Code { get; set; } = "";
        public bool IsActive { get; set; }
        public int CreatedAt { get; set; } = DateTime.Now.Millisecond;
        public List<CurrencyExchangeRate> ExchangeRates { get; set; } = new List<CurrencyExchangeRate>();
    }

    public class CurrencyExchangeRate
    {
        public string Code { get; set; } = "";
        public int Value { get; set; } = 0;
    }
}
