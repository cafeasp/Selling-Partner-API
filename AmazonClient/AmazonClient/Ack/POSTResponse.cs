using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonClient.Ack
{
    public class POSTResponse
    {
        [JsonProperty("payload")]
        public ResponseTransaction Payload { get; set; }
    }

    public class ResponseTransaction
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }

}
