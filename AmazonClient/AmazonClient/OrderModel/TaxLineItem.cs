using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class TaxLineItem
    {

        [JsonProperty("taxRate")]
        public string TaxRate { get; set; }

        [JsonProperty("taxAmount")]
        public TaxAmount TaxAmount { get; set; }
    }
}
