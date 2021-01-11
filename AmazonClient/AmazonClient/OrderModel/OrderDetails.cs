using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class OrderDetails
    {
        [JsonProperty("customerOrderNumber")]
        public string CustomerOrderNumber { get; set; }

        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("shipmentDetails")]
        public ShipmentDetails ShipmentDetails { get; set; }

        [JsonProperty("taxTotal")]
        public TaxTotal TaxTotal { get; set; }

        [JsonProperty("sellingParty")]
        public SellingParty SellingParty { get; set; }

        [JsonProperty("shipFromParty")]
        public ShipFromParty ShipFromParty { get; set; }

        [JsonProperty("shipToParty")]
        public ShipToParty ShipToParty { get; set; }

        [JsonProperty("billToParty")]
        public BillToParty BillToParty { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }
    }
}
