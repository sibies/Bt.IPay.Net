using Newtonsoft.Json;

namespace Bt.IPay.Net.Reqursts.Register
{
    public class DeliveryInfo
    {
        [JsonProperty("deliveryType")]
        public string DeliveryType { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("postAddress")]
        public string PostAddress { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}