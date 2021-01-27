using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClient.InventoryModel
{

    public class InventoryDetails
    {
        public SellingParty sellingParty { get; set; }
        public bool isFullUpdate { get; set; }
        public List<InventoryItem> items { get; set; }
    }

    public class SellingParty
    {
        public string partyId { get; set; }
    }

    public class InventoryUpdate
    {
        public InventoryDetails inventory { get; set; }
    }

    public class InventoryItem
    {
        public string buyerProductIdentifier { get; set; }
        public string vendorProductIdentifier { get; set; }
        public bool isObsolete { get; set; }
        public Available availableQuantity { get; set; }
    }

    public class Available
    {
        public int amount { get; set; }
        public string unitOfMeasure { get; set; }
    }

}
