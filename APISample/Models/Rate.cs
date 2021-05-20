using System;
using System.Collections.Generic;

#nullable disable

namespace APISample.Models
{
    public partial class Rate
    {
        public string CurrencyPair { get; set; }
        public double Value { get; set; }
    }
}
