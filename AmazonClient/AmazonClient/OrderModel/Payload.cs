using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class Payload
    {

        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Order> Orders { get; set; }
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }
    }
}
