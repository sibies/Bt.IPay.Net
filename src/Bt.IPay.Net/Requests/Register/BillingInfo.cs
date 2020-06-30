using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests.Register
{
    public class BillingInfo
    {
        [JsonProperty("deliveryType")]
        public string DeliveryType { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("postAddress")]
        public string PostAddress { get; set; }
        [JsonProperty("postAddress2")]
        public string PostAddress2 { get; set; }
        [JsonProperty("postAddress3")]
        public string PostAddress3 { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}