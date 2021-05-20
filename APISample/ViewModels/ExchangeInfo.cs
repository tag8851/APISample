using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.ViewModels
{
    public class ExchangeInfo
    {
        public string CurrencyPair{ get; set; }
        public double Rate { get; set; }
        public double Price { get; set; }
        public double ExchangePrice { get; set; }
    }
}
