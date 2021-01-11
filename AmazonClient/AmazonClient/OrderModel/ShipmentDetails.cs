using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class ShipmentDetails
    {

        [JsonProperty("isPriorityShipment")]
        public bool IsPriorityShipment { get; set; }

        [JsonProperty("isScheduledDeliveryShipment")]
        public bool IsScheduledDeliveryShipment { get; set; }

        [JsonProperty("isPslipRequired")]
        public bool IsPslipRequired { get; set; }

        [JsonProperty("shipMethod")]
        public string ShipMethod { get; set; }

        [JsonProperty("shipmentDates")]
        public ShipmentDates ShipmentDates { get; set; }
    }
}
