using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class Item
    {

        [JsonProperty("itemSequenceNumber")]
        public int ItemSequenceNumber { get; set; }

        [JsonProperty("buyerProductIdentifier")]
        public string BuyerProductIdentifier { get; set; }

        [JsonProperty("vendorProductIdentifier")]
        public string VendorProductIdentifier { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("orderedQuantity")]
        public OrderedQuantity OrderedQuantity { get; set; }

        [JsonProperty("netPrice")]
        public NetPrice NetPrice { get; set; }

        [JsonProperty("taxDetails")]
        public TaxDetails TaxDetails { get; set; }

        [JsonProperty("totalPrice")]
        public TotalPrice TotalPrice { get; set; }
    }
}
