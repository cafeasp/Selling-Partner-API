using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class NetPrice
    {

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
