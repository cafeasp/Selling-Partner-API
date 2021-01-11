using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class ShipmentDates
    {

        [JsonProperty("requiredShipDate")]
        public DateTime RequiredShipDate { get; set; }

        [JsonProperty("promisedDeliveryDate")]
        public DateTime PromisedDeliveryDate { get; set; }
    }
}
