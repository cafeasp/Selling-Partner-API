using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Signer;
using DFOrder.Model;
using AmazonClient.InventoryModel;

namespace AmazonClient
{
    class Program
    {
        #region Prop
        static private AuthHelper signatureHelper;
        static private RestClient restClient;
        static private RestRequest restRequest;
        private const string live_url_base = "https://sellingpartnerapi-na.amazon.com";
        private const string sandbox_url_base = "https://sandbox.sellingpartnerapi-na.amazon.com";//did not work
        static string content_form_urlencoded = "application/x-www-form-urlencoded";
        static string content_json = "application/json";
        static string purchase_order_resource = "/vendor/directFulfillment/orders/v1/purchaseOrders";
        #endregion
        static void Main(string[] args)
        {
            

            signatureHelper = new AuthHelper(
                 AppCred.Default.ClientId, AppCred.Default.ClientSecret, AppCred.Default.RefreshToken, new Uri(AppCred.Default.Endpoint),
                 AppCred.Default.AccessKeyId, AppCred.Default.SecretKey, AppCred.Default.Region
            );

            //OrderImport();

            UpdateInventory();
        }


        static void OrderImport()
        {
            restClient = new RestClient(live_url_base);
            IRestRequest restRequest = new RestRequest(purchase_order_resource, Method.GET);

            restRequest.AddHeader("x-amz-access-token", "token_from_your_secure_db");

            restRequest.AddQueryParameter("createdAfter", DateTime.Now.AddHours(-7).ToString("o"));
            restRequest.AddQueryParameter("createdBefore", DateTime.Now.ToString("o"));

            var request = signatureHelper.SignRequest(restRequest, restClient, content_form_urlencoded);

            try
            {
                var result = restClient.Execute(request);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //read your orders
                    var payload = JsonConvert.DeserializeObject<Payload>(result.Content);

                    foreach (var order in payload.Orders)
                    {
                        string po = order.PurchaseOrderNumber;
                        DateTime orderDate = order.OrderDetails.OrderDate;


                        foreach (var item in order.OrderDetails.Items)
                        {
                            string vendorSku = item.VendorProductIdentifier;
                            string price = item.NetPrice.Amount;
                            int qty = item.OrderedQuantity.Amount;

                        }
                    }
                    
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    //bad token
                    string new_token = signatureHelper.GetToken();

                    //save new_token to your secure location/db and run OrderImport again
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        static void UpdateInventory()
        {
            string your_dc_id = "ABC";

            string inventory_url = "/vendor/directFulfillment/inventory/v1/warehouse/" + your_dc_id + "/items";

            restClient = new RestClient(live_url_base);
            IRestRequest restRequest = new RestRequest(inventory_url, Method.POST);
            

            restRequest.AddHeader("x-amz-access-token", "token_from_your_secure_db");

            string json = BuildInventoryUpdateFeed();

            restRequest.AddParameter(content_json, json, ParameterType.RequestBody);

            var request = signatureHelper.SignRequest(restRequest, restClient, content_json);

            try
            {
                var result = restClient.Execute(request);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        static string BuildInventoryUpdateFeed()
        {
            var details = new InventoryDetails();
            details.sellingParty = new InventoryModel.SellingParty() { partyId = "your_vendor_id" };
            details.isFullUpdate = false;
            
            var update = new InventoryUpdate();
            update.inventory = details;
            
            var list = new List<InventoryItem>();
            var item = new InventoryItem();
            item.buyerProductIdentifier = "buyer_item";
            item.vendorProductIdentifier = "vendor_item";
            item.isObsolete = false;

            var available = new Available();
            available.amount = 345;
            available.unitOfMeasure = "Each";

            item.availableQuantity = available;

            list.Add(item);

            details.items = list;

            return JsonConvert.SerializeObject(update, Formatting.Indented);

            
        }
    }
}
