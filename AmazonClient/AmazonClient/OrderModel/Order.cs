using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFOrder.Model
{
    public class Order
    {
        [JsonProperty("purchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }

        [JsonProperty("orderDetails")]
        public OrderDetails OrderDetails { get; set; }
    }
}
