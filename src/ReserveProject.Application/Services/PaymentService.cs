using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Services
{
    public static class PaymentService
    {
        private static string Token()
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"1006:581ba5eeadd657c8ccddc74c839bd3ad"));

            var client = new RestClient("https://dev.ipay.ge/opay/api/v1/oauth2/token/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {encoded}");
            request.AddParameter("grant_type", "client_credentials");
            IRestResponse response = client.Execute(request);

            var accessToken = JsonConvert
                .DeserializeObject<TokenResponse>(response.Content)
                .AccessToken;

            return accessToken;
        }

        public static OrderResponse Order(string accessToken, OrderRequest order)
        {
            var body = JsonConvert.SerializeObject(order);

            var client = new RestClient("https://dev.ipay.ge/opay/api/v1/checkout/orders/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialized = JsonConvert
               .DeserializeObject<OrderResponse>(response.Content);
            return deserialized;
        }

        private class TokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }

        public class OrderRequest
        {
            public string intent { get; set; }
            public string redirect_url { get; set; }
            public string shop_order_id { get; set; }
            public string card_transaction_id { get; set; }
            public string locale { get; set; }
            public Purchase_Units[] purchase_units { get; set; }
            public Item[] items { get; set; }

            public class Purchase_Units
            {
                public Amount amount { get; set; }
                public string industry_type { get; set; }
            }

            public class Amount
            {
                public string currency_code { get; set; }
                public int value { get; set; }
            }

            public class Item
            {
                public string product_id { get; set; }
                public int quantity { get; set; }
                public int amount { get; set; }
                public string description { get; set; }
            }
        }

        public class OrderResponse
        {
            public string status { get; set; }
            public string payment_hash { get; set; }
            public Link[] links { get; set; }
            public string order_id { get; set; }

            public class Link
            {
                public string href { get; set; }
                public string rel { get; set; }
                public string method { get; set; }
            }
        }
    }
}
