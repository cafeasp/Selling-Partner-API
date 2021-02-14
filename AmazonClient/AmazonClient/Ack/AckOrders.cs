using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClient.Ack
{
    public class AckOrders
    {
        [JsonProperty("orderAcknowledgements")]
        public IList<OrderAcknowledgement> OrderAcknowledgements { get; set; }
    }

    public class AcknowledgementStatus
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class SellingParty
    {

        [JsonProperty("partyId")]
        public string PartyId { get; set; }
    }

    public class ShipFromParty
    {

        [JsonProperty("partyId")]
        public string PartyId { get; set; }
    }

    public class AcknowledgedQuantity
    {

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
    }

    public class ItemAcknowledgements
    {

        [JsonProperty("itemSequenceNumber")]
        public string ItemSequenceNumber { get; set; }

        [JsonProperty("buyerProductIdentifier")]
        public string BuyerProductIdentifier { get; set; }

        [JsonProperty("vendorProductIdentifier")]
        public string VendorProductIdentifier { get; set; }

        [JsonProperty("acknowledgedQuantity")]
        public AcknowledgedQuantity AcknowledgedQuantity { get; set; }
    }

    public class OrderAcknowledgement
    {

        [JsonProperty("purchaseOrderNumber")]
        public string PurchaseOrderNumber { get; set; }

        [JsonProperty("vendorOrderNumber")]
        public string VendorOrderNumber { get; set; }

        [JsonProperty("acknowledgementDate")]
        public string AcknowledgementDate { get; set; }

        [JsonProperty("acknowledgementStatus")]
        public AcknowledgementStatus AcknowledgementStatus { get; set; }

        [JsonProperty("sellingParty")]
        public SellingParty SellingParty { get; set; }

        [JsonProperty("shipFromParty")]
        public ShipFromParty ShipFromParty { get; set; }

        [JsonProperty("itemAcknowledgements")]
        public IList<ItemAcknowledgements> Items { get; set; }
    }

}
