using Newtonsoft.Json;

namespace Bt.IPay.Net.Requests.Register
{
    public class CustomerDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("deliveryInfo")]
        public DeliveryInfo DeliveryInfo { get; set; }
        [JsonProperty("billingInfo")]
        public BillingInfo BillingInfo { get; set; }
    }
}