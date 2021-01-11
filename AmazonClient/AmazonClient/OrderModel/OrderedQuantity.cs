using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class OrderedQuantity
    {

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
    }
}
